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

            groupBox2.Text = Global.Messages.Get("Tab_Map_SettingsLabel");
            lnlSystemText.Text = Global.Messages.Get("Tab_Map_MapOwner") + @":";
            label4.Text = Global.Messages.Get("Tab_Map_Map_Key") + @":";
            label5.Text = Global.Messages.Get("Tab_Map_SaveLowSec") + @":";
            label1.Text = Global.Messages.Get("Tab_Map_IsMemberCanDeleteSystem") + @":";
            
            label2.Text = Global.Messages.Get("Tab_Map_ServerAddress") + @":";

            cmdReload.Text = Global.Messages.Get("Tab_Map_Reload") + @":";
            cmdUpdateMapSettings.Text = Global.Messages.Get("Tab_Map_UpdateAll") + @":";

        }

        public void ForceRefresh(Map spaceMap)
        {
            Log.DebugFormat("[InformationMapSettingsView.ForceRefresh] start");
            txtKey.Text = spaceMap.Key;
            txtOwner.Text = spaceMap.GetOwner();
            txtServerAddress.Text = Global.ApplicationSettings.Server_MapAddress;
            Log.DebugFormat("[InformationMapSettingsView.ForceRefresh] end");
        }

        private void cmdUpdateMapSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                MessageBox.Show(Global.Messages.Get("Tab_Map_MessageFillMapKey"));
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
