using System;
using System.Windows.Forms;
using EveJimaCore.BLL.Map;

namespace EveJimaCore.WhlControls
{
    public partial class windowMapSettings : Form
    {
        public Map SpaceMap { get; set; }

        public windowMapSettings(Map SpaceMap = null)
        {
            InitializeComponent();

            this.SpaceMap = SpaceMap;
        }

        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void windowMapSettings_Load(object sender, EventArgs e)
        {
            if(SpaceMap == null)
            {
                cmdSave.Text = "Create new Map";
            }
            else
            {
                cmdSave.Text = "Save Map";
                txtMapKey.Text = SpaceMap.Key;
            }
        }
    }
}
