using EvaJimaCore;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class eveCrlWormholeInformation : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public eveCrlWormholeInformation()
        {
            InitializeComponent();

            label5.Text = Global.Messages.Get("Tab_WormholeInfo_Name");
            label1.Text = Global.Messages.Get("Tab_WormholeInfo_Type");
            label2.Text = Global.Messages.Get("Tab_WormholeInfo_MaxStableTime");
            label3.Text = Global.Messages.Get("Tab_WormholeInfo_MaxStableMass");
            label4.Text = Global.Messages.Get("Tab_WormholeInfo_MaxMassRegeneration");
            label6.Text = Global.Messages.Get("Tab_WormholeInfo_MaxJumpMass");
            label7.Text = Global.Messages.Get("Tab_WormholeInfo_Class");

            foreach (var wormholeTypesKey in Global.Space.WormholeTypes.Keys)
            {
                cmbWormholeClasses.Items.Add(new ComboboxItem { Text = wormholeTypesKey, Value = wormholeTypesKey });
            }
        }

        private void cmbWormholeClasses_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var wormholeType = cmbWormholeClasses.Text;

            var wormholeInfo = Global.Space.WormholeTypes[wormholeType];


            txtName.Text = wormholeInfo.Name;
            label8.Text = wormholeInfo.Classification;
            label9.Text = "Leads into " + wormholeInfo.LeadsTo + " system";
            label10.Text = wormholeInfo.Lifetime;
            label11.Text = wormholeInfo.TotalMass;
            label12.Text = wormholeInfo.Regen;
            label13.Text = wormholeInfo.SingleMass;

        }
    }
}
