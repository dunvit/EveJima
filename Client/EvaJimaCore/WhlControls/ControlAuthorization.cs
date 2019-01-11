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
    public partial class ControlAuthorization : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ControlAuthorization));

        public event Action<string> OnSelectUser;

        public ControlAuthorization()
        {
            InitializeComponent();

            Pilotes = new List<PilotEntity>();

            label1.Text = Localization.Messages.Get("LoadAllPilotesFromStorage");
            btnEditPilots.Text = Localization.Messages.Get("Tab_Authorization_EditPilots", "Edit Pilots");
            lblAuthorizationInfo.Text = Localization.Messages.Get("TextAuthorizationInfo");

            if (IsDebug) return;

            Global.Pilots.OnAddPilot += AddPilotToPilotsList;
            Global.Pilots.OnActivatePilot += ActivatePilot;
        }

        private void ActivatePilot(PilotEntity pilot)
        {
            cmbPilots.SelectedIndex = cmbPilots.FindString(pilot.Name);
            Log.DebugFormat("[whlAuthorization.ActivatePilot] cmbPilots.SelectedIndex {0}", cmbPilots.FindString(pilot.Name));
            RefreshPilotInfo();
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (IsDebug) return;

            if (Visible && !Disposing)
            {
                if (Global.ApplicationSettings.Pilots.Count > 0 && Pilotes.Count < 1 )
                {
                    cmdLoadPilotes.Value = string.Format(Localization.Messages.Get("LoadPilotsFromCache"), Global.ApplicationSettings.Pilots.Count);
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
                    lblUpdateLog.Text = string.Format( Localization.Messages.Get("StartAuthorizePilot"), pilot.Item1);
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
            btnEditPilots.Visible = true;
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

            btnEditPilots.Visible = true;
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

            lblAuthorizationInfo.Text = Localization.Messages.Get("TextAfterAuthorizationInfo") + Environment.NewLine + Environment.NewLine + Localization.Messages.Get("TextAuthorizationInfo");
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
                lblAuthorizationInfo.Text = Localization.Messages.Get("TextAfterAuthorizationInfo") + Environment.NewLine + Environment.NewLine + Localization.Messages.Get("TextAuthorizationInfo");
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
            lblAuthorizationInfo.Text = Localization.Messages.Get("TextAuthorizationInfo");
        }

        private void cmdLoadPilotes_Click(object sender, EventArgs e)
        {
            cmdLoadPilotes.Visible = false;

            LoadAllPilotesFromStorage();

            btnLogInWithEveOnline.Visible = true;
        }

        private void btnEditPilots_Click(object sender, EventArgs e)
        {
            Global.Presenter.ChangeScreen("EditPilots");
        }

        public override void ActivateContainer()
        {
            var a = "";
        }

    }
}
