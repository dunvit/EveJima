using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.UiTools;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ControlGetNewVersion : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ControlGetNewVersion));

        public ControlGetNewVersion()
        {
            InitializeComponent();

            if (IsDebug) return;

            var address = @"http://evejima.mikotaj.com/versions/Release_" + Global.ApplicationSettings.Version +  @".html";

            AddTab(address);

            Activate();
        }

        private void Activate()
        {
            try
            {
                if (IsDebug) return;

                cmdPasteCosmicSifnatures.Value = @"Update from version " + Global.ApplicationSettings.CurrentVersion + " to " + Global.ApplicationSettings.Version;
                cmdPasteCosmicSifnatures.Refresh();

                cmdPasteCosmicSifnatures.Visible = true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlVersion.Activate] Critical error. Exception {0}", ex);
            }
       }

        private void AddTab(string url)
        {
            try
            {
                browserTabControl.SuspendLayout();

                var browser = new WebBrowser { Dock = DockStyle.Fill };

                var tabPage = new TabPage(url)
                {
                    Dock = DockStyle.Fill
                };

                //browser.Navigate(url);

                var serviceRequest = new WebClient();
                var response = serviceRequest.DownloadString(new Uri(url));

                browser.DocumentText = response;

                browser.Tag = tabPage;

                browserTabControl.Controls.Add(browser);

                browserTabControl.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlVersion.AddTab] Critical error. Exception {0}", ex);
            }
        }

        public void DisposeBrowser()
        {
            try
            {
                browserTabControl.Dispose();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlVersion.DisposeBrowser] Critical error. Exception {0}", ex);
            }
        }

        private void Event_StartUpdateVersion(object sender, EventArgs e)
        {
            try
            {
                Log.Debug("[whlVersion.Event_StartUpdateVersion] Start update");

                //Global.ApplicationSettings.Server_update_content_version = Global.ApplicationSettings.Server_update_uri_version.Replace("Version.txt", "" + Global.Settings.CurrentVersion + "/VersionContent.txt");
                //Global.ApplicationSettings.Save();

                try
                {
                    try
                    {
                        Process.Start("https://github.com/dunvit/EveJima/releases/tag/" + Global.ApplicationSettings.Version);
                        //Process.Start(@"updater.exe");
                    }
                    catch (Exception ex2)
                    {
                        Log.ErrorFormat("[whlVersion.Event_StartUpdateVersion] Critical error. Exception {0}", ex2);
                    }
                }
                catch (Exception ex1)
                {
                    Log.ErrorFormat("[whlVersion.Event_StartUpdateVersion] Critical error. Exception {0}", ex1);
                }

                Global.Presenter.Close();

                Application.Exit();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlVersion.Event_StartUpdateVersion] Critical error. Exception {0}", ex);
            }
        }
    }
}
