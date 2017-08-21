using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaSettings;
using log4net;
using EveJimaUniverse;
using Newtonsoft.Json;

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

        public static Color GetColorBySecurity(SecurityStatus security)
        {
            switch ( security )
            {
                case SecurityStatus.WSpace:
                    return Color.DarkRed;

                case SecurityStatus.Highsec:
                    return Color.LimeGreen;

                case SecurityStatus.Lowsec:
                    return Color.Chocolate;

                case SecurityStatus.Nullsec:
                    return Color.Red;
            }

            return Color.LimeGreen;
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

        public static SecurityStatus GetStatus(double securityStatus)
        {
            if(securityStatus < 0) return SecurityStatus.Nullsec;

            if(securityStatus > 0 && securityStatus < 0.45) return SecurityStatus.Lowsec;

            if (securityStatus >= 0.45) return SecurityStatus.Highsec;

            return SecurityStatus.WSpace;
        }

        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }

        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        public static T XmlDeserializeFromString<T>(this string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }

        public static object XmlDeserializeFromString(this string objectData, Type type)
        {
            var serializer = new XmlSerializer(type);
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }

            return result;
        }

        public static IList<T> CloneGenericList<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static void ConvertSettings(ApplicationSettings newSettings, Settings oldSettings, WorkEnvironment workEnvironment)
        {
            newSettings.Version = oldSettings.Version;
            newSettings.CurrentVersion = oldSettings.CurrentVersion;

            newSettings.Authorization_ClientId = oldSettings.CCPSSO_AUTH_CLIENT_ID;
            newSettings.Authorization_ClientSecret = oldSettings.CCPSSO_AUTH_CLIENT_SECRET;
            newSettings.Authorization_ClientState = oldSettings.CCPSSO_AUTH_CLIENT_STATE;
            newSettings.Authorization_Port = oldSettings.CCPSSO_AUTH_PORT;
            newSettings.Authorization_Scopes = oldSettings.CCPSSO_AUTH_SCOPES;
            newSettings.Server_update_uri_version = oldSettings.Server_update_uri_version;
            newSettings.Server_update_content_version = oldSettings.Server_update_content_version;
            newSettings.Client_execution_file = oldSettings.Client_execution_file;


            newSettings.Browser_IsShowFavorites = workEnvironment.IsShowFavorites;

            newSettings.Browser_IsPinned = workEnvironment.IsPinned;

            newSettings.Browser_LocationMaximizeX = workEnvironment.LocationMaximizeX;
            newSettings.Browser_LocationMaximizeY = workEnvironment.LocationMaximizeY;

            var allLines = Global.Pilots.GetPilotsStorageContent();

            foreach (var allLine in allLines)
            {
                try
                {
                    if (allLine.Trim() == String.Empty) continue;

                    var pilotDetails = allLine.Split(',');

                    newSettings.Pilots.Add(new Tuple<string, string, string, string>(pilotDetails[0], pilotDetails[1], pilotDetails[2], ""));
                }
                catch (Exception ex)
                {
                    //Log.ErrorFormat("[whlAuthorization.LoadAllPilotesFromStorage] Critical error. Exception {0}", ex);
                }

            }

            newSettings.Save();
        }

        public static T CloneObject<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
    }
}
