using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EvaJimaCore;
using EveJimaCore;
using log4net;

namespace EveJima
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var log = LogManager.GetLogger(typeof(Program));

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log.Debug("----------------------------------------------------------------------------");
            log.Debug("[Program.Main] Start application EvaJima");

            Global.Initialization();

            if (GetConfigOptionalStringValue("BrowserType", "chromiumWebBrowser") == "chromiumWebBrowser")
            {
                var cache_dir = Application.StartupPath + "\\tmp";

                Directory.CreateDirectory(cache_dir);

                var settings = new CefSettings
                {
                    UserAgent = "pipiscrew_browser_v" + Cef.CefSharpVersion,
                    CachePath = cache_dir
                };

                //To persist session cookies (cookies without an expiry date or validity interval)
                settings.CefCommandLineArgs.Add("persist_session_cookies", "1");

                Cef.Initialize(settings);
            }
            else
            {
                InitializeBrowserEmulation();
            }

            try
            {
                Application.Run(new EveJimaWindow());
            }
            catch(Exception e)
            {
                log.Error("[Program.Main] Critical error: " + e);
            }
        }

        private static void InitializeBrowserEmulation()
        {
            if (!WebEmulator.IsBrowserEmulationSet())
            {
                WebEmulator.SetBrowserEmulationVersion();
            }
        }

        private static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings.Get(keyName);

            return defaultValue;
        }

    }
}
