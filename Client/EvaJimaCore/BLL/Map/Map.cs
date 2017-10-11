using System;
using System.Collections.Generic;
using System.Linq;
using EvaJimaCore;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json;

namespace EveJimaCore.BLL.Map
{
    public class Map
    {
        public event Action<string> OnChangeStatus;

        public MapUpdateHistory History;

        private static readonly ILog Log = LogManager.GetLogger(typeof(Map));
        readonly ILog _commandsLog = LogManager.GetLogger("All");

        public string Key { get; set; }

        private string Owner { get; set; }

        public string ActivePilot { get; set; }

        private long _lastUpdate;

        public DateTime LastUpdateTime { get; private set; }

        public List<EveJimaUniverse.System> Systems { get; set; }

        public List<PilotLocation> Pilotes { get; set; }

        public string SelectedSolarSystemName { get; set; }

        public string LocationSolarSystemName { get; set; }

        public string PreviousLocationSolarSystemName { get; set; }

        public bool IsPublic { get; set; }

        public Map()
        {
            Systems = new List<EveJimaUniverse.System>();

            _lastUpdate = new DateTime(2015,5,5).Ticks;

            
        }

        public void Activate(string owner, string system)
        {
            OnChangeStatus?.Invoke($"[Map.Activate] Start updates for current map '{Key}' for pilot {ActivePilot}");

            ActivePilot = owner;
            SelectedSolarSystemName = system;
            LocationSolarSystemName = system;
        }

        public string GetOwner()
        {
            return Owner;
        }

        public void SetOwner(string owner)
        {
            Owner = owner;
        }

        public EveJimaUniverse.System GetSystem(string name)
        {
            var system = Systems.FirstOrDefault(solarSystem => solarSystem.Name == name);

            if( system == null) return null;

            return system.Region == null ? GetSolarSystemInformation(system) : system;
        }

        private EveJimaUniverse.System GetSolarSystemInformation(EveJimaUniverse.System system)
        {
            try
            {
                var systemInformation = Global.Space.GetSystemByName(system.Name);

                system.Id = systemInformation.Id;
                system.Region = systemInformation.Region;
                system.Class = systemInformation.Class;
                system.Constelation = systemInformation.Constelation;
                system.Effect = systemInformation.Effect;
                system.Moons = systemInformation.Moons;
                system.Planets = systemInformation.Planets;
                system.Security = systemInformation.Security;
                system.Static = systemInformation.Static;
                system.Static2 = systemInformation.Static2;
                system.Sun = systemInformation.Sun;

                return system;
            }
            catch(Exception)
            {

                return system;
            }

            
        }

        public void Reload(string key)
        {
            _lastUpdate = new DateTime(2015, 5, 5).Ticks;
        }

        public void Reset(string key)
        {
            _commandsLog.InfoFormat("[Map.Reset] Reset map with key ='{0}' to key '{2}' for pilot ='{1}'", Key, ActivePilot, key);
            _lastUpdate = new DateTime(2015, 5, 5).Ticks;
            Key = key;

            ApiPublishSolarSystem(ActivePilot, Key, null, LocationSolarSystemName);

            Global.Pilots.Selected.Key = key;
            Global.ApplicationSettings.UpdatePilotInStorage(Global.Pilots.Selected.Name, Global.Pilots.Selected.Id.ToString(), Global.Pilots.Selected.EsiData.RefreshToken, Key);
        }

        public MapUpdateHistory ApiPublishSolarSystem(string pilotName, string key, string systemFrom, string systemTo)
        {
            OnChangeStatus?.Invoke($"[Map.ApiPublishSolarSystem] Start Publish Solar System for map '{Key}' with pilot '{pilotName}'. Relocated from '{systemFrom}' to '{systemTo}'");

            var result = Global.MapApiFunctions.PublishSolarSystem(this, pilotName, Key, systemFrom, systemTo, _lastUpdate);

            return result;
        }

        public MapUpdateHistory GetUpdates()
        {
            //Global.MapApiFunctions.UpdateMap(SpaceMap);
            OnChangeStatus?.Invoke($"[Map.Update] Start Update Solar System for map '{Key}' with pilot '{ActivePilot}'.");

            var result = Global.MapApiFunctions.UpdateMap(this);

            return result;
        }

        public MapUpdateHistory ApiDeleteSolarSystem(string key , string solarSystemName, string pilotName)
        {
            OnChangeStatus?.Invoke($"[Map.ApiDeleteSolarSystem] Start Delete Solar System for map '{key}' with pilot '{pilotName}'. Deleted solar system name is '{solarSystemName}'");

            var updatedSystems = Global.MapApiFunctions.DeleteSolarSystem(this, solarSystemName);

            return updatedSystems;
        }

        public MapUpdateHistory ApiDeleteConnectionBeetwenSolarSystems(string solarSystemFrom, string solarSystemTo)
        {
            OnChangeStatus?.Invoke($"[Map.ApiDeleteSolarSystem] For map '{Key}' delete connection beetwen solar systems '{solarSystemFrom}' and '{solarSystemTo}'.");

            var result = Global.MapApiFunctions.DeleteConnectionBetweenSolarSystems(this, ActivePilot, Key, solarSystemFrom, solarSystemTo);

            return result;
        }

        public MapUpdateHistory ApiPublishSignatures(string key, string solarSystemName, string pilotName, List<CosmicSignature> signatures)
        {
            OnChangeStatus?.Invoke($"[Map.ApiPublishSignatures] Start Publish Signatures Solar System '{solarSystemName}' for map '{key}' with pilot '{pilotName}'. signatures count is '{signatures.Count}'");

            var updatedSystems = Global.MapApiFunctions.PublishSignatures(this, pilotName, key, solarSystemName, signatures);

            RemoveSystem(solarSystemName);

            return updatedSystems;
        }

        public long GetLastUpdate()
        {
            return _lastUpdate;
        }

        public void SetLastUpdate(DateTime value)
        {
            _lastUpdate = value.Ticks;

            LastUpdateTime = value;
        }


        public void Publish(string pilotName, string systemFrom, string systemTo)
        {
            ApiPublishSolarSystem(pilotName, Key, systemFrom, systemTo);
        }

        public string GetPilotesBySolarSystem(string name)
        {
            var pilotesInSolarSystem = "";

            foreach ( var pilotLocation in Pilotes )
            {
                if ( pilotLocation.System == name )
                {
                    if ( pilotesInSolarSystem == "" )
                    {
                        pilotesInSolarSystem = pilotLocation.Name;
                    }
                    else
                    {
                        pilotesInSolarSystem = pilotesInSolarSystem + Environment.NewLine + "" + pilotLocation.Name;
                    }
                }
            }

            return pilotesInSolarSystem;
        }

        public void RelocatePilot(string pilotname, string systemfrom, string systemto)
        {
            PreviousLocationSolarSystemName = systemfrom;
            LocationSolarSystemName = systemto;
        }

        public void RemoveSystem(string solarSystem)
        {
            OnChangeStatus?.Invoke($"[Map.RemoveSystem] Check is removed solar system '{solarSystem}' current for selected pilot {Global.Pilots.Selected.Name}...");

            if (solarSystem == LocationSolarSystemName) return;

            //var deletedSystem = GetSystem(solarSystem);

            //deletedSystem.IsDeleted = true;

            SelectedSolarSystemName = LocationSolarSystemName;
        }

        public MapUpdateHistory ApiPublishDeathNotice(string locationSolarSystem)
        {
            var result = Global.MapApiFunctions.DeleteConnectionBetweenSolarSystems(this, ActivePilot, Key, PreviousLocationSolarSystemName, locationSolarSystem);

            OnChangeStatus?.Invoke($"[Map.ApiPublishDeathNotice] End get updates for map '{Key}' after DeathNotice delete connection from system {PreviousLocationSolarSystemName} to system {locationSolarSystem}. Updated {result.UpdatedSystems} solar systems.");

            _commandsLog.InfoFormat("[Map.ApiPublishDeathNotice] For map with key {0} delete connection from system {2} to system {1}", Key, locationSolarSystem, PreviousLocationSolarSystemName);

            return result;
        }

        public Map Clone()
        {
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<Map>(JsonConvert.SerializeObject(this), deserializeSettings);
        }
    }
}
