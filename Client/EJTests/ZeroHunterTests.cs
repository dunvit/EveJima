using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using EveJimaCore;
using EveJimaUniverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Newtonsoft.Json;

namespace EJTests
{
    [TestClass]
    public class ZeroHunterTests
    {
        [TestMethod]
        public void LoadAllGates()
        {
            var esiAPI = new EsiApi("e136434f8a0c484ab802666f378cac09", "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY");

            esiAPI.Refresh("VCajl13JWXZmJoZ0UxVJ4u3AHKh9FaNcb0bQ2mdQkGFfaLRhMrs0hw7_7xUjvJVPy6oHzIridqpUClbAOvBuSQ2");

            var universe = new UniverseEntity();
            universe.Initialization();

            foreach(var system in universe.Systems)
            {
                try
                {
                    var linkedSystem = new LinkedSystem { Name = system.Name, Id = system.Id };

                    var stargates = esiAPI.GetStargates(Convert.ToInt32(system.Id));

                    if(stargates == null) continue;

                    foreach (var stargate in stargates)
                    {
                        var solarSystemId = esiAPI.GetSolarSystemIdByStargate(stargate);

                        linkedSystem.LinkedSystems.Add(solarSystemId);
                    }

                    universe.LinkedSystems.Add(linkedSystem);
                }
                catch(Exception ex)
                {
                    var a = "";
                }
                
            }





            var dataFile = @"C:/Data/LinkedSystems.dat";

            var jsonFormatter = new DataContractJsonSerializer(typeof(List<LinkedSystem>));

            if (File.Exists(dataFile)) File.Delete(dataFile);


            using (var fs = new FileStream(dataFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, universe.LinkedSystems);
            }

            var settingsContentLoad = File.ReadAllText(dataFile);

            //dynamic jsonResponse = JsonConvert.DeserializeObject(settingsContent);

            //var Systems = jsonResponse.Systems;
            //var WormholeTypes = jsonResponse.WormholeTypes;

            var LinkedSystems = new List<LinkedSystem>();

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(settingsContentLoad));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(LinkedSystems.GetType());
            LinkedSystems = ser.ReadObject(ms) as List<LinkedSystem>;
            ms.Close();

        }


        [TestMethod]
        public void TestMethod1()
        {
            var esiAuthorization = new EsiApi("e136434f8a0c484ab802666f378cac09", "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY");

            esiAuthorization.Refresh("VCajl13JWXZmJoZ0UxVJ4u3AHKh9FaNcb0bQ2mdQkGFfaLRhMrs0hw7_7xUjvJVPy6oHzIridqpUClbAOvBuSQ2");

            var data = esiAuthorization.GetCharacterInfo(96205630);

            var stargates = esiAuthorization.GetStargates(30000003);

            Assert.AreEqual(stargates.Count, 4);

            foreach(var stargate in stargates)
            {
                var solarSystemId = esiAuthorization.GetSolarSystemIdByStargate(stargate);
            }

            var space = new UniverseEntity();
            space.Initialization();

            var solarSystemGare = space.GetSystemByName("Gare");

            var solarSystemStacmon = space.GetSystemByName("Stacmon");

            var jumps = esiAuthorization.GetRouteJumps(solarSystemGare.Id, solarSystemStacmon.Id);

            Assert.AreEqual(jumps, 4);

            var solarSystems = GetSystemsList(space, solarSystemGare.Id, 5);

            Assert.AreEqual(solarSystems.Count(), 26);

            var location = esiAuthorization.GetLocation(96205630);

            var bookmarks = esiAuthorization.GetBookmarks(96205630, "0");

        }



        private IEnumerable<string> GetSystemsList(UniverseEntity universeEntity, string solarSystemId, int range)
        {
            var systems = new List<string>();

            GetSystems(universeEntity, solarSystemId, range, 0, systems);

            return systems;
        }

        private void GetSystems(UniverseEntity universeEntity, string solarSystemId, int range, int currentRange, List<string> systems)
        {
            currentRange = currentRange + 1;

            if(currentRange > range) return;

            var linkedSystems = universeEntity.GetLinkedSystems(solarSystemId);

            foreach (var system in linkedSystems.LinkedSystems)
            {
                var linkedSystem = universeEntity.GetSystemById(system);

                if(systems.Contains(linkedSystem.Id) == false)
                {
                    systems.Add(linkedSystem.Id);

                    GetSystems(universeEntity, linkedSystem.Id, range, currentRange, systems);
                }
            }


        }
    }
}
