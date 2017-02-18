using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlSolarSystemOffline : baseContainer
    {
        public BrowserNavigate OnBrowserNavigate;

        private static readonly ILog Log = LogManager.GetLogger(typeof(whlSolarSystemOffline));

        public StarSystemEntity SolarSystem { get; set; }


        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();

        public whlSolarSystemOffline()
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
        }

        public void RefreshSolarSystem(StarSystemEntity location)
        {
            SolarSystem = location.Clone() as StarSystemEntity;

            txtSolarSystemClass.Text = location.Class;
            txtSolarSystemEffect.Text = location.Effect.Trim();
            txtSolarSystemRegion.Text = location.Region.Replace(" Unknown (", "").Replace(")", "");
            txtSolarSystemConstellation.Text = location.Constelation.Replace(" Unknown (", "").Replace(")", "");

            txtSolarSystemStaticI.Text = "";
            txtSolarSystemStaticII.Text = "";

            txtSolarSystemStaticIData.Text = "";
            txtSolarSystemStaticIIData.Text = "";

            txtSolarSystemStaticI.Visible = false;
            txtSolarSystemStaticII.Visible = false;
            txtSolarSystemStaticIData.Visible = false;
            txtSolarSystemStaticIIData.Visible = false;

            if (string.IsNullOrEmpty(location.Static) == false)
            {
                var wormholeI = Global.Space.Wormholes[location.Static.Trim()];

                txtSolarSystemStaticI.Text = wormholeI.Name;
                txtSolarSystemStaticI.Visible = true;
                txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);
                txtSolarSystemStaticIData.Text = wormholeI.LeadsTo;
                txtSolarSystemStaticIData.Visible = true;

                toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass);

            }

            if (string.IsNullOrEmpty(location.Static2) == false)
            {
                var wormholeII = Global.Space.Wormholes[location.Static2.Trim()];


                txtSolarSystemStaticII.Text = wormholeII.Name;
                txtSolarSystemStaticII.Visible = true;
                txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);
                txtSolarSystemStaticIIData.Text = wormholeII.LeadsTo;
                txtSolarSystemStaticIIData.Visible = true;

                toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass);
            }
        }




        private void Event_ShowZkillboard(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            OnBrowserNavigate("https://zkillboard.com/system/" + Global.Space.BasicSolarSystems[txtSolarSystem.Text.Trim().ToUpper()] + "/");
        }

        private void Event_ShowSuperpute(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            OnBrowserNavigate("http://superpute.com/system/" + txtSolarSystem.Text.Trim() + "");
        }

        private void Event_ShowEllatha(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            if (txtSolarSystem.Text.Trim().Contains("J") == false)
            {
                MessageBox.Show(@"Ellatha only for W-Space systems");
                return;
            }

            OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + txtSolarSystem.Text.Trim().Replace("J", "") + "");
            
        }

        private void Event_ShowDotlan(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            OnBrowserNavigate("http://evemaps.dotlan.net/system/" + txtSolarSystem.Text.Trim() + "");
        }

        private void Event_TripwireShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + txtSolarSystem.Text + "");
        }

        private void Event_AnalizeSolarSystem(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            LoadLocationInfo(txtSolarSystem.Text);

            RefreshSolarSystem(SolarSystem);
        }

        

        private void LoadLocationInfo(string solarSystemName)
        {
            Log.DebugFormat("[whlSolarSystemOffline.LoadLocationInfo] starting for solarSystemName = {0}", solarSystemName);

            try
            {
                if (SolarSystem == null) SolarSystem = new StarSystemEntity();

                if (Global.Space.SolarSystems.ContainsKey(solarSystemName))
                {
                    var location = Global.Space.SolarSystems[solarSystemName];

                    SolarSystem = location.Clone() as StarSystemEntity;

                    if (SolarSystem != null)
                    {
                        SolarSystem.Id = Global.Space.BasicSolarSystems[solarSystemName.ToUpper()];
                    }
                }
                else
                {
                    SolarSystem.Region = "";
                    SolarSystem.Constelation = "";
                    SolarSystem.Effect = "";
                    SolarSystem.Class = "";
                    SolarSystem.Static2 = "";
                    SolarSystem.Static = "";

                    SolarSystem.Id = Global.Space.BasicSolarSystems[solarSystemName.ToUpper()];

                    SolarSystem.System = solarSystemName;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlSolarSystemOffline.LoadLocationInfo] Critical error. Exception {0}", ex);

                if (SolarSystem != null)
                {
                    SolarSystem.System = "unknown";
                }
            }
        }

        private void Event_SolarSystemNameLeave(object sender, EventArgs e)
        {
            LoadLocationInfo(txtSolarSystem.Text);

            RefreshSolarSystem(SolarSystem);
        }

        private void Event_ShowWormholePvE(object sender, EventArgs e)
        {
            OnBrowserNavigate("https://docs.google.com/spreadsheets/d/17cNu8hxqJKqkkPnhDlIuJY-IT6ps7kTNCd3BEz0Bvqs/pubhtml#");
        }

        private void Event_PastaShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            OnBrowserNavigate("http://wh.pasta.gg/" + txtSolarSystem.Text.Trim() + "");
        }
    }
}
