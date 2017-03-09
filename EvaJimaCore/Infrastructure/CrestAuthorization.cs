using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using EvaJimaCore;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class CrestAuthorization
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CrestAuthorization));

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

        private string CCPSSO_AUTH_CLIENT_ID = "";
        
        private string CCPSSO_AUTH_CLIENT_SECRET = "";

        public CrestAuthorization(string token, string clientID, string clientSecret)
        {
            CCPSSO_AUTH_CLIENT_ID = clientID;
            CCPSSO_AUTH_CLIENT_SECRET = clientSecret;

            Log.DebugFormat("[CrestAuthorization.CrestAuthorization] started for token = {0}", token);

            VerifyAuthorizationCode(token);

            Refresh();
        }

        private void VerifyAuthorizationCode(string token)
        {
            Log.DebugFormat("[CrestAuthorization.VerifyAuthorizationCode] started for token = {0}", token);

            const string url = "https://login.eveonline.com/oauth/token";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(CCPSSO_AUTH_CLIENT_ID + ":" + CCPSSO_AUTH_CLIENT_SECRET));

            Log.DebugFormat("[CrestAuthorization.VerifyAuthorizationCode] encoded is {0}", encoded);

            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
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

                    Log.DebugFormat("[CrestAuthorization.VerifyAuthorizationCode] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[CrestAuthorization.VerifyAuthorizationCode] Critical error. Exception is {0}", ex);
            }

        }

        public void Refresh(string refreshToken)
        {
            RefreshToken = refreshToken;
            Refresh();
        }

        public void Refresh()
        {
            Log.DebugFormat("[CrestAuthorization.Refresh] started for refresh_token = {0}", RefreshToken);

            const string url = "https://login.eveonline.com/oauth/token";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(CCPSSO_AUTH_CLIENT_ID + ":" + CCPSSO_AUTH_CLIENT_SECRET));
                httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
                httpWebRequest.Host = "login.eveonline.com";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = "{\"grant_type\":\"refresh_token\",\"refresh_token\":\"" + RefreshToken + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Log.DebugFormat("[CrestAuthorization.Refresh] result = {0}", result);

                    dynamic data = JObject.Parse(result);

                    AccessToken = data.access_token;
                    RefreshToken = data.refresh_token;
                    TokenType = data.token_type;
                    ExpiresIn = data.expires_in;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [CrestAuthorization.Refresh] Exception is {0}", ex);
            }

        }

        public dynamic ObtainingCharacterData()
        {
            Log.DebugFormat("[CrestAuthorization.ObtainingCharacterData] AccessToken = {0}", AccessToken);

            const string url = "https://login.eveonline.com/oauth/verify";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "login.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[CrestAuthorization.ObtainingCharacterData] result = {0}", result);

                return JObject.Parse(result);

            }

        }

        public dynamic GetLocation(long pilotId)
        {
            Log.DebugFormat("[CrestAuthorization.GetLocation] started. pilotId = {0}", pilotId);

            var url = "https://crest-tq.eveonline.com//characters/" + pilotId + "/location/";

            Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Get location. " + url);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "crest-tq.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                Log.DebugFormat("[CrestAuthorization.GetLocation] result = {0}", result);

                return JObject.Parse(result);

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
