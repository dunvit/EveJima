using EvaJimaCore;

namespace EveJimaCore.WhlControls
{
    public partial class ControlSettings : BaseContainer
    {
        public ControlSettings()
        {
            InitializeComponent();

            label_EveJimaVersion.Text = Localization.Messages.Get("Tab_Settings_EveJimaVersion");
            label_Author.Text = Localization.Messages.Get("Tab_Settings_Author");
            label_UseBrowser.Text = Localization.Messages.Get("Tab_Settings_UseBrowser");
            label_UseWormholesMap.Text = Localization.Messages.Get("Tab_Settings_UseWormholesMap");
            label_ShortSignatureRebuild.Text = Localization.Messages.Get("Tab_Settings_ShortSignatureRebuild");
            label_NeedRestart_1.Text = Localization.Messages.Get("Tab_Settings_NeedRestart");
            label_NeedRestart_2.Text = Localization.Messages.Get("Tab_Settings_NeedRestart");
            label_NeedRestart_3.Text = Localization.Messages.Get("Tab_Settings_NeedRestart");
            label_NeedRestart_4.Text = Localization.Messages.Get("Tab_Settings_NeedRestart");
            label_SaveSettings.Value = Localization.Messages.Get("Tab_Settings_SaveSettings");
            label_UseWhiteColorForSystems.Text = Localization.Messages.Get("Tab_Settings_UseWhiteColorForSystems");

            labelInterceptLinksFromEve.Text = Localization.Messages.Get("Tab_Settings_Intercept_links_from_EVE") + @":";

            label_Language.Text = Localization.Messages.Get("Tab_Settings_Language");

            label_IsOpenZkillboardInNewTab.Text = Localization.Messages.Get("Tab_Settings_IsOpenZkillboardInNewTab");

            cmdLanguage.Items.Add(new ComboboxItem { Text = "English", Value = 0 });
            cmdLanguage.Items.Add(new ComboboxItem { Text = "Russian", Value = 1 });



            if(Global.ApplicationSettings != null)
            {
                cmdLanguage.SelectedIndex = Global.ApplicationSettings.LanguageId;

                crlIsUseMap.Checked = Global.ApplicationSettings.IsUseMap;
            }
            else
            {
                cmdLanguage.SelectedIndex = 1;
            }
        }

        public override void ActivateContainer()
        {
            if (Global.ApplicationSettings != null)
                SetValues(Global.ApplicationSettings);
        }

        private void SetValues(ApplicationSettings applicationSettings)
        {
            crlIsUseMap.Checked = applicationSettings.IsUseMap;
            crlIsUseBrowser.Checked = applicationSettings.IsUseBrowser;
            crlIsSignatureRebuild.Checked = applicationSettings.IsSignatureRebuildEnabled;
            crlIsInterceptLinksFromEVE.Checked = applicationSettings.IsInterceptLinksFromEVE;
            chkIsOpenNewTabForZkillboard.Checked = applicationSettings.Browser_IsOpenKillboardInNewTab;
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

            if (Global.ApplicationSettings.Browser_IsOpenKillboardInNewTab != chkIsOpenNewTabForZkillboard.Checked)
            {
                Global.ApplicationSettings.Browser_IsOpenKillboardInNewTab = chkIsOpenNewTabForZkillboard.Checked;
                isNeedCloseApplication = true;
            }


            if (crlIsInterceptLinksFromEVE.Checked != Global.ApplicationSettings.IsInterceptLinksFromEVE)
            {
                Global.ApplicationSettings.IsInterceptLinksFromEVE = crlIsInterceptLinksFromEVE.Checked;
                isNeedCloseApplication = true;
            }

            if (crlIsUseWhiteColorForSystems.Checked != Global.ApplicationSettings.IsUseWhiteColorForSystems)
            {
                Global.ApplicationSettings.IsUseWhiteColorForSystems = crlIsUseWhiteColorForSystems.Checked;
            }

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
            if (Global.ApplicationSettings != null)
                label7.Text = Global.ApplicationSettings.CurrentVersion;
        }

        private void cmdEditSignaturesPattern_Click(object sender, System.EventArgs e)
        {
            Global.Presenter.ChangeScreen("Pattern");
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
