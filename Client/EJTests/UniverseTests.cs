using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using CsvHelper;
using EveJimaCore;
using EveJimaUniverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class UniverseTests
    {
        [TestMethod]
        public void Universe_LoadNames()
        {
            var universe = new Universe();

            var data = Infrastructure.GetSolarSystems();

            foreach(var system in data)
            {
                universe.Systems.Add(new EveJimaUniverse.System {Name = system.Key, Id = system.Value});
            }

            //LoadWSpaceSystemInfoSystems(universe, @"Data/WSpaceSystemInfo - Systems.csv");
            //LoadBaseSystemInfoSystems(universe, @"Data/WSpaceSystemInfo - Base Solar Systems.csv");

            var dataFile = @"C:/Data/Universe.dat";

            var jsonFormatter = new DataContractJsonSerializer(typeof(Universe));

            if (File.Exists(dataFile)) File.Delete(dataFile);

            using (var fs = new FileStream(dataFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, universe);
            }

            var json = File.ReadAllText(dataFile);
            var universeAfterLoad = new Universe();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(universeAfterLoad.GetType());
            universeAfterLoad = ser.ReadObject(ms) as Universe;
            ms.Close();

            Assert.IsTrue(universe.Systems.Count == universeAfterLoad.Systems.Count);

        }

        //WSpaceSystemInfo - Base Solar Systems.csv
        private static void LoadWSpaceSystemInfoSystems( Universe universe, string fileName)
        {
            //using (var sr = new StreamReader(fileName))
            //{
            //    var records = new CsvReader(sr).GetRecords<StarSystem>();

            //    foreach (var record in records)
            //    {
            //        var system = universe.GetSystemById(record.Id);

            //        if(system == null)
            //        {
            //            system = universe.GetSystemByName(record.SolarSystemName);
            //        }

            //        if (system == null) continue;

            //        system.Class = record.Class;
            //        system.Constelation = record.Constelation;
            //        system.Effect = record.Effect;
            //        system.Moons = record.Moons;
            //        system.Planets = record.Planets;
            //        system.Region = record.Region;
            //        system.Static = record.Static;
            //        system.Static2 = record.Static2;
            //        system.Sun = record.Sun;
            //        system.Security = SecurityStatus.WSpace;
            //    }
            //}

        }

        //private static void LoadBaseSystemInfoSystems(Universe universe, string fileName)
        //{
        //    using (var sr = new StreamReader(fileName))
        //    {
        //        var records = new CsvReader(sr).GetRecords<BaseSolarSystem>();

        //        foreach (var record in records)
        //        {
        //            var system = universe.GetSystemByName(record.System);

        //            if (system == null) continue;

        //            system.Region = record.Region;

        //            system.Security = Tools.GetStatus(record.SecurityRating);
        //        }
        //    }

        //}

        [TestMethod]
        public void LoadWormholesData()
        {
            Dictionary<string, WormholeType> WormholeTypes = new Dictionary<string, WormholeType>();

            using (var sr = new StreamReader(@"C:/Data/WSpaceSystemInfo - Wormholes.csv"))
            {
                var records = new CsvReader(sr).GetRecords<WormholeType>();

                foreach (var record in records)
                {
                    WormholeTypes.Add(record.Name.Trim(), record);
                }
            }

            var dataFile = @"C:/Data/Wormholes.dat";

            var jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, WormholeType>));

            if (File.Exists(dataFile)) File.Delete(dataFile);

            using (var fs = new FileStream(dataFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, WormholeTypes);
            }

            var json = File.ReadAllText(dataFile);
            var WormholeTypesAfterLoad = new Dictionary<string, WormholeType>();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(WormholeTypesAfterLoad.GetType());
            WormholeTypesAfterLoad = ser.ReadObject(ms) as Dictionary<string, WormholeType>;
            ms.Close();

        }
    }
}
