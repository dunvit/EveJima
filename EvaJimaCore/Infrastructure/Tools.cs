using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace EveJimaCore
{
    public static class Tools
    {
        #region
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        #endregion

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();

            return GetWindowText(handle, buff, nChars) > 0 ? buff.ToString() : null;
        }

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

        public static bool IsWSpaceSystem(string systemName)
        {
            var numbersInSystemName = Regex.Match(systemName, @"\d+").Value;

            if (numbersInSystemName == "") return false;

            return systemName.Replace(numbersInSystemName, "") == "J";
        }
    }
}
