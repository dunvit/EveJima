using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ControlAuthorization : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ControlAuthorization));

        private delegate void SetTextCallback(string text);

        private delegate void SetSelectedItem(int item);

        public event Action<string> OnSelectUser;

        public ControlAuthorization()
        {
            InitializeComponent();

            Pilots = new List<PilotEntity>();

            label1.Text = Localization.Messages.Get("LoadAllPilotesFromStorage");
            btnEditPilots.Text = Localization.Messages.Get("Tab_Authorization_EditPilots", "Edit Pilots");
            lblAuthorizationInfo.Text = Localization.Messages.Get("TextAuthorizationInfo");

            if (IsDebug) return;

            Global.Pilots.OnAddPilot += AddPilotToPilotsList;
            Global.Pilots.OnActivatePilot += ActivatePilot;
        }

        private void ActivatePilot(PilotEntity pilot)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ActivatePilot(pilot)));
            }

            SetSelected(cmbPilots.FindString(pilot.Name));

            Log.DebugFormat("[whlAuthorization.ActivatePilot] cmbPilots.SelectedIndex {0}", cmbPilots.FindString(pilot.Name));
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (IsDebug) return;

            if (Visible && !Disposing)
            {
                if (Global.ApplicationSettings.Pilots.Count > 0 && Pilots.Count < 1 )
                {
                    cmdLoadPilotes.Value = string.Format(Localization.Messages.Get("LoadPilotsFromCache"), Global.ApplicationSettings.Pilots.Count);
                    cmdLoadPilotes.Visible = true;
                    btnLogInWithEveOnline.Visible = false;
                }
            }
        }

        private List<PilotEntity> Pilots { get; set; }

        private bool _isLoadedPilotsFromStorage = true ;

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
            if (cmbPilots.Visible == false && _isLoadedPilotsFromStorage)
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

            if (Global.Pilots == null || Global.Pilots.Selected == null) return;

            crlPilotPortrait.Image = Global.Pilots.Selected.Portrait;
            crlPilotPortrait.Refresh();

            crlPilotPortrait.Visible = true;

            lblAuthorizationInfo.Text = Localization.Messages.Get("TextAfterAuthorizationInfo") + Environment.NewLine + Environment.NewLine + Localization.Messages.Get("TextAuthorizationInfo");
            Log.DebugFormat("[whlAuthorization.RefreshPilotInfo] cmbPilots.SelectedIndex");
        }


        private void ShowPilots()
        {
            if (Pilots.Count <= 0) return;

            PilotEntity pilot = null;

            foreach (var pilotEntity in Pilots)
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
            if (_isLoadedPilotsFromStorage)
            {
                Global.Pilots.Activate(cmbPilots.Text);

                RefreshPilotInfo();
            }
        }

        private void cmdLoadPilotes_Click(object sender, EventArgs e)
        {
            cmdLoadPilotes.Visible = false;

            _isLoadedPilotsFromStorage = false;

            LoadPilots();
        }

        private async void LoadPilots()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadPilots));
            }

            lblAuthorizationInfo.Visible = false;
            lblAuthorizationInfo.Refresh();

            containerScreenUpdate.Location = new Point(100, 21);
            containerScreenUpdate.Refresh();

            Pilots = await Task.Run(() => AuthorizePilots());

            containerScreenUpdate.Location = new Point(-500, -500);
            lblAuthorizationInfo.Visible = true;
            btnEditPilots.Visible = true;

            lblAuthorizationInfo.Refresh();

            ShowPilots();

            cmbPilots.TextChanged += (cmbPilots_TextChanged);

            _isLoadedPilotsFromStorage = true;

            btnLogInWithEveOnline.Visible = true;
        }

        

        private List<PilotEntity> AuthorizePilots()
        {
            var pilots = new List<PilotEntity>();

            foreach (var pilot in Global.ApplicationSettings.Pilots)
            {
                try
                {
                    SetText(string.Format(Localization.Messages.Get("StartAuthorizePilot"), pilot.Item1));

                    var currentPilot = new PilotEntity(pilot.Item2, pilot.Item3) { Key = pilot.Item4 };

                    pilots.Add(currentPilot);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlAuthorization.LoadAllPilotesFromStorage] Critical error. Exception {0}", ex);
                }
            }

            return pilots;
        }

        private void SetText(string text)
        {
            if (lblUpdateLog.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, text);
            }
            else
            {
                lblUpdateLog.Text = text;
            }
        }

        private void SetSelected(int index)
        {
            if (lblUpdateLog.InvokeRequired)
            {
                var d = new SetSelectedItem(SetSelected);
                Invoke(d, index);
            }
            else
            {
                cmbPilots.SelectedIndex = index;
                if (Global.Pilots == null || Global.Pilots.Selected == null) return;

                crlPilotPortrait.Image = Global.Pilots.Selected.Portrait;
                crlPilotPortrait.Refresh();

                crlPilotPortrait.Visible = true;

                lblAuthorizationInfo.Text = Localization.Messages.Get("TextAfterAuthorizationInfo") + Environment.NewLine + Environment.NewLine + Localization.Messages.Get("TextAuthorizationInfo");
                Log.DebugFormat("[whlAuthorization.RefreshPilotInfo] cmbPilots.SelectedIndex");
            }
        }

        private void btnEditPilots_Click(object sender, EventArgs e)
        {
            Global.Presenter.ChangeScreen("EditPilots");
        }

        public override void ActivateContainer()
        {
            
        }

    }
}
