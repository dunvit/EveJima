using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlSolarSystemOffline : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlSolarSystemOffline));

        public EveJimaUniverse.System SolarSystem { get; set; }


        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();

        private string maxStableMass = Global.Messages.Get("Tab_Information_MaxStableMass");
        private string maxJumpMass = Global.Messages.Get("Tab_Information_MaxJumpMass");

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

            lnlSystemText.Text = Global.Messages.Get("Tab_Information_SolarSystem") + @": ";
            label4.Text = Global.Messages.Get("Tab_Information_Region") + @": ";
            label8.Text = Global.Messages.Get("Tab_Information_Constellation") + @": ";
            label5.Text = Global.Messages.Get("Tab_Information_Class") + @": ";
            label6.Text = Global.Messages.Get("Tab_Information_Effect") + @": ";
            label7.Text = Global.Messages.Get("Tab_Information_Static") + @": I";
            label1.Text = Global.Messages.Get("Tab_Information_Static") + @": II";
        }

        public void RefreshSolarSystem(EveJimaUniverse.System location)
        {
            SolarSystem = location.Clone() as EveJimaUniverse.System;

            txtSolarSystemClass.Text = location.Class;
            if (location.Effect != null) txtSolarSystemEffect.Text = location.Effect.Trim();
            if (location.Region!= null) txtSolarSystemRegion.Text = location.Region.Replace(" Unknown (", "").Replace(")", "");
            if (location.Constelation != null) txtSolarSystemConstellation.Text = location.Constelation != null ? location.Constelation.Replace(" Unknown (", "").Replace(")", "") : "";

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
                var wormholeI = Global.Space.WormholeTypes[location.Static.Trim()];

                txtSolarSystemStaticI.Text = wormholeI.Name;
                txtSolarSystemStaticI.Visible = true;
                txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);
                txtSolarSystemStaticIData.Text = wormholeI.LeadsTo;
                txtSolarSystemStaticIData.Visible = true;

                toolTip1.SetToolTip(txtSolarSystemStaticI, maxStableMass + "=" + wormholeI.TotalMass + "\r\n" + maxJumpMass + "=" + wormholeI.SingleMass);

            }

            if (string.IsNullOrEmpty(location.Static2) == false)
            {
                var wormholeII = Global.Space.WormholeTypes[location.Static2.Trim()];


                txtSolarSystemStaticII.Text = wormholeII.Name;
                txtSolarSystemStaticII.Visible = true;
                txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);
                txtSolarSystemStaticIIData.Text = wormholeII.LeadsTo;
                txtSolarSystemStaticIIData.Visible = true;

                toolTip2.SetToolTip(txtSolarSystemStaticII, maxStableMass + "=" + wormholeII.TotalMass + "\r\n" + maxJumpMass + "=" + wormholeII.SingleMass);
            }
        }




        private void Event_ShowZkillboard(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("https://zkillboard.com/system/" + Global.Space.GetSystemByName(txtSolarSystem.Text.Trim().ToUpper()).Id + "/");
        }

        private void Event_ShowSuperpute(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://superpute.com/system/" + txtSolarSystem.Text.Trim() + "");
        }

        private void Event_ShowEllatha(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            if (txtSolarSystem.Text.Trim().Contains("J") == false)
            {
                MessageBox.Show(Global.Messages.Get("Tab_Information_EllathaWarning"));
                return;
            }

            Global.InternalBrowser.OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + txtSolarSystem.Text.Trim().Replace("J", "") + "");
            
        }

        private void Event_ShowDotlan(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://evemaps.dotlan.net/system/" + txtSolarSystem.Text.Trim() + "");
        }

        private void Event_TripwireShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + txtSolarSystem.Text + "");
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
                if (SolarSystem == null) SolarSystem = new EveJimaUniverse.System();

                if (Global.Space.GetSystemByName(solarSystemName) != null)
                {
                    var location = Global.Space.GetSystemByName(solarSystemName);

                    SolarSystem = location.Clone() as EveJimaUniverse.System;

                    if (SolarSystem != null)
                    {
                        SolarSystem.Id = Global.Space.GetSystemByName(solarSystemName.ToUpper()).Id;
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

                    SolarSystem.Id = Global.Space.GetSystemByName(solarSystemName.ToUpper()).Id;

                    SolarSystem.Name = solarSystemName;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlSolarSystemOffline.LoadLocationInfo] Critical error. Exception {0}", ex);

                if (SolarSystem != null)
                {
                    SolarSystem.Name = "unknown";
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
            Global.InternalBrowser.OnBrowserNavigate("https://docs.google.com/spreadsheets/d/17cNu8hxqJKqkkPnhDlIuJY-IT6ps7kTNCd3BEz0Bvqs/pubhtml#");
        }

        private void Event_PastaShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystem.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://wh.pasta.gg/" + txtSolarSystem.Text.Trim() + "");
        }

    }
}
