using System;
using System.Net;
using System.Threading;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class ZKillboardApi
    {
        public static bool IsCharacter(string Id, ILog log)
        {
            try
            {
                //Thread.Sleep(100);

                var url = "https://zkillboard.com/api/stats/characterID/" + Id + "/";

                //log.FatalFormat("[ZKillboardApi.IsCharacter] url = '{0}'", url);


                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                if(content.IndexOf("is not a valid parameter") > -1)
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                //log.FatalFormat("[ZKillboardApi.IsCharacter] Exception = '{0}'", ex);
                return false;
            }

        }

        public static bool IsCorporation(string Id, ILog log)
        {
            try
            {
                //Thread.Sleep(100);

                var url = "https://zkillboard.com/api/stats/corporationID/" + Id + "/";

                log.FatalFormat("[ZKillboardApi.IsCorporation] url = '{0}'", url);

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                dynamic data = JObject.Parse(content);
                var info = data.allTimeSum.ToString();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsSolarSystem(string Id, ILog log)
        {
            try
            {
                //Thread.Sleep(100);

                var url = "https://zkillboard.com/api/stats/solarSystemID/" + Id + "/";

                //log.FatalFormat("[ZKillboardApi.IsSolarSystem] url = '{0}'", url);

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                dynamic data = JObject.Parse(content);
                var info = data.allTimeSum.ToString();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsAlliance(string Id, ILog log)
        {
            try
            {
                //Thread.Sleep(100);

                var url = "https://zkillboard.com/api/stats/allianceID/" + Id + "/";

                //log.FatalFormat("[ZKillboardApi.IsAlliance] url = '{0}'", url);

                var webClient = new WebClient();
                webClient.Headers.Add("User-Agent: Other");

                var content = webClient.DownloadString(url);

                dynamic data = JObject.Parse(content);
                var info = data.allTimeSum.ToString();

                return true;
            }
            catch
            {
                return false;
            }

        }

        //
    }
}
