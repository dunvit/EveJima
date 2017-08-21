using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
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

            return null;
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
                Log.ErrorFormat("Critical error in [EsiAuthorization.Refresh] Exception is {0}", ex);
                return null;
            }

            
        }

        public dynamic GetCharacterInfo(long pilotId)
        {
            Log.DebugFormat("[CrestAuthorization.GetCharacterInfo] started. pilotId = {0}", pilotId);

            var url = "https://crest-tq.eveonline.com//characters/" + pilotId + "/";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "crest-tq.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[CrestAuthorization.GetCharacterInfo] result = {0}", result);

                return JObject.Parse(result);

            }
        }


    }
}
