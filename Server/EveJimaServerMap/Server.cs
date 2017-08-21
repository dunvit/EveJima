using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json;

namespace EveJimaServerMap
{
    public class Server
    {
        public List<string> Messages = new List<string>();
        public List<Map> Maps = new List<Map>();
        public List<PilotLocation> Pilots = new List<PilotLocation>();

        private readonly MapType type;

        public Server(MapType type)
        {
            this.type = type;
        }

        public string BuildUpdateString(string mapKey, string pilot, long ticks)
        {
            var dtTime = new DateTime(ticks);

            var map = GetMap(mapKey, pilot);

            var updatedSystems = map.GetUpdates(dtTime);

            var deletedSystems = map.GetDeleted(dtTime);

            var updatedPilots = GetPilotes(mapKey, dtTime);

            dynamic genericUpdateData = new ExpandoObject();

            genericUpdateData.Owner = map.Information.Owner;

            genericUpdateData.SystemsUpdated = updatedSystems;

            genericUpdateData.SystemsDeleted = deletedSystems;

            genericUpdateData.Pilots = updatedPilots;

            genericUpdateData.UpdateTime = DateTime.UtcNow.Ticks;

            return JsonConvert.SerializeObject(genericUpdateData);
        }

        public Map GetMap(string key, string pilotName, string systemFrom, string systemTo)
        {
            var map = GetMapByKey(key);

            if (map == null) return CreateMap(key, pilotName);

            if(map.Systems.Count == 0) return map;

            if(map.IsSystemConnectedToMap(systemFrom)) return map;
            
            if (map.IsSystemConnectedToMap(systemTo)) return MapsMergePostProcessing(map, pilotName, systemTo, systemFrom);

            if (map.IsSystemConnectedToMap(systemFrom)) return MapsMergePostProcessing(map, pilotName, systemFrom, systemFrom);

            var pilotMapKey = key + "_" + pilotName.Replace(" ", "_").Replace("-", "_");

            map = GetMapByKey(pilotMapKey);

            return map ?? CreateMap(pilotMapKey, pilotName);
        }

        private Map MapsMergePostProcessing(Map map, string pilotName, string connectedMapsSystem, string systemFrom)
        {
            var pilotMapKey = map.Information.Key + "_" + pilotName.Replace(" ", "_").Replace("-", "_");

            var localMap = GetMapByKey(pilotMapKey);

            if (localMap == null) return map;

            localMap.AddSolarSystem(systemFrom, connectedMapsSystem);

            var connectedSystem = localMap.GetSystem(connectedMapsSystem);

            mergedSystems = new List<string>();

            MapsMergeAddSystem(map, localMap, connectedSystem);

            map.Save();

            var itemToRemove = Maps.Single(r => r.Information.Key == pilotMapKey);
            Maps.Remove(itemToRemove);

            localMap.Delete();

            foreach (var solarSystem in map.Systems)
            {
                solarSystem.Value.LastUpdate = DateTime.UtcNow;
            }

            return map;
        }

        private List<string> mergedSystems; 

        private void MapsMergeAddSystem(Map map, Map localMap, EveJimaUniverse.System system)
        {
            foreach(var connection in system.ConnectedSolarSystems)
            {
                var connectedSystem = localMap.GetSystem(connection);

                if(mergedSystems.Contains(connection) == false)
                {
                    mergedSystems.Add(connection);
                    
                    map.AddSolarSystem(system.Name, connectedSystem.Name, false);

                    MapsMergeAddSystem(map, localMap, connectedSystem);
                }
                
            }
        }

        private Map GetMapByKey(string key)
        {
            return Maps.FirstOrDefault(spaceMap => spaceMap.Information.Key == key);
        }

        private Map CreateMap(string key, string pilotName)
        {
            var map = new Map();
            map.Initialization(key, type);
            map.Information.Owner = pilotName;

            AddMap(map);

            return map;
        }

        public string GetMapOwner(string key)
        {
            foreach (var spaceMap in Maps.Where(spaceMap => spaceMap.Information.Key == key))
            {
                return spaceMap.Information.Owner;
            }

            return "";
        }

        public Map GetMap(string key, string pilotName)
        {
            foreach (var spaceMap in Maps)
            {
                if (spaceMap.Information.Key == key)
                {

                    var location = Pilots.Find(x => x.MapKey == key && x.Name == pilotName);

                    if(location == null) continue;

                    if (spaceMap.IsSystemConnectedToMap(location.System))
                    {

                        return spaceMap;
                    }

                    var localMapKey = key + "_" + pilotName.Replace(" ", "_").Replace("-", "_");

                    foreach (var spaceMapLocal in Maps)
                    {
                        if (spaceMapLocal.Information.Key == localMapKey)
                        {
                            return spaceMapLocal;
                        }
                    }

                    return CreateMap(localMapKey, pilotName);
                }
            }

            return CreateMap(key, pilotName);
        }

        public void AddMap(Map map)
        {
            Maps.Add(map);
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public void RelocatePilot(string key, string pilot, string system)
        {
            try
            {
                var isExist = false;

                foreach (var pilotLocation in Pilots)
                {
                    if (pilotLocation.Name != pilot) continue;

                    isExist = true;
                    pilotLocation.MapKey = key;
                    pilotLocation.System = system;
                    pilotLocation.LastUpdate = DateTime.UtcNow;
                }

                if (isExist == false)
                {
                    Pilots.Add(new PilotLocation { MapKey = key, Name = pilot, System = system, LastUpdate = DateTime.UtcNow });
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("All").ErrorFormat("[RelocatePilot] Critical error map with key {0} exception {1}", key, ex);
            }

        }

        public List<PilotLocation> GetPilotes(string mapKey, DateTime lastUpdate)
        {
            var list = new List<PilotLocation>();

            foreach (var solarSystem in Pilots)
            {
                if (solarSystem.MapKey == mapKey) //solarSystem.LastUpdate > lastUpdate && 
                {
                    try
                    {
                        list.Add(solarSystem);
                    }
                    catch (Exception ex)
                    {
                        LogManager.GetLogger("All").ErrorFormat("[GetPilotes] Critical error map with key {0} exception {1}", mapKey, ex);
                    }
                }
            }

            return list;
        }

        
    }
}
