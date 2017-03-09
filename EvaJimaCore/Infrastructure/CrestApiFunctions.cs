using System;
using System.IO;
using System.Net;
using EveJimaCore.BLL;
using log4net;

namespace EveJimaCore
{
    public class CrestApiFunctions
    {
        public static void SetWaypoint(PilotEntity pilot, string clearOtherWaypoints, string solarSystemId)
        {
            var Log = LogManager.GetLogger(typeof(CrestAuthorization));

            Log.DebugFormat("[CrestAuthorization.SetWaypointRefresh] started for refresh_token = {0}", pilot.CrestData.AccessToken);

            var url = "https://crest-tq.eveonline.com//characters/" + pilot.Id + "/ui/autopilot/waypoints/";

            try
            {
                
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + pilot.CrestData.AccessToken);
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
