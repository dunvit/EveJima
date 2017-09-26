using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class EveCrlLocation : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();

        public EveCrlLocation()
        {
            InitializeComponent();

            Global.Presenter.OnEnterToSolarSystem += EventOnEnterToSolarSystem;
        }

        private void EventOnEnterToSolarSystem(string solarSystemName)
        {
            FillInformationForCurrentSolarSystems(Global.Space.GetSystemByName(solarSystemName));
        }

        private void EventOnLocationChange(Map map)
        {
            FillInformationForCurrentSolarSystems(Global.Space.GetSystemByName(map.LocationSolarSystemName));
        }

        public void FillInformationForCurrentSolarSystems(EveJimaUniverse.System solarSystem)
        {
            if (solarSystem == null) return;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FillInformationForCurrentSolarSystems(solarSystem)));
                return;
            }

            try
            {
                txtSolarSystemName.Text = solarSystem.Name;

                txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem(solarSystem.Security.ToString());

                if(solarSystem.Security == SecurityStatus.WSpace)
                {
                    txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem("C" + solarSystem.Class);
                }

                txtSolarSystemClass.Text = solarSystem.Class;

                if (solarSystem.Effect != null)
                {
                    txtSolarSystemEffect.Text = solarSystem.Effect.Trim() == "" ? "None" : solarSystem.Effect.Trim();
                }
                else
                {
                    txtSolarSystemEffect.Text = "";
                }

                if (solarSystem.Region != null)
                {
                    txtSolarSystemRegion.Text = solarSystem.Region.Replace(" Unknown (", "").Replace(")", "");
                }
                else
                {
                    txtSolarSystemRegion.Text = "";
                }


                txtSolarSystemStaticI.Text = "";
                txtSolarSystemStaticII.Text = "";

                txtSolarSystemStaticIData.Text = "";
                txtSolarSystemStaticIIData.Text = "";

                txtSolarSystemStaticI.Visible = false;
                txtSolarSystemStaticII.Visible = false;
                txtSolarSystemStaticIData.Visible = false;
                txtSolarSystemStaticIIData.Visible = false;

                label1.Visible = false;

                //txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem(solarSystem.Security.ToString());

                if (string.IsNullOrEmpty(solarSystem.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[solarSystem.Static.Trim()];

                    txtSolarSystemStaticI.Text = wormholeI.Name + " " + wormholeI.LeadsTo;
                    txtSolarSystemStaticI.Visible = true;
                    txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);

                    txtSolarSystemStaticIData.Text = wormholeI.LeadsTo;
                    txtSolarSystemStaticIData.Visible = true;

                    toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass + "\r\nMax Life time =" + wormholeI.Lifetime);
                }

                if (string.IsNullOrEmpty(solarSystem.Static2) == false)
                {
                    label1.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[solarSystem.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);

                    txtSolarSystemStaticIIData.Text = wormholeII.LeadsTo;
                    txtSolarSystemStaticIIData.Visible = true;

                    toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass + "\r\nMax Life time =" + wormholeII.Lifetime);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SolarSystemInformationControl.FillInformationForCurrentSolarSystems] Critical error. Exception {0}", ex);
            }
        }

        private void Event_ShowZkillboard(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("https://zkillboard.com/system/" + Global.Space.GetSystemByName(txtSolarSystemName.Text.Trim().ToUpper()).Id + "/");

        }

        private void Event_ShowSuperpute(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://superpute.com/system/" + txtSolarSystemName.Text.Trim() + "");
        }

        private void Event_ShowEllatha(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            if (txtSolarSystemName.Text.Trim().Contains("J") == false)
            {
                MessageBox.Show(@"Ellatha only for W-Space systems");
                return;
            }

            Global.InternalBrowser.OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + txtSolarSystemName.Text.Trim().Replace("J", "") + "");

        }

        private void Event_ShowDotlan(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://evemaps.dotlan.net/system/" + txtSolarSystemName.Text.Trim() + "");

        }

        private void Event_TripwireShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + txtSolarSystemName.Text + "");

        }

        private void Event_PastaShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.OnBrowserNavigate("http://wh.pasta.gg/" + txtSolarSystemName.Text.Trim() + "");

        }
    }
}
