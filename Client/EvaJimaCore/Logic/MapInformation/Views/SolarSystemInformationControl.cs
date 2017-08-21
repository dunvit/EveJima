using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation.Views;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.Logic.MapInformation
{
    public partial class SolarSystemInformationControl : UserControl, IMapInformationControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public event Action<string> CentreScreenSelectedSystem;

        public event Action<string> CentreScreenLocationSystem;

        public event Action<string> DeleteSelectedSystem;

        public event Action<string> DeathNotice;

        public SolarSystemInformationControl()
        {
            InitializeComponent();
        }

        public void ForceRefresh(Map spaceMap)
        {
            if(spaceMap != null) FillInformationForCurrentSolarSystems(spaceMap.GetSystem(spaceMap.SelectedSolarSystemName));
        }

        private void FillInformationForCurrentSolarSystems(EveJimaUniverse.System solarSystem)
        {
            if(solarSystem == null) return;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FillInformationForCurrentSolarSystems(solarSystem)));
                return;
            }

            try
            {
                txtSolarSystemName.Text = solarSystem.Name;

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

                txtSolarSystemStaticI.Visible = false;
                txtSolarSystemStaticII.Visible = false;

                label1.Visible = false;

                txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem(solarSystem.Security.ToString());

                if (string.IsNullOrEmpty(solarSystem.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[solarSystem.Static.Trim()];

                    txtSolarSystemStaticI.Text = wormholeI.Name + " " + wormholeI.LeadsTo;
                    txtSolarSystemStaticI.Visible = true;
                    txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);

                    //toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass + "\r\nMax Life time =" + wormholeI.Lifetime);
                }

                if (string.IsNullOrEmpty(solarSystem.Static2) == false)
                {
                    label1.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[solarSystem.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);

                    //toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass + "\r\nMax Life time =" + wormholeII.Lifetime);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SolarSystemInformationControl.FillInformationForCurrentSolarSystems] Critical error. Exception {0}", ex);
            }
        }

        private void SolarSystemInformationControl_Load(object sender, System.EventArgs e)
        {

        }

        private void cmdZkillboard_Click(object sender, EventArgs e)
        {
            Global.InternalBrowser.OnBrowserNavigate(("https://zkillboard.com/system/" + Global.Space.GetSystemByName(Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName.ToUpper()).Id + "/"));
        }

        private void cmdEllatha_Click(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName != "unknown")
            {
                if (Global.Pilots.Selected.Location.Name.Contains("J") == false)
                {
                    MessageBox.Show(@"Ellatha only for W-Space systems");
                    return;
                }

                Global.InternalBrowser.OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName.Replace("J", "") + "");
            }
        }

        private void cmdDotlan_Click(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName != "unknown")
                Global.InternalBrowser.OnBrowserNavigate("http://evemaps.dotlan.net/system/" + Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName + "");
        }

        private void cmdSuperpute_Click(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName != "unknown")
                Global.InternalBrowser.OnBrowserNavigate("http://superpute.com/system/" + Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName + "");
        }

        private void cmdPasta_Click(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName != "unknown")
                Global.InternalBrowser.OnBrowserNavigate("http://wh.pasta.gg/" + Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName + "");
        }

        private void cmdTripwire_Click(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName != "unknown")
                Global.InternalBrowser.OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName + "");
        }

        private void Event_CentreSelectedSystem(object sender, EventArgs e)
        {
            CentreScreenSelectedSystem(null);
        }

        private void Event_CentreLocationSystem(object sender, EventArgs e)
        {
            CentreScreenLocationSystem(null);
        }

        private void Event_DeleteSelectedSystem(object sender, EventArgs e)
        {
            DeleteSelectedSystem(Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName);
        }

        private void Click_SendDeathNotice(object sender, EventArgs e)
        {
            DeathNotice(Global.Pilots.Selected.SpaceMap.LocationSolarSystemName);
        }
    }
}
