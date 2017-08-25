using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using log4net;

namespace EveJimaUniverse
{
    public class Universe
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Universe));

        public List<System> Systems = new List<System>();

        public Dictionary<string, WormholeType> WormholeTypes = new Dictionary<string, WormholeType>();

        public Universe()
        {
            
        }

        public void Initialization()
        {
            LoadWormholeTypes();
            LoadSolarSystems();
        }

        private void LoadSolarSystems()
        {
            var dataFile = @"Data/Universe.dat";

            var json = File.ReadAllText(dataFile);
            var universeAfterLoad = new Universe();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(universeAfterLoad.GetType());
            universeAfterLoad = ser.ReadObject(ms) as Universe;
            ms.Close();

            Systems = universeAfterLoad.Systems;
        }

        public System GetSystemById(string id)
        {
            return Systems.FirstOrDefault(system => system.Id == id);
        }

        public System GetSystemByName(string name)
        {
            foreach(var system in Systems)
            {
                if(system.Name == name)
                {
                    var a = "";
                }
            }

            return Systems.FirstOrDefault(system => system.Name.ToUpper() == name.ToUpper());
        }

        private void LoadWormholeTypes()
        {
            Log.Debug("[SpaceEntity.LoadWormholes] Read csv file \"Data/WSpaceSystemInfo - Wormholes.csv\". ");

            try
            {
                var json = File.ReadAllText(@"Data/Wormholes.dat");
                var WormholeTypesAfterLoad = new Dictionary<string, WormholeType>();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                var ser = new DataContractJsonSerializer(WormholeTypesAfterLoad.GetType());
                WormholeTypes = ser.ReadObject(ms) as Dictionary<string, WormholeType>;
                ms.Close();

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadWormholes] Critical error = {0}", ex);
            }
        }

        public string GetTitle(System solarSystem)
        {
            var title = solarSystem.Name + "";

            if (string.IsNullOrEmpty(solarSystem.Class) == false)
            {
                title = title + "[C" + solarSystem.Class + "]";
            }

            if (string.IsNullOrEmpty(solarSystem.Static) == false)
            {
                var wormholeI = WormholeTypes[solarSystem.Static.Trim()];

                title = title + " " + wormholeI.Name + "[" + wormholeI.LeadsTo + "]";
            }

            if (string.IsNullOrEmpty(solarSystem.Static2) == false)
            {
                var wormholeII = WormholeTypes[solarSystem.Static2.Trim()];

                title = title + " " + wormholeII.Name + "[" + wormholeII.LeadsTo + "]";
            }

            return title;
        }
    }
}
