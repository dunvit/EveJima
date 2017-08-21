﻿using System;
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

        public int Browser_LocationMaximizeX { get; set; }
        public int Browser_LocationMaximizeY { get; set; }

        public string Server_MapAddress { get; set; }


        public List<Tuple<string, string, string, string>> Pilots { get; set; }

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

        private static bool IsNeedConvert()
        {
            return File.Exists("EveJimaSettings.txt");
        }

        private void Load()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EveJima", "Settings.dat");

            var settingsContent = "";

            if(File.Exists(path))
            {
                settingsContent = File.ReadAllText(path);
                IsConverted = true;
            }
            else
            {
                settingsContent = File.ReadAllText(@"EveJimaSettings.txt");
            }

            

            dynamic jsonResponse = JsonConvert.DeserializeObject(settingsContent);

            Version                         = jsonResponse.Version;
            CurrentVersion                  = jsonResponse.CurrentVersion;
            Authorization_ClientId          = jsonResponse.Authorization_ClientId;
            Authorization_ClientSecret      = jsonResponse.Authorization_ClientSecret;
            Authorization_ClientState       = jsonResponse.Authorization_ClientState;
            Authorization_Port              = jsonResponse.Authorization_Port;
            Authorization_Scopes            = jsonResponse.Authorization_Scopes;
            Server_update_uri_version       = jsonResponse.Server_update_uri_version;
            Server_update_content_version   = jsonResponse.Server_update_content_version;
            Client_execution_file           = jsonResponse.Client_execution_file;
            Browser_IsShowFavorites         = jsonResponse.Browser_IsShowFavorites;
            Browser_IsPinned                = jsonResponse.Browser_IsPinned;
            Browser_LocationMaximizeX       = jsonResponse.Browser_LocationMaximizeX;
            Browser_LocationMaximizeY       = jsonResponse.Browser_LocationMaximizeY;
            Server_MapAddress               = jsonResponse.Server_MapAddress;

            var ccPilots = jsonResponse.Pilots;

            foreach(var ccPilot in ccPilots)
            {
                Pilots.Add(new Tuple<string, string, string, string>(ccPilot.Item1.ToString(), ccPilot.Item2.ToString(), ccPilot.Item3.ToString(), ccPilot.Item4.ToString()));
            }

        }

        public void Save()
        {
            var path = "";
            try
            {
                path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EveJima");
                var path2 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "EveJima", "Settings.dat");

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
                    Browser_IsShowFavorites = Browser_IsShowFavorites,
                    Browser_IsPinned = Browser_IsPinned,
                    Browser_LocationMaximizeX = Browser_LocationMaximizeX,
                    Browser_LocationMaximizeY = Browser_LocationMaximizeY,
                    Pilots = Pilots,
                    Server_MapAddress = Server_MapAddress,
                });

                // TODO: ReBuild screens coordinates for one screen { foreach (var screen in Screen.AllScreens) }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    using (StreamWriter sw = new StreamWriter(path2, true))
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

                    using (StreamWriter sw = new StreamWriter(path2, true))
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
