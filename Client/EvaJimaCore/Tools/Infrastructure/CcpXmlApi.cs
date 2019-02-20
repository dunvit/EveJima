using System;
using System.IO;
using System.Net;
using System.Text;
using EvaJimaCore;
using log4net;

namespace EveJimaCore
{
    public class CcpXmlApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CcpXmlApi));

        public string GetPilotIdByName(string name)
        {
            var characterId = "0";
            var url = "";

            try
            {
                url = Global.ApplicationSettings.Common.EsiAddress + "/latest/search/?search=" + WebUtility.UrlEncode(name) + "&categories=character&language=en-us&strict=true&datasource=tranquility";

                Log.DebugFormat("[Zkillboard.GetZkillboardUrlByName] Read url {0} ", url);

                var data = ReadFile(url);

                characterId = data.Split(new[] { "[" }, StringSplitOptions.None)[1].Split(new[] { "]" }, StringSplitOptions.None)[0];

                return characterId;
            }
            catch(Exception e)
            {
                Log.ErrorFormat("[Pilot.GetPilotIdByName] Read url {0} is failed. Exception = {1} ", url, e);
                return characterId;
            }
        }

        private static string ReadFile(string urlAddress)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlAddress);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.ErrorFormat("[Pilot.ReadCageConfigurationFile] Read configuration file {0} is failed. Status = {1} ", urlAddress, response.StatusCode);
                return null;
            }

            var receiveStream = response.GetResponseStream();

            var readStream = response.CharacterSet == null ? new StreamReader(receiveStream) : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            var data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            return data;
        }
    }
}
