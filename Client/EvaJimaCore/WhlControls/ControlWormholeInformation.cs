using EvaJimaCore;
using EveJimaCore.UiTools;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ControlWormholeInformation : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public ControlWormholeInformation()
        {
            InitializeComponent();

            if (IsDebug) return;

            label5.Text = Localization.Messages.Get("Tab_WormholeInfo_Name");
            label1.Text = Localization.Messages.Get("Tab_WormholeInfo_Type");
            label2.Text = Localization.Messages.Get("Tab_WormholeInfo_MaxStableTime");
            label3.Text = Localization.Messages.Get("Tab_WormholeInfo_MaxStableMass");
            label4.Text = Localization.Messages.Get("Tab_WormholeInfo_MaxMassRegeneration");
            label6.Text = Localization.Messages.Get("Tab_WormholeInfo_MaxJumpMass");
            label7.Text = Localization.Messages.Get("Tab_WormholeInfo_Class");
            
            foreach(var wormholeTypesKey in Global.Space.WormholeTypes.Keys)
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
