using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class EsiApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EsiApi));

        private string CLIENT_ID = "";
        private string CLIENT_SECRET = "";

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

        public EsiApi(string clientID, string clientSecret)
        {
            Log.DebugFormat("[EsiApi.EsiApi] started for clientID = {0} and clientSecret = {1}", clientID, clientSecret);

            CLIENT_ID = clientID;
            CLIENT_SECRET = clientSecret;
        }

        public void Authorization(string token)
        {
            Log.DebugFormat("[EsiApi.Authorization] started for token = {0}", token);

            VerifyAuthorizationCode(token);

            Refresh();
        }

        private void VerifyAuthorizationCode(string token)
        {
            Log.DebugFormat("[EsiApi.VerifyAuthorizationCode] started for token = {0}", token);

            var url = "https://login.eveonline.com/oauth/token";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(CLIENT_ID + ":" + CLIENT_SECRET));

            Log.DebugFormat("[EsiApi.VerifyAuthorizationCode] encoded is {0}", encoded);

            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Host = "login.eveonline.com";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"grant_type\":\"authorization_code\",\"code\":\"" + token + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.VerifyAuthorizationCode] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[EsiApi.VerifyAuthorizationCode] Critical error. Exception is {0}", ex);
            }

        }

        public void Refresh(string refreshToken)
        {
            RefreshToken = refreshToken;
            Refresh();
        }

        public void Refresh()
        {
            Log.DebugFormat("[EsiApi.Refresh] started for refresh_token = {0}", RefreshToken);

            var url = "https://login.eveonline.com/oauth/token";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(CLIENT_ID + ":" + CLIENT_SECRET));
                httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
                httpWebRequest.Host = "login.eveonline.com";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"grant_type\":\"refresh_token\",\"refresh_token\":\"" + RefreshToken + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.Refresh] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.Refresh] Exception is {0}", ex);
            }

        }

        public void SetWaypoint(string addToBeginning, string clearOtherWaypoints, string solarSystemId)
        {
            Log.DebugFormat("[EsiApi.SetWaypoint] started for refresh_token = {0}", AccessToken);
            
            var url = @"https://esi.tech.ccp.is/latest/ui/autopilot/waypoint/?add_to_beginning=false&clear_other_waypoints=" + clearOtherWaypoints  + "&datasource=tranquility&destination_id=" + solarSystemId;

            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    using (HttpWebResponse objResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        // do something...
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.SetWaypoint] Exception is {0}", ex);
            }

        }

        public dynamic ObtainingCharacterData()
        {
            Log.DebugFormat("[EsiApi.ObtainingCharacterData] AccessToken = {0}", AccessToken);

            var url = "https://login.eveonline.com/oauth/verify";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "login.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[EsiApi.ObtainingCharacterData] result = {0}", result);

                return JObject.Parse(result);

            }

        }

        public dynamic GetSolarSystemInfo(string systemId)
        {
            Log.DebugFormat("[EsiApi.GetSolarSystemInfo] started. systemId = {0}", systemId);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/systems/" + systemId + "/";

                Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Get solar system. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";
                
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetSolarSystemInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetSolarSystemInfo] systemId = {1} Exception is {0}", ex, systemId);
                return null;
            }
        }

        public dynamic GetConstellationInfo(string id)
        {
            Log.DebugFormat("[EsiApi.GetConstellationInfo] started. systemId = {0}", id);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/constellations/" + id + "/";

                Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Constellation. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetConstellationInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetConstellationInfo] systemId = {1} Exception is {0}", ex, id);
                return null;
            }
        }

        public dynamic GetRegionInfo(string id)
        {
            Log.DebugFormat("[EsiApi.GetConstellGetRegionInfoationInfo] started. systemId = {0}", id);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/regions/" + id + "/";

                Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Region. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetRegionInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetRegionInfo] systemId = {1} Exception is {0}", ex, id);
                return null;
            }
        }

        public string GetSolarSystemId(string name)
        {
            Log.DebugFormat("[EsiApi.GetSolarSystemId] started. name = {0}", name);

            var url = "";
            var solarSystemId = "";

            try
            {
                url = "https://esi.tech.ccp.is/latest/search/?search=" + WebUtility.UrlEncode(name) + "&categories=solar_system&language=en-us&strict=true&datasource=tranquility";

                Log.DebugFormat("[EsiApi.GetSolarSystemId] Read url {0} ", url);

                var data = Tools.ReadFile(url, Log);

                solarSystemId = data.Split(new[] { "[" }, StringSplitOptions.None)[1].Split(new[] { "]" }, StringSplitOptions.None)[0];

                return solarSystemId;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("[Pilot.GetSolarSystemId] Read url {0} is failed. Exception = {1} ", url, e);
                return solarSystemId;
            }
        }

        public dynamic GetCorporationInfo(string corporationId)
        {
            Log.DebugFormat("[EsiApi.GetCorporationInfo] started. systemId = {0}", corporationId);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/corporations/names/?corporation_ids=" + corporationId + "&datasource=tranquility";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    result = result.Substring(1, result.Length - 2);

                    Log.DebugFormat("[EsiApi.GetCorporationInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetCorporationInfo] systemId = {1} Exception is {0}", ex, corporationId);
                return null;
            }
        }

        public dynamic GetLocation(long pilotId)
        {
            Log.DebugFormat("[EsiApi.GetLocation] started. pilotId = {0}", pilotId);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/characters/" + pilotId + "/location/";

                Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Get location. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";
                //httpWebRequest.Host = "crest-tq.eveonline.com";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetLocation] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetLocation] Exception is {0}", ex);
                return null;
            }

            
        }

        public List<string> GetStargates(int systemId)
        {
            Log.DebugFormat("[EsiApi.GetStargates] started. systemId = {0}", systemId);

            var stargates = new List<string>();

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/systems/" + systemId + "/";

                Log.DebugFormat(DateTime.Now.ToLongTimeString() + " Start Get solar system. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetStargates] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    
                    var dynamicStargates = data.stargates;

                    foreach (var content in dynamicStargates)
                    {
                        var locationId = content.ToString();

                        stargates.Add(locationId);
                    }

                    return stargates;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetStargates] systemId = {1} Exception is {0}", ex, systemId);
                return null;
            }
        }

        public List<Bookmark> GetBookmarks(long pilotId, string folderId)
        {
            Log.DebugFormat("[EsiApi.GetBookmarks] started. pilotId = {0}", pilotId);

            try
            {
                var url = "https://esi.tech.ccp.is/v1/characters/" + pilotId + "/bookmarks/";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetBookmarks] result = {0}", result);

                    var retValue = new List<Bookmark>();

                    foreach (var content in JArray.Parse(result).Children<JObject>())
                    {
                        try
                        {
                            if(content.SelectToken("folder_id") == null) continue;

                            

                            var bookmark = new Bookmark
                            {
                                Name = content.SelectToken("memo").ToString(),
                                SystemId = content.SelectToken("target.location_id").ToString(),
                                Note = content.SelectToken("note").ToString()
                            };


                            foreach(var contentInternal in content.SelectToken("target").Children<JObject>())
                            {
                                var a1 = contentInternal.SelectToken("item_id").ToString();
                            }


                            //string distance = content.SelectToken("target[0].item[0].item_id").ToString();

                            //if (content.SelectToken("target.item.item_id").ToString() == "5")
                            //{
                            //    bookmark.SystemId = content.SelectToken("target.item.item_id").ToString();
                            //}

                            if(content.SelectToken("target.item.type_id") != null)
                            {
                                if(content.SelectToken("target.item.type_id").ToString() == "5")
                                {
                                    // Bookmark of solar system from star map
                                    if(content.SelectToken("target.item.item_id") != null)
                                    {
                                        bookmark.SystemId = content.SelectToken("target.item.item_id").ToString();
                                    }
                                }
                            }

                            if (content.SelectToken("folder_id").ToString() == folderId) retValue.Add(bookmark);
                        }
                        catch(Exception exinternal)
                        {
                            string a = "";
                        }

                        

                    }

                    return retValue;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetBookmarks] Exception is {0}", ex);
                return null;
            }


        }

        public List<Tuple<string,string>> GetBookmarksFolders(long pilotId)
        {
            Log.DebugFormat("[EsiApi.GetBookmarksFolders] started. pilotId = {0}", pilotId);

            try
            {
                var url = "https://esi.tech.ccp.is/v1/characters/" + pilotId + "/bookmarks/folders/";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetBookmarksFolders] result = {0}", result);

                    var retValue = new List<Tuple<string, string>>();

                    foreach (var content in JArray.Parse(result).Children<JObject>())
                    {
                        retValue.Add(new Tuple<string, string>(content.SelectToken("name").ToString(), content.SelectToken("folder_id").ToString()));
                    }

                    return retValue;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetBookmarksFolders] Exception is {0}", ex);
                return null;
            }


        }

        public int GetRouteJumps(string origin, string destination)
        {
            Log.DebugFormat("[EsiApi.GetRouteJumps] started. origin = {0} destination = {1}", origin, destination);

            try
            {
                var url = "https://esi.tech.ccp.is/v1/route/" + origin + "/" + destination + "/";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetRouteJumps] result = {0}", result);

                    return JArray.Parse(result).Count - 1;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetRouteJumps] Exception is {0}", ex);
                return -1;
            }


        }

        public dynamic GetCharacterInfo(long pilotId)
        {
            Log.DebugFormat("[CrestAuthorization.GetCharacterInfo] started. pilotId = {0}", pilotId);

            
            var url = "https://esi.tech.ccp.is/v1/characters/" + pilotId + "/portrait/";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[CrestAuthorization.GetCharacterInfo] result = {0}", result);

                return JObject.Parse(result);

            }
        }


        public string GetSolarSystemIdByStargate(string stargateId)
        {
            Log.DebugFormat("[EsiApi.GetSolarSystemIdByStargate] started. stargateId = {0}", stargateId);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/stargates/" + stargateId + "/";

                Log.DebugFormat("[EsiApi.GetSolarSystemIdByStargate] Start Get solar system. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiApi.GetSolarSystemIdByStargate] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    var solarSystemId = data.destination.system_id;

                    return solarSystemId.ToString();

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetSolarSystemIdByStargate] stargateId = {1} Exception is {0}", ex, stargateId);
                return null;
            }
        }


        public static Tuple<string, string, string> GetSystemKills(string systemId)
        {
            Log.DebugFormat("[EsiApi.GetSystemKills] started. systemId = {0} ", systemId);

            try
            {
                var url = "https://esi.tech.ccp.is/v2/universe/system_kills/";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    foreach (var content in JArray.Parse(result))
                    {
                        var system_id = content.SelectToken("system_id").ToString();
                        var ship_kills = content.SelectToken("ship_kills").ToString();
                        var npc_kills = content.SelectToken("npc_kills").ToString();
                        var pod_kills = content.SelectToken("pod_kills").ToString();

                        if(systemId == system_id)
                        {
                            return new Tuple<string, string, string>(ship_kills, npc_kills, pod_kills);
                        }

                    }

                    Log.DebugFormat("[EsiApi.GetSystemKills] result = {0}", result);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiApi.GetSystemKills] Exception is {0}", ex);
                return null;
            }


        }

    }
}
