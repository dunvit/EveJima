using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlAuthorization : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlAuthorization));

        private const string TextAuthorizationInfo =
            "To login you will need to press the button and go to the  CCP SSO (single sign-on) site. All your private data will remain on the CCP's website.";

        private const string TextAfterAuthorizationInfo =
            "You have successfully logged into the system and the EveJima can now keep track of your current position. You can log in again with another character.";

        private const string TextErrorAuthorizationInfo = "It has failed to create a local server. Log in CCP SSO (single sign-on) site is not possible.";

        public whlAuthorization()
        {
            InitializeComponent();

            
        }

        private void Event_GoToCCPSSO(object sender, EventArgs e)
        {
            var data = WebUtility.UrlEncode(@"http://localhost:" + Global.Settings.CCPSSO_AUTH_PORT + "/WormholeLocator");
            Process.Start("https://login.eveonline.com/oauth/authorize?response_type=code&redirect_uri=" + data +
                          "&client_id=" + Global.Settings.CCPSSO_AUTH_CLIENT_ID + "&scope=" + Global.Settings.CCPSSO_AUTH_SCOPES + "&state=" + Global.Settings.CCPSSO_AUTH_CLIENT_STATE + "");
        }

        public void PilotAuthorizeFlow(string code)
        {
            Log.DebugFormat("[whlAuthorization.PilotAuthorizeFlow] starting for token = {0}", code);

            var _currentPilot = new PilotEntity();

            _currentPilot.Initialization(code);



            if (Global.Pilots.IsExist(_currentPilot.Id) == false)
            {
                Global.Pilots.Add(_currentPilot);

                cmbPilots.Items.Add(_currentPilot.Name.Trim());
                cmbPilots.Text = _currentPilot.Name.Trim();
            }

            cmbPilots.Visible = true;

            Global.Pilots.Selected = _currentPilot;

        }

        public void RefreshPilotInfo()
        {
            crlPilotPortrait.Image = Global.Pilots.Selected.Portrait;
            crlPilotPortrait.Refresh();

            crlPilotPortrait.Visible = true;

            lblAuthorizationInfo.Text = TextAfterAuthorizationInfo + Environment.NewLine + Environment.NewLine + TextAuthorizationInfo;
        }

        private void cmbPilots_TextChanged(object sender, EventArgs e)
        {
            Global.Pilots.Activate(cmbPilots.Text);

            RefreshPilotInfo();
        }

        private void Event_FormLoad(object sender, EventArgs e)
        {
            
        }

        public void RefreshAuthorizationStatus()
        {
            //if (Global.Settings.IsAuthorizationEnabled)
            //{
            //    lblAuthorizationInfo.Text = TextAuthorizationInfo;
            //}
            //else
            //{
            //    lblAuthorizationInfo.Text = TextErrorAuthorizationInfo;
            //    btnLogInWithEveOnline.Visible = false;
            //}
        }


    }
}
