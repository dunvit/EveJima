using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.Tools;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class mapSolarSystemKSpace : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public mapSolarSystemKSpace()
        {
            InitializeComponent();
        }

        public void RefreshSolarSystem(EveJimaUniverse.System location)
        {
            if (location == null) return;

            try
            {
                txtSolarSystemName.Text = location.Name;
                
                txtSolarSystemRegion.Text = location.Region.Replace(" Unknown (", "").Replace(")", "");

                txtSolarSystemName.ForeColor = Common.GetColorBySolarSystem(location.Security.ToString());
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[mapSolarSystemKSpace.RefreshSolarSystem] Critical error. Exception {0}", ex);
            }
        }
    }
}
