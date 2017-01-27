using System;
using System.Diagnostics;
using System.Windows.Forms;
using EvaJimaCore;
//using CefSharp.WinForms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlVersion : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlVersion));

        public whlVersion()
        {
            InitializeComponent();

            //AddTab("https://github.com/dunvit/WHL/releases");

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
            //try
            //{
            //    browserTabControl.SuspendLayout();

            //    var browser = new ChromiumWebBrowser(url) { Dock = DockStyle.Fill };

            //    browser.CreateControl();

            //    browserTabControl.Controls.Add(browser);

            //    browserTabControl.ResumeLayout(true);
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat("[whlVersion.AddTab] Critical error. Exception {0}", ex);
            //}
        }

        private void Event_StartUpdateVersion(object sender, EventArgs e)
        {
            try
            {
                Log.Debug("[whlVersion.Event_StartUpdateVersion] Start update");

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
