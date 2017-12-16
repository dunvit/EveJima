using EvaJimaCore;

namespace EveJimaCore.WhlControls
{
    public partial class EveCrlSettings : BaseContainer
    {
        public EveCrlSettings()
        {
            InitializeComponent();

            label4.Text = Global.Messages.Get("Tab_Settings_EveJimaVersion");
            label6.Text = Global.Messages.Get("Tab_Settings_Author");
            label5.Text = Global.Messages.Get("Tab_Settings_UseBrowser");
            label3.Text = Global.Messages.Get("Tab_Settings_UseWormholesMap");
            cmdIsSignatureRebuild.Text = Global.Messages.Get("Tab_Settings_ShortSignatureRebuild");
            label1.Text = Global.Messages.Get("Tab_Settings_NeedRestart");
            label2.Text = Global.Messages.Get("Tab_Settings_NeedRestart");
            cmdSaveSettings.Value = Global.Messages.Get("Tab_Settings_SaveSettings");

            lblLanguage.Text = Global.Messages.Get("Tab_Settings_Language");


            cmdLanguage.Items.Add(new ComboboxItem { Text = "English", Value = 0 });
            cmdLanguage.Items.Add(new ComboboxItem { Text = "Russian", Value = 1 });

            cmdLanguage.SelectedIndex = Global.ApplicationSettings.LanguageId;
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

            if (cmdLanguage.SelectedIndex != Global.ApplicationSettings.LanguageId)
            {
                Global.ApplicationSettings.LanguageId = cmdLanguage.SelectedIndex;
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

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
