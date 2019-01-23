using EvaJimaCore;
using EveJimaCore.Monitoring;

namespace EveJimaCore.WhlControls
{
    public partial class ControlBookmarkPattern : BaseContainer
    {
        public ControlBookmarkPattern()
        {
            InitializeComponent();

            if (IsDebug) return;

            cmdReturn.Value = Localization.Messages.Get("Tab_BookmarkPattern_Return");
            cmdSaveChanges.Value = Localization.Messages.Get("Tab_BookmarkPattern_Save");

            lblRelicSites.Text = Localization.Messages.Get("Tab_BookmarkPattern_RelicSites");
            lblDataSites.Text = Localization.Messages.Get("Tab_BookmarkPattern_DataSites");
            lblGasSites.Text = Localization.Messages.Get("Tab_BookmarkPattern_GasSites");
            lblWormholeSites.Text = Localization.Messages.Get("Tab_BookmarkPattern_WormholeSites");
            lblDateTime.Text = Localization.Messages.Get("Tab_BookmarkPattern_DateTime");
            lblUser.Text = Localization.Messages.Get("Tab_BookmarkPattern_User");
            lblCodeLetters.Text = Localization.Messages.Get("Tab_BookmarkPattern_CodeLetters");
            lblCodeNumbers.Text = Localization.Messages.Get("Tab_BookmarkPattern_CodeNumbers");
            lblPreview.Text = Localization.Messages.Get("Tab_BookmarkPattern_Preview");
        }

        private void cmdReturn_Click(object sender, System.EventArgs e)
        {
            Global.Presenter.ChangeScreen("Settings");
        }

        public override void ActivateContainer()
        {
            txtBookmarkPattern.Text = Global.ApplicationSettings.SignatureRebuildPattern;
            txtRelicSites.Text = Global.ApplicationSettings.SignaturePatternRelic;
            txtDataSites.Text = Global.ApplicationSettings.SignaturePatternData;
            txtGasSites.Text = Global.ApplicationSettings.SignaturePatternGas;
            txtWormholeSites.Text = Global.ApplicationSettings.SignaturePatternWormhole;
        }

        private void cmdSaveChanges_Click(object sender, System.EventArgs e)
        {
            Global.ApplicationSettings.SignatureRebuildPattern = txtBookmarkPattern.Text;
            Global.ApplicationSettings.SignaturePatternRelic = txtRelicSites.Text;
            Global.ApplicationSettings.SignaturePatternData = txtDataSites.Text;
            Global.ApplicationSettings.SignaturePatternGas = txtGasSites.Text;
            Global.ApplicationSettings.SignaturePatternWormhole = txtWormholeSites.Text;

            Global.ApplicationSettings.Save();

            Global.Presenter.ChangeScreen("Settings");
        }

        private void cmdShowResult_Click(object sender, System.EventArgs e)
        {
            var applicationSettings = new ApplicationSettings
            {
                IsSignatureRebuildEnabled = false,
                SignatureRebuildPattern = txtBookmarkPattern.Text,
                SignaturePatternRelic = txtRelicSites.Text,
                SignaturePatternData = txtDataSites.Text,
                SignaturePatternGas = txtGasSites.Text,
                SignaturePatternWormhole = txtWormholeSites.Text
            };

            var bookmarks = new BookmarksMonitoring(applicationSettings);

            lblPreviewResult.Text = bookmarks.Execute(label1.Text);
        }
    }
}
