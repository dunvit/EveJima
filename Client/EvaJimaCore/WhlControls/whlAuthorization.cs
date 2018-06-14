using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlAuthorization : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlAuthorization));

        public event Action<string> OnSelectUser; 

        public whlAuthorization()
        {
            InitializeComponent();

            Pilotes = new List<PilotEntity>();

            label1.Text = Global.Messages.Get("LoadAllPilotesFromStorage");
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if(Visible && !Disposing)
            {
                if (Global.ApplicationSettings.Pilots.Count > 0 && Pilotes.Count < 1 )
                {
                    cmdLoadPilotes.Value = string.Format(Global.Messages.Get("LoadPilotsFromCache"), Global.ApplicationSettings.Pilots.Count);
                    cmdLoadPilotes.Visible = true;
                    btnLogInWithEveOnline.Visible = false;
                }
            }
        }

        List<PilotEntity> Pilotes { get; set; }

        private bool _isLoadedPilotesFromStorage = true ;



        public void LoadAllPilotesFromStorage()
        {
            _isLoadedPilotesFromStorage = false;

            if (InvokeRequired)
            {
                Invoke(new Action(LoadAllPilotesFromStorage));
            }

            AuthorizeAllPilotsInAccount();

            ShowPilots();

            _isLoadedPilotesFromStorage = true;
        }

        public void AuthorizeAllPilotsInAccount()
        {
            lblAuthorizationInfo.Visible = false;
            lblAuthorizationInfo.Refresh();

            containerScreenUpdate.Location = new Point(100, 21);
            containerScreenUpdate.Refresh();

            Pilotes = new List<PilotEntity>();

            foreach (var pilot in Global.ApplicationSettings.Pilots)
            {
                try
                {
                    lblUpdateLog.Text = string.Format( Global.Messages.Get("StartAuthorizePilot"), pilot.Item1);
                    lblUpdateLog.Refresh();

                    var currentPilot = new PilotEntity(pilot.Item2, pilot.Item3) { Key = pilot.Item4 };

                    Pilotes.Add(currentPilot);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlAuthorization.LoadAllPilotesFromStorage] Critical error. Exception {0}", ex);
                }

            }

            

            containerScreenUpdate.Location = new Point(-500, -500);
            lblAuthorizationInfo.Visible = true;
            lblAuthorizationInfo.Refresh();
        }

        private void Event_GoToCCPSSO(object sender, EventArgs e)
        {
            var data = WebUtility.UrlEncode(@"http://localhost:" + Global.ApplicationSettings.Authorization_Port + "/WormholeLocator");

            var address = "https://login.eveonline.com/oauth/authorize?response_type=code&redirect_uri=" + data +
                          "&client_id=" + Global.ApplicationSettings.Authorization_ClientId +
                          "&scope=" + Global.ApplicationSettings.Authorization_Scopes + "&state=" +
                          Global.ApplicationSettings.Authorization_ClientState + "";

            Process.Start(address);
        }

        private void AddPilotToPilotsList(PilotEntity pilot)
        {
            if (cmbPilots.Visible == false)
            {
                cmbPilots.Visible = true;
                cmbPilots.Refresh();
            }

            var isPilotExist = false;

            foreach(var item in cmbPilots.Items)
            {
                if(item.ToString() == pilot.Name)
                {
                    isPilotExist = true;
                }
            }

            if (isPilotExist == false)
            {
                cmbPilots.Items.Add(pilot.Name.Trim());
                cmbPilots.Text = pilot.Name.Trim();

            }



        }

        public void PilotAuthorizeFlow(string code)
        {
            Log.DebugFormat("[whlAuthorization.PilotAuthorizeFlow] starting for token = {0}", code);

            try
            {
                var _currentPilot = new PilotEntity(code);

                Global.Metrics.PublishOnPilotInitialization(_currentPilot.Id);

                if (Global.Pilots.IsExist(_currentPilot.Id) == false)
                {

                    Global.ApplicationSettings.UpdatePilotInStorage(_currentPilot.Name, _currentPilot.Id.ToString(), _currentPilot.EsiData.RefreshToken, _currentPilot.Key);

                    Global.Pilots.Add(_currentPilot);

                    cmbPilots.Visible = true;

                    Global.Pilots.SetSelected(_currentPilot);

                    AddPilotToPilotsList(_currentPilot);

                    Pilotes.Add(_currentPilot);
                }
                else
                {
                    // Update token
                    Global.ApplicationSettings.UpdatePilotInStorage(_currentPilot.Name, _currentPilot.Id.ToString(), _currentPilot.EsiData.RefreshToken, _currentPilot.Key);
                }

                cmbPilots.Visible = true;

                Global.Pilots.SetSelected(_currentPilot);

                
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlAuthorization.PilotAuthorizeFlow] Critical error. Exception {0}", ex);
            }
        }


        public void SelectPilot(string pilot)
        {
            cmbPilots.SelectedIndex = cmbPilots.FindString(pilot);
            Log.DebugFormat("[whlAuthorization.SelectPilot] cmbPilots.SelectedIndex {0}", cmbPilots.FindString(pilot).ToString());
            RefreshPilotInfo();
        }

        public void RefreshPilotInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RefreshPilotInfo()));
            }

            crlPilotPortrait.Image = Global.Pilots.Selected.Portrait;
            crlPilotPortrait.Refresh();

            crlPilotPortrait.Visible = true;

            lblAuthorizationInfo.Text = Tools.GetValue("TextAfterAuthorizationInfo", Global.ApplicationSettings.LanguageId) + Environment.NewLine + Environment.NewLine + Tools.GetValue("TextAuthorizationInfo", Global.ApplicationSettings.LanguageId);
            Log.DebugFormat("[whlAuthorization.RefreshPilotInfo] cmbPilots.SelectedIndex");
        }


        private void ShowPilots()
        {
            if (Pilotes.Count <= 0) return;

            PilotEntity pilot = null;

            foreach (var pilotEntity in Pilotes)
            {
                var isFirstMapLoad = false;

                if (pilotEntity.Key == "")
                {
                    pilotEntity.Key = Name;
                    isFirstMapLoad = true;
                }

                Global.Pilots.Add(pilotEntity);

                AddPilotToPilotsList(pilotEntity);

                pilot = pilotEntity;

                if (isFirstMapLoad)
                {
                    Global.ApplicationSettings.UpdatePilotInStorage(pilotEntity.Name, pilotEntity.Id.ToString(), pilotEntity.RefreshToken, pilotEntity.Key);

                    Global.ApplicationSettings.Save();
                }
            }

            if(pilot != null) Global.Pilots.SetSelected(pilot);

            cmbPilots.Invoke(new MethodInvoker(delegate
            {
                btnLogInWithEveOnline.Visible = true;
                cmbPilots.Visible = true;
                crlPilotPortrait.Image = Global.Pilots.Selected.Portrait;
                crlPilotPortrait.Refresh();
                crlPilotPortrait.Visible = true;
                lblAuthorizationInfo.Text = Tools.GetValue("TextAfterAuthorizationInfo", Global.ApplicationSettings.LanguageId) + Environment.NewLine + Environment.NewLine + Tools.GetValue("TextAuthorizationInfo", Global.ApplicationSettings.LanguageId);
            }));
            
            if ( Global.Pilots.Selected != null )
            {
                Global.Pilots.Activate(Global.Pilots.Selected.Name);
            }
            
            OnSelectUser?.Invoke(Global.Pilots.Selected.Name);
        }

        private void cmbPilots_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadedPilotesFromStorage)
            {
                
                Global.Pilots.Activate(cmbPilots.Text);

                RefreshPilotInfo();
            }
        }

        public void RefreshAuthorizationStatus()
        {
            lblAuthorizationInfo.Text = Tools.GetValue("TextAuthorizationInfo", Global.ApplicationSettings.LanguageId);
        }

        private void cmdLoadPilotes_Click(object sender, EventArgs e)
        {
            cmdLoadPilotes.Visible = false;

            LoadAllPilotesFromStorage();

            btnLogInWithEveOnline.Visible = true;
        }
    }
}
