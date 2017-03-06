using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlSolarSystem : baseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlSolarSystem));

        public DelegateShowLostAndFoundOffice OnShowLostAndFoundOffice;
        public DelegateShowTravelHistory OnShowTravelHistory;
        public DelegateChangeSolarSystemInfo OnChangeSolarSystemInfo;

        public BrowserNavigate OnBrowserNavigate;

        public StarSystemEntity SolarSystem { get; set; }

        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();

        

        public whlSolarSystem()
        {
            InitializeComponent();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;

            cmbServices.Items.Add("Zkillboard");
            cmbServices.Items.Add("Superpute");
            cmbServices.Items.Add("Ellatha");
            cmbServices.Items.Add("Dotlan");
            cmbServices.Items.Add("Tripwire");
            cmbServices.Items.Add("Pasta.gg");

            cmbServices.SelectedIndex = cmbServices.FindString("Zkillboard");

            cmbServices.Visible = true;

        }

        public void RefreshSolarSystem(StarSystemEntity location)
        {
            if (location == null) return;

            SolarSystem = location.Clone() as StarSystemEntity;

            if (Global.Pilots.Selected.Location.System == "unknown") return;

            txtSolarSystemName.Text = Global.Pilots.Selected.Location.System;
            txtSolarSystemClass.Text = Global.Pilots.Selected.Location.Class;
            txtSolarSystemEffect.Text = Global.Pilots.Selected.Location.Effect.Trim();
            txtSolarSystemRegion.Text = Global.Pilots.Selected.Location.Region.Replace(" Unknown (", "").Replace(")", "");
            txtSolarSystemConstellation.Text = Global.Pilots.Selected.Location.Constelation.Replace(" Unknown (", "").Replace(")", "");

            txtSolarSystemStaticI.Text = "";
            txtSolarSystemStaticII.Text = "";

            txtSolarSystemStaticIData.Text = "";
            txtSolarSystemStaticIIData.Text = "";

            txtSolarSystemStaticI.Visible = false;
            txtSolarSystemStaticII.Visible = false;
            txtSolarSystemStaticIData.Visible = false;
            txtSolarSystemStaticIIData.Visible = false;

            var title = Global.Pilots.Selected.Location.System + "";

            if (string.IsNullOrEmpty(Global.Pilots.Selected.Location.Class) == false)
            {
                title = title + "[C" + Global.Pilots.Selected.Location.Class + "]";
            }

            if (string.IsNullOrEmpty(Global.Pilots.Selected.Location.Static) == false)
            {
                var wormholeI = Global.Space.Wormholes[Global.Pilots.Selected.Location.Static.Trim()];

                txtSolarSystemStaticI.Text = wormholeI.Name;
                txtSolarSystemStaticI.Visible = true;
                txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);
                txtSolarSystemStaticIData.Text = wormholeI.LeadsTo;
                txtSolarSystemStaticIData.Visible = true;

                toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass + "\r\nMax Life time =" + wormholeI.Lifetime);

                title = title + " " + wormholeI.Name + "[" + wormholeI.LeadsTo + "]";
            }

            if (string.IsNullOrEmpty(Global.Pilots.Selected.Location.Static2) == false)
            {
                var wormholeII = Global.Space.Wormholes[Global.Pilots.Selected.Location.Static2.Trim()];


                txtSolarSystemStaticII.Text = wormholeII.Name;
                txtSolarSystemStaticII.Visible = true;
                txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);
                txtSolarSystemStaticIIData.Text = wormholeII.LeadsTo;
                txtSolarSystemStaticIIData.Visible = true;

                toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass + "\r\nMax Life time =" + wormholeII.Lifetime);

                title = title + " " + wormholeII.Name + "[" + wormholeII.LeadsTo + "]";
            }

            if (OnChangeSolarSystemInfo == null) return;

            try
            {
                OnChangeSolarSystemInfo(title);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlSolarSystem.RefreshSolarSystem] Critical error = {0}", ex);
            }
        }

        private void Event_ShowTravelHistory(object sender, EventArgs e)
        {
            OnShowTravelHistory();
        }

        private void Event_OpenLostAndFoundOffice(object sender, EventArgs e)
        {
            //Global.Pilots.Selected.CrestData.SetWaypoint(Global.Pilots.Selected.Id);

            OnShowLostAndFoundOffice();
        }

        private void Event_ServiceShow(object sender, EventArgs e)
        {
            switch (cmbServices.Text)
            {
                case "Zkillboard":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                        OnBrowserNavigate("https://zkillboard.com/system/" + Global.Pilots.Selected.Location.Id.Replace("J", "") + "/");
                    break;
                case "Superpute":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                        OnBrowserNavigate("http://superpute.com/system/" + Global.Pilots.Selected.Location.System + "");
                    break;
                case "Ellatha":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                    {
                        if (Global.Pilots.Selected.Location.System.Contains("J") == false)
                        {
                            MessageBox.Show(@"Ellatha only for W-Space systems");
                            return;
                        }

                        OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + Global.Pilots.Selected.Location.System.Replace("J", "") + "");
                    }
                    break;
                case "Dotlan":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                        OnBrowserNavigate("http://evemaps.dotlan.net/system/" + Global.Pilots.Selected.Location.System + "");
                    break;
                case "Tripwire":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                        OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + SolarSystem.System + "");
                    break;
                case "Pasta.gg":
                    if (SolarSystem != null && SolarSystem.System != "unknown")
                        OnBrowserNavigate("http://wh.pasta.gg/" + SolarSystem.System + "");
                    break;

            }
        }

        private void Event_SelectService(object sender, EventArgs e)
        {
            cmdShow.Value = cmbServices.Text + @" Show"; 
        }
    }
}
