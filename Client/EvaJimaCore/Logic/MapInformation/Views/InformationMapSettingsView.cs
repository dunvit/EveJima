using System;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation.Views;
using log4net;

namespace EveJimaCore.Logic.MapInformation
{
    public partial class InformationMapSettingsView : UserControl, IMapInformationControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InformationMapSettingsView));
        public event Action<string> ChangeMapKey;
        public event Action<string> ReloadMap;

        public InformationMapSettingsView()
        {
            InitializeComponent();
        }

        public void ForceRefresh(Map spaceMap)
        {
            Log.DebugFormat("[InformationMapSettingsView.ForceRefresh] start");
            txtKey.Text = spaceMap.Key;
            txtOwner.Text = spaceMap.GetOwner();
            txtServerAddress.Text = Global.ApplicationSettings.Server_MapAddress;
            Log.DebugFormat("[InformationMapSettingsView.ForceRefresh] end");
        }

        private void cmdUpdateMapSettings_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                MessageBox.Show(@"Please fill 'Map Key' field.");
                return;
            }

            if (ChangeMapKey != null) ChangeMapKey(txtKey.Text);
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            if(ReloadMap != null) ReloadMap(txtKey.Text);
        }
    }
}
