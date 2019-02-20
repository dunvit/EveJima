using System;
using System.Configuration;

namespace EveJimaCore.Configuration
{
    public static class ConfigurationTools
    {
        public static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings[keyName];

            return defaultValue;
        }

        public static bool GetConfigOptionalBoolValue(string keyName, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return Convert.ToBoolean(ConfigurationManager.AppSettings[keyName]);

            return defaultValue;
        }
    }
}
