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

        public List<LinkedSystem>  LinkedSystems = new List<LinkedSystem>();

        public Dictionary<string, WormholeType> WormholeTypes = new Dictionary<string, WormholeType>();

        public Universe()
        {
            
        }

        public void Initialization()
        {
            LoadWormholeTypes();
            LoadSolarSystems();
            LoadLinkedSystems();
        }

        private void LoadLinkedSystems()
        {
            Log.Debug("[SpaceEntity.LoadLinkedSystems] Read file \"Data/LinkedSystems.dat\". ");
            var dataFile = @"Data/LinkedSystems.dat";
            var json = File.ReadAllText(dataFile);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(LinkedSystems.GetType());
            LinkedSystems = ser.ReadObject(ms) as List<LinkedSystem>;
            ms.Close();
            Log.Debug("[SpaceEntity.LoadLinkedSystems] Close ");
        }

        private void LoadSolarSystems()
        {
            Log.Debug("[SpaceEntity.LoadSolarSystems] Read file \"Data/Universe.dat\". ");

            var dataFile = @"Data/Universe.dat";

            var json = File.ReadAllText(dataFile);
            var universeAfterLoad = new Universe();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(universeAfterLoad.GetType());
            universeAfterLoad = ser.ReadObject(ms) as Universe;
            ms.Close();

            Systems = universeAfterLoad.Systems;

            Log.Debug("[SpaceEntity.LoadSolarSystems] Close ");
        }

        public System GetSystemById(string id)
        {
            return Systems.FirstOrDefault(system => system.Id == id);
        }

        public LinkedSystem GetLinkedSystems(string id)
        {
            foreach(var linkedSystem in LinkedSystems)
            {
                if(linkedSystem.Id == id)
                {
                    return linkedSystem;
                }
            }

            return null;
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
            Log.Debug("[SpaceEntity.LoadWormholes] Read file \"Data/Wormholes.dat\". ");

            try
            {
                var json = File.ReadAllText(@"Data/Wormholes.dat");
                Log.Debug("[SpaceEntity.LoadWormholes] json = " + json);
                var WormholeTypesAfterLoad = new Dictionary<string, WormholeType>();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                Log.Debug("[SpaceEntity.LoadWormholes] MemoryStream ");
                var ser = new DataContractJsonSerializer(WormholeTypesAfterLoad.GetType());
                Log.Debug("[SpaceEntity.LoadWormholes] DataContractJsonSerializer ");
                WormholeTypes = ser.ReadObject(ms) as Dictionary<string, WormholeType>;
                Log.Debug("[SpaceEntity.LoadWormholes] ReadObject ");
                ms.Close();
                Log.Debug("[SpaceEntity.LoadWormholes] Close ");
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
