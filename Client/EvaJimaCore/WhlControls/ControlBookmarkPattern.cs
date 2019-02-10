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

            cmdExamples.Items.Add(new ComboboxItem { Text = "OKX-638	  Cosmic Signature	  Gas Site	  Token Perimeter Reservoir	  100.0%	  21.18 AU", Value = 1 });
            cmdExamples.Items.Add(new ComboboxItem { Text = "OKX-638	  Cosmic Signature	  Wormhole	  Unknown Wormhole	  100.0%	  21.18 AU", Value = 2 });

            cmdExamples.SelectedIndex = 1;
        }

        private void cmdReturn_Click(object sender, System.EventArgs e)
        {
            Global.Presenter.ChangeScreen("Settings");
        }

        public override void ActivateContainer()
        {
            txtRelicSites.Text = Global.ApplicationSettings.SignaturePatternRelic;
            txtDataSites.Text = Global.ApplicationSettings.SignaturePatternData;
            txtGasSites.Text = Global.ApplicationSettings.SignaturePatternGas;
            txtWormholeSites.Text = Global.ApplicationSettings.SignaturePatternWormhole;
            txtUnknown.Text = Global.ApplicationSettings.SignaturePatternUnknown;
        }

        private void cmdSaveChanges_Click(object sender, System.EventArgs e)
        {
            Global.ApplicationSettings.SignaturePatternRelic = txtRelicSites.Text;
            Global.ApplicationSettings.SignaturePatternData = txtDataSites.Text;
            Global.ApplicationSettings.SignaturePatternGas = txtGasSites.Text;
            Global.ApplicationSettings.SignaturePatternWormhole = txtWormholeSites.Text;
            Global.ApplicationSettings.SignaturePatternUnknown = txtUnknown.Text;

            Global.ApplicationSettings.Save();

            Global.Presenter.ChangeScreen("Settings");
        }

        private void cmdShowResult_Click(object sender, System.EventArgs e)
        {
            var applicationSettings = new ApplicationSettings
            {
                IsSignatureRebuildEnabled = false,
                SignaturePatternRelic = txtRelicSites.Text,
                SignaturePatternData = txtDataSites.Text,
                SignaturePatternGas = txtGasSites.Text,
                SignaturePatternWormhole = txtWormholeSites.Text,
                SignaturePatternUnknown = txtUnknown.Text
            };

            var bookmarks = new BookmarksMonitoring(applicationSettings);

            lblPreviewResult.Text = bookmarks.Execute(cmdExamples.SelectedItem.ToString());
        }

        private void cmdRestore_Click(object sender, System.EventArgs e)
        {
            txtRelicSites.Text = "Relic %ABC-%123 %NAME (%ET)";
            txtDataSites.Text = "Data %ABC-%123 %NAME (%ET)";
            txtGasSites.Text = "Gas %ABC-%123 %NAME (%ET)";
            txtWormholeSites.Text = "WH %ABC-%123 %NAME (%ET)";
            txtUnknown.Text = "Unknown %ABC-%123 %NAME (%ET)";
        }
    }
}
