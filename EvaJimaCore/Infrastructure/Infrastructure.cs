using System;
using System.Collections;
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

        public Infrastructure()
        {
            
        }

        public static void GetSolarSystems()
        {
            const string url = "https://crest-tq.eveonline.com/solarsystems/";

            var client = new WebClient();

            var result = client.DownloadString(url);

            var jsonData = JObject.Parse(result);

            var data = jsonData["items"].ToString().Trim(); ;
            
            var a = JArray.Parse(data);

            foreach (var o in a.Children<JObject>())
            {
                var id = o["id"].ToString().Trim();
                var name = o["name"].ToString().Trim();
   
                Global.Space.BasicSolarSystems.Add(name, id);
            }


            using (var sw = new StreamWriter(@"Data/BasicSolarSystems.csv"))
            {
                var writer = new CsvWriter(sw);

                IEnumerable records = Global.Space.BasicSolarSystems.ToList();

                writer.WriteRecords(records);
            }
        }
    }
}
