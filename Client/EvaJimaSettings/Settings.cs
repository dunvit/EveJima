using System;
using System.IO;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaSettings
{
    public class Settings
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Settings));

        public bool IsLoadedSuccessfully = true;

        public string Version = "1.26";
        public string CurrentVersion = "1.26";
        public bool IsAuthorizationEnabled = true;

        public string CCPSSO_AUTH_CLIENT_ID = "";
        public string CCPSSO_AUTH_CLIENT_SECRET = "";
        public string CCPSSO_AUTH_CLIENT_STATE = "";
        public string CCPSSO_AUTH_PORT = "";
        public string CCPSSO_AUTH_SCOPES = "";

        public string Server_update_uri_version = "";
        public string Server_update_content_version = "";

        public string Client_execution_file = "";

        

        public Settings()
        {
            Log.Debug("[Settings.LoadSettings] Start load settings");

            try
            {
                using (var reader = new StreamReader("settings.txt"))
                {
                    dynamic data = JObject.Parse(reader.ReadToEnd());

                    CCPSSO_AUTH_CLIENT_ID           = data.CCPSSO_AUTH_CLIENT_ID;
                    CCPSSO_AUTH_CLIENT_SECRET       = data.CCPSSO_AUTH_CLIENT_SECRET;
                    CCPSSO_AUTH_CLIENT_STATE        = data.CCPSSO_AUTH_CLIENT_STATE;
                    CCPSSO_AUTH_PORT                = data.CCPSSO_AUTH_PORT;
                    CCPSSO_AUTH_SCOPES              = data.CCPSSO_AUTH_SCOPES;
                    Server_update_uri_version       = data.Server_update_uri_version;
                    Server_update_content_version   = data.Server_update_content_version;
                    Client_execution_file           = data.Client_execution_file;
                }

                CurrentVersion = File.ReadAllText(@"Version.txt");

                Log.DebugFormat("[Settings.LoadSettings] Read version. Current version is {0}", CurrentVersion);

                using (var wc = new System.Net.WebClient())
                    Version = wc.DownloadString(Server_update_uri_version);

                Log.DebugFormat("[Settings.LoadSettings] Read version. Last version is {0}", Version);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[Settings.LoadSettings] Critical error. Exception {0}", ex);
                IsLoadedSuccessfully = false;
            }
            
        }


    }
}
