using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class mapSolarSystemWSpace : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public mapSolarSystemWSpace()
        {
            InitializeComponent();
        }

        public void RefreshSolarSystem(EveJimaUniverse.System location)
        {
            if (location == null) return;

            try
            {
                txtSolarSystemName.Text = location.Name;
                txtSolarSystemClass.Text = location.Class;
                if(location.Effect != null)
                {
                    txtSolarSystemEffect.Text = location.Effect.Trim() == "" ? "None" : location.Effect.Trim();
                }
                else
                {
                    txtSolarSystemEffect.Text = "";
                }

                if (location.Region != null)
                {
                    txtSolarSystemRegion.Text = location.Region.Replace(" Unknown (", "").Replace(")", "");
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

                txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem(location.Security.ToString());

                if (string.IsNullOrEmpty(location.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[location.Static.Trim()];

                    txtSolarSystemStaticI.Text = wormholeI.Name + " " + wormholeI.LeadsTo;
                    txtSolarSystemStaticI.Visible = true;
                    txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);

                    //toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass + "\r\nMax Life time =" + wormholeI.Lifetime);
                }

                if (string.IsNullOrEmpty(location.Static2) == false)
                {
                    label1.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[location.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);

                    //toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass + "\r\nMax Life time =" + wormholeII.Lifetime);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[mapSolarSystemWSpace.RefreshSolarSystem] Critical error. Exception {0}", ex);
            }

        }
    }
}
