using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using EvaJimaCore;
using log4net;

namespace EveJimaCore
{
    public class ApplicationSettings
    {
        readonly ILog _commandsLog = LogManager.GetLogger("Errors");

        public bool IsConverted { private set; get; }

        public string Version { set; get; }

        public string CurrentVersion { set; get; }

        public string Authorization_ClientId { set; get; }
        public string Authorization_ClientSecret { set; get; }
        public string Authorization_ClientState { set; get; }
        public string Authorization_Port { set; get; }
        public string Authorization_Scopes { set; get; }

        public string Server_update_uri_version { set; get; }
        public string Server_update_content_version { set; get; }

        public string Client_execution_file { set; get; }

        public bool Browser_IsShowFavorites { get; set; }

        public bool Browser_IsPinned { get; set; }

        public bool Browser_IsOpenKillboardInNewTab { get; set; }

        public int Browser_LocationMaximizeX { get; set; }
        public int Browser_LocationMaximizeY { get; set; }

        public string Server_MapAddress { get; set; }


        public List<Tuple<string, string, string, string>> Pilots { get; set; }


        public bool IsUseMap { get; set; }

        public bool IsUseBrowser { get; set; }

        public bool IsSignatureRebuildEnabled { get; set; }

        public bool IsNeedUpdateVersion { get; set; }

        public bool IsInterceptLinksFromEVE { get; set; }

        public int LanguageId { get; set; }

        public ApplicationSettings()
        {
            Pilots = new List<Tuple<string, string, string, string>>();

            Load();
        }

        public string GetPilotKey(string name)
        {
            foreach (var pilot in Pilots)
            {
                if (pilot.Item1 == name)
                {
                    return pilot.Item4;
                }
            }

            return "";
        }

        public void UpdatePilotInStorage(string name, string id, string token, string mapKey = "")
        {
            Tuple<string, string, string, string> removedPilot = null;
            Tuple<string, string, string, string> updatedPilot = new Tuple<string, string, string, string>(name, id, token, mapKey);

            foreach (var pilot in Pilots)
            {
                if(pilot.Item1 == name)
                {
                    removedPilot = pilot;
                }
            }

            if(removedPilot != null)
            {
                Pilots.Remove(removedPilot);
            }

            Pilots.Add(updatedPilot);

            Save();
        }

        private void Load()
        {
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EveJima", "Settings.dat");

                string settingsContent;

                if (File.Exists(path))
                {
                    settingsContent = File.ReadAllText(path);
                    IsConverted = true;

                    // Default value
                    CurrentVersion = "1.0.0";

                    dynamic jsonResponse = JsonConvert.DeserializeObject(settingsContent);

                    Authorization_ClientId = jsonResponse.Authorization_ClientId;
                    Authorization_ClientSecret = jsonResponse.Authorization_ClientSecret;
                    Authorization_ClientState = jsonResponse.Authorization_ClientState;
                    Authorization_Port = jsonResponse.Authorization_Port;
                    Authorization_Scopes = jsonResponse.Authorization_Scopes;
                    Server_update_uri_version = jsonResponse.Server_update_uri_version;
                    Server_update_content_version = jsonResponse.Server_update_content_version;
                    Client_execution_file = jsonResponse.Client_execution_file;
                    Browser_IsShowFavorites = jsonResponse.Browser_IsShowFavorites;
                    Browser_IsPinned = jsonResponse.Browser_IsPinned;
                    Browser_LocationMaximizeX = jsonResponse.Browser_LocationMaximizeX;
                    Browser_LocationMaximizeY = jsonResponse.Browser_LocationMaximizeY;

                    Browser_IsOpenKillboardInNewTab = jsonResponse.Browser_IsOpenKillboardInNewTab == null ? true : jsonResponse.Browser_IsOpenKillboardInNewTab;

                    Server_MapAddress = jsonResponse.Server_MapAddress;

                    IsUseBrowser = jsonResponse.IsUseBrowser == null ? true : jsonResponse.IsUseBrowser;
                    IsUseMap = jsonResponse.IsUseMap == null ? false : jsonResponse.IsUseMap;
                    IsSignatureRebuildEnabled = jsonResponse.IsSignatureRebuildEnabled == null ? true : jsonResponse.IsSignatureRebuildEnabled;

                    IsInterceptLinksFromEVE = jsonResponse.IsInterceptLinksFromEVE == null ? false : jsonResponse.IsInterceptLinksFromEVE;

                    LanguageId = jsonResponse.LanguageId == null ? 0 : jsonResponse.LanguageId;

                    var ccPilots = jsonResponse.Pilots;

                    foreach (var ccPilot in ccPilots)
                    {
                        Pilots.Add(new Tuple<string, string, string, string>(ccPilot.Item1.ToString(), ccPilot.Item2.ToString(), ccPilot.Item3.ToString(), ccPilot.Item4.ToString()));
                    }
                }
                else
                {
                    // Set default values for older program versions (without Settings.dat file)
                    Authorization_ClientId = "e136434f8a0c484ab802666f378cac09";
                    Authorization_ClientSecret = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";
                    Authorization_ClientState = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";
                    Authorization_Port = "8080";
                    Authorization_Scopes = "esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-bookmarks.read_character_bookmarks.v1 esi-fleets.read_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1";
                    Server_update_uri_version = @"http://evejima.mikotaj.com/Version.txt";
                    Server_update_content_version = @"http://evejima.mikotaj.com/VersionContent.txt";
                    Client_execution_file = "EveJima.exe";
                    Browser_IsShowFavorites = false;
                    Browser_IsPinned = false;
                    Browser_IsOpenKillboardInNewTab = true;
                    Browser_LocationMaximizeX = 510;
                    Browser_LocationMaximizeY = 254;
                    Server_MapAddress = @"http://www.evajima-maps.somee.com";

                    IsUseBrowser = true;
                    IsUseMap = false;
                    IsSignatureRebuildEnabled = true;
                    IsInterceptLinksFromEVE = false;

                    Save();
                }

                using (var wc = new System.Net.WebClient())
                    Version = wc.DownloadString(Server_update_uri_version);

                CurrentVersion = File.ReadAllText(@"Version.txt");

                if (new Version(Version).CompareTo(new Version(CurrentVersion)) > 0)
                {
                    IsNeedUpdateVersion = true;
                }
            }
            catch(Exception e)
            {
                Authorization_ClientId = "e136434f8a0c484ab802666f378cac09";
                Authorization_ClientSecret = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";
                Authorization_ClientState = "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY";
                Authorization_Port = "8080";
                Authorization_Scopes = "esi-location.read_location.v1 esi-location.read_ship_type.v1 esi-bookmarks.read_character_bookmarks.v1 esi-fleets.read_fleet.v1 esi-ui.open_window.v1 esi-ui.write_waypoint.v1";
                Server_update_uri_version = @"http://evejima.mikotaj.com/Version.txt";
                Server_update_content_version = @"http://evejima.mikotaj.com/VersionContent.txt";
                Client_execution_file = "EveJima.exe";
                Browser_IsShowFavorites = false;
                Browser_IsOpenKillboardInNewTab = true;
                Browser_IsPinned = false;
                Browser_LocationMaximizeX = 510;
                Browser_LocationMaximizeY = 254;
                Server_MapAddress = @"http://www.evajima-maps.somee.com";

                IsUseBrowser = true;
                IsUseMap = false;
                IsSignatureRebuildEnabled = true;
                IsInterceptLinksFromEVE = false;
            }

            
        }

        public void Save()
        {
            var path = "";
            try
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EveJima");
                var path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EveJima", "Settings.dat");

                if(Global.WorkEnvironment == null)
                {
                    Global.WorkEnvironment = new WorkEnvironment
                    {
                        IsPinned =  false,
                        IsShowFavorites = false,
                        LocationMaximizeX = 510,
                        LocationMaximizeY = 254,

                    };
                }

                var settingsContent = JsonConvert.SerializeObject(new
                {
                    Version = Version,
                    CurrentVersion = CurrentVersion,
                    Authorization_ClientId = Authorization_ClientId,
                    Authorization_ClientSecret = Authorization_ClientSecret,
                    Authorization_ClientState = Authorization_ClientState,
                    Authorization_Port = Authorization_Port,
                    Authorization_Scopes = Authorization_Scopes,
                    Server_update_uri_version = Server_update_uri_version,
                    Server_update_content_version = Server_update_content_version,
                    Client_execution_file = Client_execution_file,
                    Browser_IsShowFavorites = Global.WorkEnvironment.IsShowFavorites,
                    Browser_IsPinned = Global.WorkEnvironment.IsPinned,
                    Browser_LocationMaximizeX = Global.WorkEnvironment.LocationMaximizeX,
                    Browser_LocationMaximizeY = Global.WorkEnvironment.LocationMaximizeY,
                    Browser_IsOpenKillboardInNewTab = Browser_IsOpenKillboardInNewTab,
                    Pilots = Pilots,
                    Server_MapAddress = Server_MapAddress,
                    IsUseBrowser = IsUseBrowser,
                    IsUseMap = IsUseMap,
                    IsSignatureRebuildEnabled = IsSignatureRebuildEnabled,
                    IsInterceptLinksFromEVE = IsInterceptLinksFromEVE,
                    LanguageId = LanguageId
                });

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    using (var sw = new StreamWriter(path2, true))
                    {
                        sw.Write(settingsContent);
                    }
                }
                else
                {
                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }

                    using (var sw = new StreamWriter(path2, true))
                    {
                        sw.Write(settingsContent);
                    }
                }
            }
            catch(Exception ex)
            {
                _commandsLog.Error($"[ApplicationSettings.Save] Critical error on save settingt to file '{path}'. Exception is '{ex}'");
            }
        }
    }
}
