using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using EveJimaCore.BLL;
using log4net;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class CrestApiFunctions
    {
        public static dynamic GetLocation(long pilotId, string AccessToken)
        {
            //Log.DebugFormat("[CrestAuthorization.GetLocation] started. pilotId = {0}", pilotId);

            var url = "https://crest-tq.eveonline.com//characters/" + pilotId + "/contacts/";

            //Trace.TraceInformation(DateTime.Now.ToLongTimeString() + " Start Get location. " + url);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + AccessToken);
            httpWebRequest.Host = "crest-tq.eveonline.com";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                //Log.DebugFormat("[CrestAuthorization.GetLocation] result = {0}", result);

                return JObject.Parse(result);

            }
        }

        public static void SetWaypoint(PilotEntity pilot, string clearOtherWaypoints, string solarSystemId)
        {
            var Log = LogManager.GetLogger(typeof(CrestApiFunctions));

            Log.DebugFormat("[CrestAuthorization.SetWaypointRefresh] started for refresh_token = {0}", pilot.EsiData.AccessToken);

            var url = "https://crest-tq.eveonline.com//characters/" + pilot.Id + "/ui/autopilot/waypoints/";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + pilot.EsiData.AccessToken);
                httpWebRequest.Host = "crest-tq.eveonline.com";

                IDisposable disposableResponse = httpWebRequest as IDisposable;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"clearOtherWaypoints\": " + clearOtherWaypoints + ",\"first\": " + clearOtherWaypoints + ",\"solarSystem\": {\"href\": \"https://crest-tq.eveonline.com/solarsystems/" + solarSystemId + "/\",\"id\": " + solarSystemId + "}}";

                    streamWriter.Write(json);
                    streamWriter.Flush();

                    using (HttpWebResponse objResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        // do something...
                    }
                }

                httpWebRequest = null;

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error in [CrestAuthorization.SetWaypointRefresh] Exception is {0}", ex);
            }

        }
    }
}
