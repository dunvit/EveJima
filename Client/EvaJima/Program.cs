using System;
using System.Configuration;
using System.Windows.Forms;
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
                //InitializeChromium(log);
            }
            else
            {
                InitializeBrowserEmulation();
            }

            try
            {
                Application.Run(new EveJimaCore.MainEveJima());
            }
            catch(Exception e)
            {
                Global.LinkInterceptor.StopIntercepting();

                log.Error("[Program.Main] Critical error: " + e);
            }

            Global.LinkInterceptor.StopIntercepting();
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
