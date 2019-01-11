using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaIGB
{
    public class Zkillboard
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public static string GetZkillboardUrlByName(string name)
        {
            var entityId = "0";
            var url = "";

            try
            {
                url = "https://esi.evetech.net/latest/search/?search=" + WebUtility.UrlEncode(name) + "&categories=character&language=en-us&strict=true&datasource=tranquility";

                //url = "https://api.eveonline.com/eve/CharacterID.xml.aspx?names=" + WebUtility.UrlEncode(name);

                Log.DebugFormat("[Zkillboard.GetZkillboardUrlByName] Read url {0} ", url);

                var data = ReadFile(url);

                var dataParts = data.Split(new[] { "[" }, StringSplitOptions.None)[1].Split(new[] { "]" }, StringSplitOptions.None)[0];

                return GetZkillboardUrl(dataParts);
            }
            catch(Exception e)
            {
                Log.ErrorFormat("[Zkillboard.GetZkillboardUrlByName] Read url {0} is failed. Exception = {1} ", url, e);
                return string.Empty;
            }
        }

        private static string GetZkillboardUrl(string id)
        {
            if(id == "0")
            {
                Log.ErrorFormat("[MainEveJima.timerCopySelectedText_Tick] No Character No Corporation Id = '{0}'", id);

                return string.Empty;
            }

            if (IsCharacter(id))
            {
                Log.ErrorFormat("[Zkillboard.GetZkillboardUrl] Pilot Id = '{0}'", id);

                return "https://zkillboard.com/character/" + id + "/";
            }

            if (IsCorporation(id))
            {
                Log.ErrorFormat("[Zkillboard.GetZkillboardUrl] Corporation Id = '{0}'", id);

                return "https://zkillboard.com/corporation/" + id + "/";
            }

            if (IsSolarSystem(id))
            {
                Log.ErrorFormat("[Zkillboard.GetZkillboardUrl] Solar System Id = '{0}'", id);

                return "https://zkillboard.com/system/" + id + "/";
            }

            if (IsAlliance(id))
            {
                Log.ErrorFormat("[Zkillboard.GetZkillboardUrl] Alliance Id = '{0}'", id);

                return "https://zkillboard.com/alliance/" + id + "/";
            }

            Log.ErrorFormat("[MainEveJima.timerCopySelectedText_Tick] No Character No Corporation Id = '{0}'", id);

            return string.Empty;
        }

        private static string ReadFile(string url)
        {
            var content = string.Empty;
            const string referer = "";
            const string uagent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";

            try
            {
                using (var webClient = new ExtendedWebClient(uagent, referer))
                {
                    Log.DebugFormat("[Zkillboard.ReadFile] Try download file {0}; ua: {1} ref: {2} ", url, uagent, referer);

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    var result = webClient.DownloadData(url);

                    var encoding = Tools.GetEncodingFrom(webClient.ResponseHeaders, Encoding.UTF8);

                    content = encoding.GetString(result);

                    Log.DebugFormat("[Zkillboard.ReadFile] Downloaded successed css {0}; ua: {1} ref: {2} ", url, uagent, referer);

                    return content;

                }
            }
            catch(Exception e)
            {
                Log.ErrorFormat("[Zkillboard.ReadFile] Critical error on download file from '{0}'", url);

                return content;
            }
        }

        private static bool IsCharacter(string id)
        {
            try
            {
                var url = "https://zkillboard.com/api/stats/characterID/" + id + "/";

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                if (content.IndexOf("\"info\":null,") > -1)
                {
                    return false;
                }

                return true;
            }
            catch 
            {
                return false;
            }

        }

        private static bool IsCorporation(string id)
        {
            try
            {
                var url = "https://zkillboard.com/api/stats/corporationID/" + id + "/";

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                if (content.IndexOf("\"info\":null,") > -1)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsSolarSystem(string id)
        {
            try
            {
                var url = "https://zkillboard.com/api/stats/solarSystemID/" + id + "/";

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                if (content.IndexOf("\"info\":null,") > -1)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        private static bool IsAlliance(string id)
        {
            try
            {
                var url = "https://zkillboard.com/api/stats/allianceID/" + id + "/";

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                if (content.IndexOf("\"info\":null,") > -1)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
