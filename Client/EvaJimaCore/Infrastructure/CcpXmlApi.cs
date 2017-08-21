using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace EveJimaCore
{
    public class CcpXmlApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CcpXmlApi));

        public string GetPilotIdByName(string name)
        {
            var data = ReadFile("https://api.eveonline.com/eve/CharacterID.xml.aspx?names=" + WebUtility.UrlEncode(name));

            var characterId="0";

            var dataParts = data.Split(new[] { "characterID=" }, StringSplitOptions.None)[1].Split(new[] { "/>" }, StringSplitOptions.None)[0];

            dataParts = dataParts.Replace("\"", "<a>");
            

            var m1 = Regex.Matches(dataParts, @"(<a.*?>.*?<a>)", RegexOptions.Singleline);

            foreach (var value in from Match m in m1 select m.Groups[1].Value)
            {
                characterId = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
            }

            return characterId;
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
