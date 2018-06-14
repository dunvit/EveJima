using System.Configuration;
using log4net;

namespace EveJimaIGB
{
    public class Config
    {
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);

        public string BrowserType { get; }

        public string EveOnlineTitle { get; }

        public Config()
        {
            BrowserType = GetConfigOptionalStringValue("BrowserType", "chromiumWebBrowser");

            EveOnlineTitle = GetConfigOptionalStringValue("EveOnlineTitle", "EVE - ");

            WriteConfigurationOnStart();
        }

        private void WriteConfigurationOnStart()
        {
            _logger.Info("[Config.WriteConfigurationOnStart] Read data from configuration file. " +
                         " \r\n--------------------------------------------------------------------------------------------" +
                         " \r\n BrowserType                       = " + BrowserType + " " +
                         " \r\n--------------------------------------------------------------------------------------------");
        }

        private string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings.Get(keyName);

            return defaultValue;
        }
    }
}
