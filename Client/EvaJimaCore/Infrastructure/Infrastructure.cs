using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CsvHelper;
using EvaJimaCore;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class Infrastructure
    {
        public CcpXmlApi EveXmlApi = new CcpXmlApi();
 
        public static Dictionary<string, string> GetSolarSystems()
        {
            const string url = "https://crest-tq.eveonline.com/solarsystems/";

            var client = new WebClient();

            var result = client.DownloadString(url);

            var jsonData = JObject.Parse(result);

            var data = jsonData["items"].ToString().Trim(); 
            
            var a = JArray.Parse(data);

            var returnCollection = new Dictionary<string, string>();

            foreach (var o in a.Children<JObject>())
            {
                var id = o["id"].ToString().Trim();
                var name = o["name"].ToString().Trim();

                returnCollection.Add(name, id);
            }

            return returnCollection;

            //using (var sw = new StreamWriter(@"Data/BasicSolarSystems.csv"))
            //{
            //    var writer = new CsvWriter(sw);

            //    IEnumerable records = Global.Space.BasicSolarSystems.ToList();

            //    writer.WriteRecords(records);
            //}
        }
    }
}
