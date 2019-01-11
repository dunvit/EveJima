using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using log4net;
using Newtonsoft.Json;

namespace EveJimaUniverse
{
    public class UniverseEntity
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UniverseEntity));

        public List<System> Systems = new List<System>();

        public List<LinkedSystem>  LinkedSystems = new List<LinkedSystem>();

        public Dictionary<string, WormholeType> WormholeTypes = new Dictionary<string, WormholeType>();

        public UniverseEntity()
        {
            
        }

        public void Initialization()
        {
            try
            {
                LoadWormholeTypes();
                LoadSolarSystems();
                LoadLinkedSystems();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.Initialization] Critical error = {0}", ex);
            }

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

        private void LoadLinkedSystemsFromFile()
        {
            Log.Debug("[SpaceEntity.LoadLinkedSystemsFromFile] Read file \"Data/LinkedSystems.dat\". ");
            var dataFile = @"Data/LinkedSystems.dat";
            var json = File.ReadAllText(dataFile);

            LinkedSystems = JsonConvert.DeserializeObject<List<LinkedSystem>>(json);

            Log.Debug("[SpaceEntity.LoadLinkedSystemsFromFile] Close ");
        }

        private void LoadSolarSystems()
        {
            try
            {
                Log.Debug("[SpaceEntity.LoadSolarSystems] Read file \"Data/Universe.dat\". ");

                var dataFile = @"Data/Universe.dat";

                var json = File.ReadAllText(dataFile);
                var universeAfterLoad = new UniverseEntity();

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                var ser = new DataContractJsonSerializer(universeAfterLoad.GetType());
                universeAfterLoad = ser.ReadObject(ms) as UniverseEntity;
                ms.Close();

                Systems = universeAfterLoad.Systems;

                Log.Debug("[SpaceEntity.LoadSolarSystems] Close ");
            }
            catch(Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadSolarSystems] Critical error = {0}", ex.Message);
                LoadSolarSystemsFromFile();
            }
            
        }

        private void LoadSolarSystemsFromFile()
        {
            Log.Debug("[SpaceEntity.LoadSolarSystemsFromFile] Read file \"Data/Universe.dat\". ");

            var dataFile = @"Data/Universe.dat";

            var json = File.ReadAllText(dataFile);

            var universeAfterLoad = JsonConvert.DeserializeObject<UniverseEntity>(json);

            Systems = universeAfterLoad.Systems;

            Log.Debug("[SpaceEntity.LoadSolarSystemsFromFile] Close ");
        }

        public System GetSystemById(string id)
        {
            return Systems.FirstOrDefault(system => system.Id == id);
        }

        public LinkedSystem GetLinkedSystems(string id)
        {
            return LinkedSystems.FirstOrDefault(linkedSystem => linkedSystem.Id == id);
        }

        public System GetSystemByName(string name)
        {
            return Systems.FirstOrDefault(system => system.Name.ToUpper() == name.ToUpper());
        }

        private void LoadWormholeTypes()
        {
            try
            {
                Log.Debug("[SpaceEntity.LoadWormholes] Read file \"Data/Wormholes.dat\". ");


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
            catch(Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadWormholeTypes] Critical error = {0}", ex.Message);

                LoadWormholeTypesFromFile();
            }
        }

        private void LoadWormholeTypesFromFile()
        {
            Log.Debug("[SpaceEntity.LoadWormholeTypesFromFile] Read file \"Data/Wormholes.dat\". ");


            var json = File.ReadAllText(@"Data/Wormholes.dat");

            Log.Debug("[SpaceEntity.LoadWormholeTypesFromFile] json = " + json);

            WormholeTypes = JsonConvert.DeserializeObject<Dictionary<string, WormholeType>>(json);

            Log.Debug("[SpaceEntity.LoadWormholeTypesFromFile] Close ");

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
