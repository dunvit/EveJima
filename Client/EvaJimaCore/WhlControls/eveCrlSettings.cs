using System.Windows.Forms;
using EvaJimaCore;

namespace EveJimaCore.WhlControls
{
    public partial class EveCrlSettings : BaseContainer
    {
        public EveCrlSettings()
        {
            InitializeComponent();

        }

        public override void ActivateContainer()
        {
            SetValues(Global.ApplicationSettings);
        }

        private void SetValues(ApplicationSettings applicationSettings)
        {
            crlIsUseMap.Checked = applicationSettings.IsUseMap;
            crlIsUseBrowser.Checked = applicationSettings.IsUseBrowser;
            crlIsSignatureRebuild.Checked = applicationSettings.IsSignatureRebuildEnabled;
        }

        private void cmdSaveSettings_Click(object sender, System.EventArgs e)
        {
            var isNeedCloseApplication = false;

            if(crlIsUseMap.Checked != Global.ApplicationSettings.IsUseMap)
            {
                Global.ApplicationSettings.IsUseMap = crlIsUseMap.Checked;
                isNeedCloseApplication = true;
            }

            if(crlIsUseBrowser.Checked != Global.ApplicationSettings.IsUseBrowser)
            {
                Global.ApplicationSettings.IsUseBrowser = crlIsUseBrowser.Checked;
                isNeedCloseApplication = true;
            }

            Global.ApplicationSettings.IsSignatureRebuildEnabled = crlIsSignatureRebuild.Checked;

            if (isNeedCloseApplication)
            {
                Global.ApplicationSettings.Save();
                Global.Presenter.Close();
                return;
            }

            Global.ApplicationSettings.Save();
        }

        private void EveCrlSettings_Load(object sender, System.EventArgs e)
        {
            label7.Text = Global.ApplicationSettings.CurrentVersion;
        }
    }
}
