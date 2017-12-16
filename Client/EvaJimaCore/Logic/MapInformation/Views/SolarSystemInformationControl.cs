using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation.Views;
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

            groupBox2.Text = Global.Messages.Get("Tab_Map_SolarSystemInformation");

            lnlSystemText.Text = Global.Messages.Get("Tab_Information_SolarSystem") + @": ";
            label4.Text = Global.Messages.Get("Tab_Information_Region") + @": ";
            label5.Text = Global.Messages.Get("Tab_Information_Class") + @": ";
            label6.Text = Global.Messages.Get("Tab_Information_Effect") + @": ";
            label7.Text = Global.Messages.Get("Tab_Information_Static") + @": I";
            label1.Text = Global.Messages.Get("Tab_Information_Static") + @": II";

            groupBox1.Text = Global.Messages.Get("Tab_Map_Commands");

            ejButton3.Text = Global.Messages.Get("Tab_Map_CentreLocationSystem");
            cmdMapSignatures.Text = Global.Messages.Get("Tab_Map_CentreSelectedSystem");
            cmdDeathNotice.Text = Global.Messages.Get("Tab_Map_DeathNotice");

            groupBox3.Text = Global.Messages.Get("Tab_Map_InternalResourses");

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
                }

                if (string.IsNullOrEmpty(solarSystem.Static2) == false)
                {
                    label1.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[solarSystem.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SolarSystemInformationControl.FillInformationForCurrentSolarSystems] Critical error. Exception {0}", ex);
            }
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
                    MessageBox.Show(Global.Messages.Get("Tab_Information_EllathaWarning"));
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

        private void Click_SendDeathNotice(object sender, EventArgs e)
        {
            DeathNotice(Global.Pilots.Selected.SpaceMap.LocationSolarSystemName);
        }
    }
}
