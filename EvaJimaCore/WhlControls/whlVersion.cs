using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EvaJimaCore;
using CefSharp.WinForms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlVersion : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlVersion));


        public whlVersion()
        {
            InitializeComponent();

            AddTab("https://github.com/dunvit/EveJima/releases");

            Activate();
        }

        private void Activate()
        {
            try
            {
                if (Global.Settings.Version.Trim() != Global.Settings.CurrentVersion.Trim())
                {
                    cmdPasteCosmicSifnatures.Value = @"Update from version " + Global.Settings.CurrentVersion.Trim() + " to " + Global.Settings.Version;
                    cmdPasteCosmicSifnatures.Refresh();

                    cmdPasteCosmicSifnatures.Visible = true;
                }
                else
                {
                    cmdPasteCosmicSifnatures.Visible = false;
                }
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

                var browser = new ChromiumWebBrowser(url);

                // Add it to the form and fill it to the form window.
                browser.Dock = DockStyle.Fill;

                var tabPage = new TabPage(url)
                {
                    Dock = DockStyle.Fill
                };

                //This call isn't required for the sample to work. 
                //It's sole purpose is to demonstrate that #553 has been resolved.
                browser.CreateControl();

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

                string text = File.ReadAllText("settings.txt");
                text = text.Replace("VersionContent.txt", "VersionContent_" + Global.Settings.CurrentVersion.Replace(".","") + ".txt");
                File.WriteAllText("settings.txt", text);

                try
                {
                    //ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.CreateNoWindow = false;
                    //startInfo.UseShellExecute = false;
                    //startInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "updater.exe";
                    try
                    {
                        Process.Start(@"updater.exe");
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

                Application.Exit();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlVersion.Event_StartUpdateVersion] Critical error. Exception {0}", ex);
            }

            
        }
    }
}
