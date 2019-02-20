using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.Tools;
using EveJimaCore.UiTools;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ControlCurrentLocation : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        private readonly ToolTip _toolTipForStaticI = new ToolTip();
        private readonly ToolTip _toolTipForStaticII = new ToolTip();

        public ControlCurrentLocation()
        {
            InitializeComponent();

            if (IsDebug) return;

            Global.Presenter.OnEnterToSolarSystem += EventOnEnterToSolarSystem;

            lbl_Region.Text = Localization.Messages.Get("Tab_Information_Region", "Region") + @": ";
            lbl_Constellation.Text = Localization.Messages.Get("Tab_Information_Constellation", "Constellation") + @": ";
            lbl_Class.Text = Localization.Messages.Get("Tab_Information_Class", "Class") + @": ";
            lbl_Effect.Text = Localization.Messages.Get("Tab_Information_Effect", "Effect") + @": ";
            lbl_StaticI.Text = Localization.Messages.Get("Tab_Information_Static", "Static") + @": I";
            lbl_StaticII.Text = Localization.Messages.Get("Tab_Information_Static", "Static") + @": II";
        }

        private void EventOnEnterToSolarSystem(string solarSystemName)
        {
            FillInformationForCurrentSolarSystems(Global.Space.GetSystemByName(solarSystemName));
        }

        public void FillInformationForCurrentSolarSystems(EveJimaUniverse.System solarSystem)
        {
            if (solarSystem == null) return;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FillInformationForCurrentSolarSystems(solarSystem)));
                return;
            }

            var maxStableMass = Localization.Messages.Get("Tab_Information_MaxStableMass", "Max stable mass");
            var maxJumpMass = Localization.Messages.Get("Tab_Information_MaxJumpMass", "Max jump mass");

            try
            {
                var planetraySystem = Global.PlanetarySystemsInfo.GetPlanetarySystemByName(solarSystem.Name);

                txtSolarSystemName.Text = solarSystem.Name;

                txtSolarSystemName.ForeColor = Common.GetColorBySolarSystem(solarSystem.Security.ToString());

                if(solarSystem.Security == SecurityStatus.WSpace)
                {
                    txtSolarSystemName.ForeColor = Common.GetColorBySolarSystem("C" + solarSystem.Class);
                }

                if(solarSystem.Class != null)
                {
                    lbl_Class.Text = Localization.Messages.Get("Tab_Information_Class") + @": " + solarSystem.Class;
                    lbl_Class.Visible = true;
                }
                else
                {
                    lbl_Class.Visible = false;
                }

                if (solarSystem.Effect != null)
                {
                    txtSolarSystemEffect.Text = solarSystem.Effect.Trim() == "" ? "None" : solarSystem.Effect.Trim();
                }
                else
                {
                    txtSolarSystemEffect.Text = "";
                }

                txtSolarSystemRegion.Text = planetraySystem.Region;
                txtSolarSystemConstellation.Text = planetraySystem.Constelation;


                txtSolarSystemStaticI.Text = "";
                txtSolarSystemStaticII.Text = "";

                txtSolarSystemStaticIData.Text = "";
                txtSolarSystemStaticIIData.Text = "";

                txtSolarSystemStaticI.Visible = false;
                txtSolarSystemStaticII.Visible = false;
                txtSolarSystemStaticIData.Visible = false;
                txtSolarSystemStaticIIData.Visible = false;

                lbl_StaticII.Visible = false;

                //txtSolarSystemName.ForeColor = Common.GetColorBySolarSystem(solarSystem.Security.ToString());

                if (string.IsNullOrEmpty(solarSystem.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[solarSystem.Static.Trim()];

                    txtSolarSystemStaticI.Text = wormholeI.Name + " " + wormholeI.LeadsTo;
                    txtSolarSystemStaticI.Visible = true;
                    txtSolarSystemStaticI.ForeColor = Common.GetColorBySolarSystem(wormholeI.LeadsTo);

                    txtSolarSystemStaticIData.Text = wormholeI.LeadsTo;
                    txtSolarSystemStaticIData.Visible = true;

                    _toolTipForStaticI.SetToolTip(txtSolarSystemStaticI, maxStableMass + "=" + wormholeI.TotalMass + "\r\n" + maxJumpMass + "=" + wormholeI.SingleMass);
                }

                if (string.IsNullOrEmpty(solarSystem.Static2) == false)
                {
                    lbl_StaticII.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[solarSystem.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Common.GetColorBySolarSystem(wormholeII.LeadsTo);

                    txtSolarSystemStaticIIData.Text = wormholeII.LeadsTo;
                    txtSolarSystemStaticIIData.Visible = true;

                    _toolTipForStaticII.SetToolTip(txtSolarSystemStaticII, maxStableMass + "=" + wormholeII.TotalMass + "\r\n" + maxJumpMass + "=" + wormholeII.SingleMass);
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

            Global.InternalBrowser.Navigate("https://zkillboard.com/system/" + Global.Space.GetSystemByName(txtSolarSystemName.Text.Trim().ToUpper()).Id + "/");

        }

        private void Event_ShowSuperpute(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.Navigate("https://eve-wh.space/" + txtSolarSystemName.Text.Trim() + "");
        }

        private void Event_ShowEllatha(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            if (txtSolarSystemName.Text.Trim().Contains("J") == false)
            {
                MessageBox.Show(Localization.Messages.Get("Tab_Information_EllathaWarning"));
                return;
            }

            Global.InternalBrowser.Navigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + txtSolarSystemName.Text.Trim().Replace("J", "") + "");

        }

        private void Event_ShowDotlan(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.Navigate("http://evemaps.dotlan.net/system/" + txtSolarSystemName.Text.Trim() + "");

        }

        private void Event_TripwireShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.Navigate("https://tripwire.eve-apps.com/?system=" + txtSolarSystemName.Text + "");

        }

        private void Event_PastaShow(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolarSystemName.Text)) return;

            Global.InternalBrowser.Navigate("http://wh.pasta.gg/" + txtSolarSystemName.Text.Trim() + "");

        }
    }
}
