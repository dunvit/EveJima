using System;
using System.Windows.Forms;
using EvaJimaCore;
using EvaJimaCore.UiTools;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlSolarSystem : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlSolarSystem));

        public StarSystemEntity SolarSystem { get; set; }

        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();

        private DelegateShowTravelHistory _showTravelHistory;
        private DelegateChangeSolarSystemInfo _changeSolarSystemInfo;

        public whlSolarSystem(DelegateShowTravelHistory showTravelHistory, DelegateChangeSolarSystemInfo changeSolarSystemInfo)
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

            _showTravelHistory = showTravelHistory;
            _changeSolarSystemInfo = changeSolarSystemInfo;
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

                toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass);

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

                toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass);

                title = title + " " + wormholeII.Name + "[" + wormholeII.LeadsTo + "]";
            }

            if (_changeSolarSystemInfo == null) return;

            try
            {
                _changeSolarSystemInfo(title);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlSolarSystem.RefreshSolarSystem] Critical error = {0}", ex);
            }
        }

        private void Event_ShowZkillboard(object sender, EventArgs e)
        {
            if (SolarSystem != null && SolarSystem.System != "unknown")
                Global.InternalBrowser.Browser.BrowserUrlExecute("https://zkillboard.com/system/" + Global.Pilots.Selected.Location.Id.Replace("J", "") + "/");
        }

        private void Event_ShowSuperpute(object sender, EventArgs e)
        {
            if (SolarSystem != null && SolarSystem.System != "unknown")
                Global.InternalBrowser.Browser.BrowserUrlExecute("http://superpute.com/system/" + Global.Pilots.Selected.Location.System + "");
        }

        private void Event_ShowEllatha(object sender, EventArgs e)
        {
            if (SolarSystem != null && SolarSystem.System != "unknown")
            {
                if (Global.Pilots.Selected.Location.System.Contains("J") == false)
                {
                    MessageBox.Show(@"Ellatha only for W-Space systems");
                    return;
                }

                Global.InternalBrowser.Browser.BrowserUrlExecute("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + Global.Pilots.Selected.Location.System.Replace("J", "") + "");
            }
        }

        private void Event_ShowDotlan(object sender, EventArgs e)
        {
            if (SolarSystem != null && SolarSystem.System != "unknown")
                Global.InternalBrowser.Browser.BrowserUrlExecute("http://evemaps.dotlan.net/system/" + Global.Pilots.Selected.Location.System + "");
        }

        private void Event_TripwireShow(object sender, EventArgs e)
        {
            if (SolarSystem != null && SolarSystem.System != "unknown")
                Global.InternalBrowser.Browser.BrowserUrlExecute("https://tripwire.eve-apps.com/?system=" + SolarSystem.System + "");
        }

        private void Event_ShowTravelHistory(object sender, EventArgs e)
        {
            _showTravelHistory();
        }
    }
}
