using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using EveJimaCore.BLL;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class EsiAuthorization
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EsiAuthorization));

        private string CLIENT_ID = "";
        private string CLIENT_SECRET = "";

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

        public EsiAuthorization(string clientID, string clientSecret)
        {
            Log.DebugFormat("[EsiAuthorization.EsiAuthorization] started for clientID = {0} and clientSecret = {1}", clientID, clientSecret);

            CLIENT_ID = clientID;
            CLIENT_SECRET = clientSecret;
        }

        public void Authorization(string token)
        {
            Log.DebugFormat("[EsiAuthorization.Authorization] started for token = {0}", token);

            VerifyAuthorizationCode(token);

            Refresh();
        }

        private void VerifyAuthorizationCode(string token)
        {
            Log.DebugFormat("[EsiAuthorization.VerifyAuthorizationCode] started for token = {0}", token);

            var url = "https://login.eveonline.com/oauth/token";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(CLIENT_ID + ":" + CLIENT_SECRET));

            Log.DebugFormat("[EsiAuthorization.VerifyAuthorizationCode] encoded is {0}", encoded);

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

                    Log.DebugFormat("[EsiAuthorization.VerifyAuthorizationCode] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[EsiAuthorization.VerifyAuthorizationCode] Critical error. Exception is {0}", ex);
            }

        }

        public void Refresh(string refreshToken)
        {
            RefreshToken = refreshToken;
            Refresh();
        }

        public void Refresh()
        {
            Log.DebugFormat("[EsiAuthorization.Refresh] started for refresh_token = {0}", RefreshToken);

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

                    Log.DebugFormat("[EsiAuthorization.Refresh] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.Refresh] Exception is {0}", ex);
            }

        }

        public void SetWaypoint(string addToBeginning, string clearOtherWaypoints, string solarSystemId)
        {
            Log.DebugFormat("[EsiAuthorization.SetWaypoint] started for refresh_token = {0}", AccessToken);
            
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
                Log.ErrorFormat("Critical error in [EsiAuthorization.SetWaypoint] Exception is {0}", ex);
            }

        }

        public dynamic ObtainingCharacterData()
        {
            Log.DebugFormat("[EsiAuthorization.ObtainingCharacterData] AccessToken = {0}", AccessToken);

            var url = "https://login.eveonline.com/oauth/verify";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "login.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[EsiAuthorization.ObtainingCharacterData] result = {0}", result);

                return JObject.Parse(result);

            }

        }

        public dynamic GetSolarSystemInfo(string systemId)
        {
            Log.DebugFormat("[EsiAuthorization.GetSolarSystemInfo] started. systemId = {0}", systemId);

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

                    Log.DebugFormat("[EsiAuthorization.GetSolarSystemInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetSolarSystemInfo] systemId = {1} Exception is {0}", ex, systemId);
                return null;
            }
        }

        public dynamic GetCorporationInfo(string corporationId)
        {
            Log.DebugFormat("[EsiAuthorization.GetCorporationInfo] started. systemId = {0}", corporationId);

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

                    Log.DebugFormat("[EsiAuthorization.GetCorporationInfo] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetCorporationInfo] systemId = {1} Exception is {0}", ex, corporationId);
                return null;
            }
        }

        public dynamic GetLocation(long pilotId)
        {
            Log.DebugFormat("[EsiAuthorization.GetLocation] started. pilotId = {0}", pilotId);

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

                    Log.DebugFormat("[EsiAuthorization.GetLocation] result = {0}", result);

                    return JObject.Parse(result);

                }
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetLocation] Exception is {0}", ex);
                return null;
            }

            
        }

        public List<string> GetStargates(int systemId)
        {
            Log.DebugFormat("[EsiAuthorization.GetStargates] started. systemId = {0}", systemId);

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

                    Log.DebugFormat("[EsiAuthorization.GetStargates] result = {0}", result);

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
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetStargates] systemId = {1} Exception is {0}", ex, systemId);
                return null;
            }
        }

        public List<Bookmark> GetBookmarks(long pilotId, string folderId)
        {
            Log.DebugFormat("[EsiAuthorization.GetBookmarks] started. pilotId = {0}", pilotId);

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

                    Log.DebugFormat("[EsiAuthorization.GetBookmarks] result = {0}", result);

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
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetBookmarks] Exception is {0}", ex);
                return null;
            }


        }

        public List<Tuple<string,string>> GetBookmarksFolders(long pilotId)
        {
            Log.DebugFormat("[EsiAuthorization.GetBookmarksFolders] started. pilotId = {0}", pilotId);

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

                    Log.DebugFormat("[EsiAuthorization.GetBookmarksFolders] result = {0}", result);

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
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetBookmarksFolders] Exception is {0}", ex);
                return null;
            }


        }

        public int GetRouteJumps(string origin, string destination)
        {
            Log.DebugFormat("[EsiAuthorization.GetRouteJumps] started. origin = {0} destination = {1}", origin, destination);

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

                    Log.DebugFormat("[EsiAuthorization.GetRouteJumps] result = {0}", result);

                    return JArray.Parse(result).Count - 1;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetRouteJumps] Exception is {0}", ex);
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
            Log.DebugFormat("[EsiAuthorization.GetSolarSystemIdByStargate] started. stargateId = {0}", stargateId);

            try
            {
                var url = "https://esi.tech.ccp.is/latest/universe/stargates/" + stargateId + "/";

                Log.DebugFormat("[EsiAuthorization.GetSolarSystemIdByStargate] Start Get solar system. " + url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[EsiAuthorization.GetSolarSystemIdByStargate] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    var solarSystemId = data.destination.system_id;

                    return solarSystemId.ToString();

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetSolarSystemIdByStargate] stargateId = {1} Exception is {0}", ex, stargateId);
                return null;
            }
        }


        public static Tuple<string, string, string> GetSystemKills(string systemId)
        {
            Log.DebugFormat("[EsiAuthorization.GetSystemKills] started. systemId = {0} ", systemId);

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

                    Log.DebugFormat("[EsiAuthorization.GetSystemKills] result = {0}", result);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [EsiAuthorization.GetSystemKills] Exception is {0}", ex);
                return null;
            }


        }

    }
}
