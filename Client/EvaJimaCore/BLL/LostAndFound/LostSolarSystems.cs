using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace EveJimaCore.BLL.LostAndFound
{
    public class LostSolarSystems
    {
        private const string LostAndFoundOfficeServer = "http://www.evajima-storage.somee.com";// "http://localhost:51135";
        private const string AddWormholeAddress = "{0}/api/LostAndFound?action={1}&publisher={2}&wormholeName={3}&reward={4}";
        private const string DeleteWormholeAddress = "{0}/api/LostAndFound?action={1}&publisher={2}&wormholeName={3}";
        private const string GetWormholesAddress = "{0}/api/LostAndFound";

        public bool IsLoaded { get; set; }

        public Dictionary<string, LostSolarSystem> List { get; set; }

        public Dictionary<string, LostSolarSystem> Visited { get; set; } 

        public LostSolarSystems()
        {
            IsLoaded = false;

            //Task.Run(() =>
            //{
            //    List = GetDataFromServer();
            //    IsLoaded = true;
            //});

            Visited = new Dictionary<string, LostSolarSystem>();
        }

        public LostSolarSystem WormholeInspection(string solarSystemName)
        {
            foreach (var visitedSolarSystem in Visited.Values)
            {
                if (visitedSolarSystem.Name == solarSystemName)
                {
                    return null;
                }
            }

            foreach (var solarSystem in List.Values)
            {
                if (solarSystem.Name == solarSystemName)
                {
                    Visited.Add(solarSystem.Name, solarSystem);
                    return solarSystem;
                }
            }

            return null;
        }

        private Dictionary<string, LostSolarSystem> GetDataFromServer()
        {
            var url = string.Format(GetWormholesAddress, LostAndFoundOfficeServer);

            List<LostSolarSystem> model = null;
            //var client = new HttpClient();
            //var task = client.GetAsync(url)
            //  .ContinueWith((taskwithresponse) =>
            //  {
            //      var response = taskwithresponse.Result;
            //      var jsonString = response.Content.ReadAsStringAsync();
            //      jsonString.Wait();
            //      model = JsonConvert.DeserializeObject<List<LostSolarSystem>>(jsonString.Result);

            //  });

            //task.Wait();

            return model.ToDictionary(lostSolarSystem => lostSolarSystem.Name);
        }

        public string PublishWormhole(LostSolarSystem wormhole)
        {
            var url = string.Format(AddWormholeAddress, LostAndFoundOfficeServer, "add", wormhole.Publisher, wormhole.Name,wormhole.Reward);

            var message = new WebClient().DownloadString(url);

            List.Add(wormhole.Name, wormhole);

            return message;
        }

        public string RemoveWormhole(LostSolarSystem wormhole)
        {
            var message = "Ooops. Wormhole and publisher not found.";

            LostSolarSystem forRemove = null;

            foreach (var value in List.Values)
            {
                if (value.Name == wormhole.Name && value.Publisher == wormhole.Publisher)
                {
                    forRemove = value;
                }
            }

            if (forRemove != null)
            {
                var url = string.Format(DeleteWormholeAddress, LostAndFoundOfficeServer, "delete", forRemove.Publisher, forRemove.Name);

                message = new WebClient().DownloadString(url);

                List.Remove(forRemove.Name);
            }

            return message;
        }

    }



}
