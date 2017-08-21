using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using log4net;

namespace EvaJimaCore.UiTools
{
    public static class Tools
    {
        

        public static string ReadFile(string urlAddress, ILog log)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlAddress);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                log.ErrorFormat("[UiTools.ReadFile] Read configuration file {0} is failed. Status = {1} ", urlAddress, response.StatusCode);
                return null;
            }

            var receiveStream = response.GetResponseStream();

            var readStream = response.CharacterSet == null ? new StreamReader(receiveStream) : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            var data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            return data;
        }

        public static Color GetColorBySolarSystem(string solarSystemName)
        {
            if (solarSystemName.Contains("Highsec")) return Color.LimeGreen;

            if (solarSystemName.Contains("Lowsec")) return Color.Chocolate;

            if (solarSystemName.Contains("Nullsec")) return Color.Red;

            if (solarSystemName.Contains("C6")) return Color.DarkRed;

            if (solarSystemName.Contains("C2")) return Color.DeepSkyBlue;

            if (solarSystemName.Contains("C3")) return Color.DeepSkyBlue;

            if (solarSystemName.Contains("C1")) return Color.DeepSkyBlue;

            if (solarSystemName.Contains("C4")) return Color.OrangeRed;

            if (solarSystemName.Contains("C5")) return Color.Crimson;

            return Color.Bisque;
        }

    }
}
