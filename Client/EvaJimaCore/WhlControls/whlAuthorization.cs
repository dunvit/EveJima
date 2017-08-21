using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.Logic;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlAuthorization : BaseContainer
    {

        public DelegateChangeSelectedPilot OnChangeSelectedPilot { get; set; }

        private static readonly ILog Log = LogManager.GetLogger(typeof(whlAuthorization));

        private const string TextAuthorizationInfo =
            "To login you will need to press the button and go to the  CCP SSO (single sign-on) site. All your private data will remain on the CCP's website.";

        private const string TextAfterAuthorizationInfo =
            "You have successfully logged into the system and the EveJima can now keep track of your current position. You can log in again with another character.";

        private const string TextErrorAuthorizationInfo = "It has failed to create a local server. Log in CCP SSO (single sign-on) site is not possible.";

        private const string TextPleaseWaitLoadingPilots = "Loading data from the pilots cache. Please wait. It may take a few seconds.";

        public whlAuthorization()
        {
            InitializeComponent();

            Pilotes = new List<PilotEntity>();
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if(Visible && !Disposing)
            {
                if (Global.ApplicationSettings.Pilots.Count > 0 && Pilotes.Count < 1 )
                {
                    cmdLoadPilotes.Value = $"Load {Global.ApplicationSettings.Pilots.Count} pilotes from cache";
                    cmdLoadPilotes.Visible = true;
                    btnLogInWithEveOnline.Visible = false;
                    
                }
            }
        }

        List<PilotEntity> Pilotes { get; set; }

        private bool _isLoadedPilotesFromStorage;



        public void LoadAllPilotesFromStorage()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LoadAllPilotesFromStorage()));
            }

            var screen = new ScreenUpdateToServer { ActionType = "LoadAllPilotesFromStorage", MapKey = "" };
            screen.AuthorizeAllPilotsInAccount += AuthorizeAllPilotsInAccount;
            screen.ShowDialog();

            ShowPilots();

            _isLoadedPilotesFromStorage = true;
        }

        public void AuthorizeAllPilotsInAccount(string obj)
        {
            Pilotes = new List<PilotEntity>();

            foreach (var pilot in Global.ApplicationSettings.Pilots)
            {
                try
                {
                    Messages.GetInstance().PublishMessage($"Start authorize for {pilot.Item1}");

                    var currentPilot = new PilotEntity(pilot.Item2, pilot.Item3) { Key = pilot.Item4 };

                    Pilotes.Add(currentPilot);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlAuthorization.LoadAllPilotesFromStorage] Critical error. Exception {0}", ex);
                }

            }
        }

        private void Event_GoToCCPSSO(object sender, EventArgs e)
        {
            var data = WebUtility.UrlEncode(@"http://localhost:" + Global.Settings.CCPSSO_AUTH_PORT + "/WormholeLocator");

            var address = "https://login.eveonline.com/oauth/authorize?response_type=code&redirect_uri=" + data +
                          "&client_id=" + Global.ApplicationSettings.Authorization_ClientId +
                          "&scope=" + Global.ApplicationSettings.Authorization_Scopes + "&state=" +
                          Global.ApplicationSettings.Authorization_ClientState + "";

            Process.Start(address);
        }

        private void AddPilotToPilotsList(PilotEntity pilot)
        {
            var isPilotExist = false;

            foreach(var item in cmbPilots.Items)
            {
                if(item.ToString() == pilot.Name)
                {
                    isPilotExist = true;
                }
            }

            if(isPilotExist == false)
            {
                cmbPilots.Items.Add(pilot.Name.Trim());
                cmbPilots.Text = pilot.Name.Trim();
            }

            
        }

        public void PilotAuthorizeFlow(string code)
        {
            Log.DebugFormat("[whlAuthorization.PilotAuthorizeFlow] starting for token = {0}", code);

            var _currentPilot = new PilotEntity(code);

            //_currentPilot.Initialization(code);

            Global.Metrics.PublishOnPilotInitialization(_currentPilot.Id);

            if (Global.Pilots.IsExist(_currentPilot.Id) == false)
            {

                Global.ApplicationSettings.UpdatePilotInStorage(_currentPilot.Name, _currentPilot.Id.ToString(), _currentPilot.EsiData.RefreshToken, _currentPilot.Key);

                //Global.Pilots.Add(_currentPilot);

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

            ShowPilots();
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

            lblAuthorizationInfo.Text = TextAfterAuthorizationInfo + Environment.NewLine + Environment.NewLine + TextAuthorizationInfo;
            Log.DebugFormat("[whlAuthorization.RefreshPilotInfo] cmbPilots.SelectedIndex");
            if (OnChangeSelectedPilot != null) OnChangeSelectedPilot();
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
                if (OnChangeSelectedPilot != null) OnChangeSelectedPilot();
                lblAuthorizationInfo.Text = TextAfterAuthorizationInfo + Environment.NewLine + Environment.NewLine + TextAuthorizationInfo;
            }));
            

            if ( Global.Pilots.Selected != null )
            {
                Global.Pilots.Activate(Global.Pilots.Selected.Name);
            }
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
            if (Global.Settings.IsAuthorizationEnabled)
            {
                lblAuthorizationInfo.Text = TextAuthorizationInfo;
            }
            else
            {
                lblAuthorizationInfo.Text = TextErrorAuthorizationInfo;
                btnLogInWithEveOnline.Visible = false;
            }

            //string[] allLines = Global.Pilots.GetPilotsStorageContent();

            //if (allLines.Count() > 0)
            //{
            //    lblAuthorizationInfo.Text = TextPleaseWaitLoadingPilots + Environment.NewLine + Environment.NewLine;
            //    btnLogInWithEveOnline.Visible = false;
            //}

            
        }

        private void cmbPilots_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdLoadPilotes_Click(object sender, EventArgs e)
        {
            cmdLoadPilotes.Visible = false;

            LoadAllPilotesFromStorage();

            btnLogInWithEveOnline.Visible = true;
        }
    }
}
