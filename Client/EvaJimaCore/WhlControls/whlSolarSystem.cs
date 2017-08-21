using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlSolarSystem : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlSolarSystem));

        public DelegateShowLostAndFoundOffice OnShowLostAndFoundOffice;
        public DelegateShowTravelHistory OnShowTravelHistory;
        public DelegateChangeSolarSystemInfo OnChangeSolarSystemInfo;
        public DelegateContainerActivate OnContainerActivate;

        public BrowserNavigate OnBrowserNavigate;

        public EveJimaUniverse.System SolarSystem { get; set; }

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

        public void RefreshSolarSystem(EveJimaUniverse.System location)
        {
            if (location == null) return;

            try
            {
                Log.DebugFormat("[whlSolarSystem.RefreshSolarSystem] start");
                SolarSystem = location.Clone() as EveJimaUniverse.System;

                if (Global.Pilots.Selected.Location.Name == "unknown") return;

                txtSolarSystemName.Text = Global.Pilots.Selected.Location.Name;

                txtSolarSystemStaticI.Text = "";
                txtSolarSystemStaticII.Text = "";

                txtSolarSystemStaticIData.Text = "";
                txtSolarSystemStaticIIData.Text = "";

                txtSolarSystemStaticI.Visible = false;
                txtSolarSystemStaticII.Visible = false;
                txtSolarSystemStaticIData.Visible = false;
                txtSolarSystemStaticIIData.Visible = false;

                if (Tools.IsWSpaceSystem(Global.Pilots.Selected.Location.Name) == false) return;
                
                txtSolarSystemClass.Text = Global.Pilots.Selected.Location.Class;
                txtSolarSystemEffect.Text = Global.Pilots.Selected.Location.Effect.Trim();
                txtSolarSystemRegion.Text = Global.Pilots.Selected.Location.Region.Replace(" Unknown (", "").Replace(")", "");
                txtSolarSystemConstellation.Text = Global.Pilots.Selected.Location.Constelation.Replace(" Unknown (", "").Replace(")", "");

                var title = Global.Pilots.Selected.Location.Name + "";

                if (string.IsNullOrEmpty(Global.Pilots.Selected.Location.Class) == false)
                {
                    title = title + "[C" + Global.Pilots.Selected.Location.Class + "]";
                }

                if (string.IsNullOrEmpty(Global.Pilots.Selected.Location.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[Global.Pilots.Selected.Location.Static.Trim()];

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
                    var wormholeII = Global.Space.WormholeTypes[Global.Pilots.Selected.Location.Static2.Trim()];


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
            catch (Exception)
            {
                
                //throw;
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
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                        OnBrowserNavigate("https://zkillboard.com/system/" + Global.Pilots.Selected.Location.Id.Replace("J", "") + "/");
                    break;
                case "Superpute":
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                        OnBrowserNavigate("http://superpute.com/system/" + Global.Pilots.Selected.Location.Name + "");
                    break;
                case "Ellatha":
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                    {
                        if (Global.Pilots.Selected.Location.Name.Contains("J") == false)
                        {
                            MessageBox.Show(@"Ellatha only for W-Space systems");
                            return;
                        }

                        OnBrowserNavigate("http://www.ellatha.com/eve/WormholeSystemview.asp?key=" + Global.Pilots.Selected.Location.Name.Replace("J", "") + "");
                    }
                    break;
                case "Dotlan":
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                        OnBrowserNavigate("http://evemaps.dotlan.net/system/" + Global.Pilots.Selected.Location.Name + "");
                    break;
                case "Tripwire":
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                        OnBrowserNavigate("https://tripwire.eve-apps.com/?system=" + SolarSystem.Name + "");
                    break;
                case "Pasta.gg":
                    if (SolarSystem != null && SolarSystem.Name != "unknown")
                        OnBrowserNavigate("http://wh.pasta.gg/" + SolarSystem.Name + "");
                    break;

            }
        }

        private void Event_SelectService(object sender, EventArgs e)
        {
            cmdShow.Value = cmbServices.Text + @" Show"; 
        }

        private void Event_ShowRouter(object sender, EventArgs e)
        {
            OnContainerActivate("Router");
        }

        private void cmdShow_Load(object sender, EventArgs e)
        {

        }
    }
}
