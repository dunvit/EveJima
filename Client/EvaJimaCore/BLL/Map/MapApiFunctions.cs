using System;
using System.Collections.Generic;
using System.Net;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json;

namespace EveJimaCore.BLL.Map
{
    public class MapApiFunctions
    {
        public EveJimaServerMap.Router MapRouter { get; set; }

        private static readonly ILog Log = LogManager.GetLogger(typeof(MapApiFunctions));

        readonly ILog _commandsLog = LogManager.GetLogger("CommandsMap");
        readonly ILog _errorsLog = LogManager.GetLogger("Errors");
        readonly ILog _apiCallsLog = LogManager.GetLogger("ApiCalls");

        private object _mylock = new object();

        private string _mapServerAddress = "";//"http://www.evajima-maps.somee.com";// "http://localhost:51135"; //

        public void Initialization(string mapServerAddress)
        {
            _mapServerAddress = mapServerAddress;

            MapRouter = new EveJimaServerMap.Router("client");
        }

        public MapUpdateHistory UpdateMap(Map map)
        {
            Log.DebugFormat($"[MapApiFunctions.UpdateMap] start for '{map.ActivePilot}' and map '{map.Key}'");

            lock (_mylock)
            {
                try
                {
                    var result = Update(map, map.Key, map.ActivePilot, map.GetLastUpdate());

                    return PrapairData(map, result);
                }
                catch(Exception ex)
                {
                    Log.ErrorFormat("[MapApiFunctions.UpdateMap] Critical error. Exception is {0}", ex);
                }

                MapUpdateHistory historyFailure;

                historyFailure.UpdatedSystems = 0;
                historyFailure.DeletedSustems = 0;
                historyFailure.Pilots = 0;
                historyFailure.UpdateTime = DateTime.UtcNow;

                return historyFailure;
            }
        }

        private MapUpdateHistory PrapairData(Map map, string result)
        {
            dynamic deserialized = JsonConvert.DeserializeObject(result, typeof(object));

            Log.DebugFormat($"[MapApiFunctions.PrapairData] Get updates for '{map.ActivePilot}' and map '{map.Key}' {deserialized.ToString()}");

            map.SetOwner(deserialized.Owner.ToString());

            List<EveJimaUniverse.System> updatedSystems = JsonConvert.DeserializeObject<List<EveJimaUniverse.System>>(deserialized.SystemsUpdated.ToString()) as List<EveJimaUniverse.System>;

            List<EveJimaUniverse.System> deletedSystems = JsonConvert.DeserializeObject<List<EveJimaUniverse.System>>(deserialized.SystemsDeleted.ToString()) as List<EveJimaUniverse.System>;

            List<PilotLocation> updatedPilots = JsonConvert.DeserializeObject<List<PilotLocation>>(deserialized.Pilots.ToString()) as List<PilotLocation>;

            MapTools.UpdateSolarSystems(map, updatedSystems);

            MapTools.DeleteSolarSystems(map, deletedSystems);

            MapTools.RefreshPilots(map, updatedPilots);

            if(updatedSystems.Count > 0 ) MapTools.HideUnconnectedSystems(map);

            var lastUpdate = new DateTime(long.Parse(deserialized.UpdateTime.ToString()));

            map.SetLastUpdate(lastUpdate);

            MapUpdateHistory history;
            history.UpdatedSystems = updatedSystems.Count;
            history.DeletedSustems = deletedSystems.Count;
            history.Pilots = updatedPilots.Count;
            history.UpdateTime = new DateTime(lastUpdate.Ticks);

            return history;
        }

        private string Update(Map map, string key, string pilot, long delta)
        {
            Log.DebugFormat($"[MapApiFunctions.Update] start for '{pilot}' and map '{key}'");

            var address = _mapServerAddress + "/api/MapUpdates?mapKey=" + key + "&pilot=" + pilot + "&ticks=" + delta + "";

            _apiCallsLog.Info(address);

            using (var client = new WebClient())
            {
                string dataVerification;

                if (map.IsPublic)
                {
                    dataVerification = client.DownloadString(address);
                }
                else
                {
                    dataVerification = MapRouter.GetAllUpdates(key, pilot, delta);
                }

                Log.DebugFormat($"[MapApiFunctions.Update] end for '{pilot}' and map '{key}'");

                var updatedData =JsonConvert.DeserializeObject(dataVerification).ToString();

                return updatedData;
                //return JsonConvert.DeserializeObject<List<SolarSystem>>(JsonConvert.DeserializeObject(dataVerification).ToString());
            }
        }



        public MapUpdateHistory PublishSolarSystem(Map map, string pilotName, string key, string systemFrom, string systemTo, long delta)
        {
            Log.DebugFormat("[MapApiFunctions.PublishSolarSystem] start");

            var address = _mapServerAddress + "/api/PublishSolarSystem?pilot=" + pilotName + "&mapKey=" + key + "&systemFrom=" + systemFrom + "&systemTo=" + systemTo + "&ticks=" + delta + "";

            _apiCallsLog.Info(address);

            try
            {
                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.PublishSolarSystem(pilotName, key, systemFrom, systemTo, delta);
                    }

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.Debug($"[MapApiFunctions.PublishSolarSystem] end. Responce:\n\r {updatedData} \r\n for time {new DateTime(delta).ToLongTimeString()}");

                    return PrapairData(map, updatedData);
                }
            }
            catch(Exception ex)
            {
                _errorsLog.ErrorFormat("[.PublishSolarSystem] Critical error. Address '{0}' Exception {1}", address, ex);
            }

            MapUpdateHistory historyFailure;

            historyFailure.UpdatedSystems = 0;
            historyFailure.DeletedSustems = 0;
            historyFailure.Pilots = 0;
            historyFailure.UpdateTime = DateTime.UtcNow;

            return historyFailure;
        }

        public MapUpdateHistory UpdateSolarSystemCoordinates(Map map, string key, string system, string pilot, int positionX, int positionY, long delta)
        {
            Log.DebugFormat("[MapApiFunctions.UpdateSolarSystemCoordinates] start");

            try
            {
                var address = _mapServerAddress + "/api/UpdateSolarSystemCoordinates?mapKey=" + key + "&system=" + system + "&pilot=" + pilot + "&positionX=" + positionX + "&positionY=" + positionY + "&ticks=" + delta + "";

                _apiCallsLog.Info(address);

                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.UpdateSolarSystemCoordinates( key, system, pilot, positionX, positionY, delta);
                    }

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    _commandsLog.DebugFormat("[MapApiFunctions.UpdateSolarSystemCoordinates] Change solar system coordinates complete. Point = {0} SolarSystemName = {1} ", system, key);

                    Log.DebugFormat("[MapApiFunctions.UpdateSolarSystemCoordinates] end");

                    return PrapairData(map, updatedData);
                }
            }
            catch (Exception ex)
            {
                _errorsLog.ErrorFormat("[MapApiFunctions.UpdateSolarSystemCoordinates] Point = {1} SolarSystemName = {2} Critical error {0}", ex, system, key);
            }

            MapUpdateHistory historyFailure;

            historyFailure.UpdatedSystems = 0;
            historyFailure.DeletedSustems = 0;
            historyFailure.Pilots = 0;
            historyFailure.UpdateTime = DateTime.UtcNow;

            return historyFailure;
        }

        public MapUpdateHistory DeleteSolarSystem(Map map, string system)
        {
            Log.DebugFormat($"[MapApiFunctions.DeleteSolarSystem] start for system {system}");

            try
            {
                var address = _mapServerAddress + "/api/DeleteSolarSystem?mapKey=" + map.Key + "&system=" + system + "&pilotName=" + map.ActivePilot + "&ticks=" + map.GetLastUpdate() + "";

                _apiCallsLog.Info(address);

                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.DeleteSolarSystem(map.Key, system, map.ActivePilot, map.GetLastUpdate());
                    }

                    _commandsLog.InfoFormat("[Map.DeleteSolarSystem] Delete Solar System {2} with map key ='{0}' for pilot ='{1}'", map.Key, map.ActivePilot, system);

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.DebugFormat($"[MapApiFunctions.DeleteSolarSystem] end  for system {system}");

                    return PrapairData(map, updatedData);
                }
            }
            catch(Exception ex)
            {
                _commandsLog.ErrorFormat("[Map.DeleteSolarSystem] Critical error - Delete Solar System {2} with map key ='{0}' for pilot ='{1}' Exception {3}", map.Key, map.ActivePilot, system, ex);

                MapUpdateHistory historyFailure;

                historyFailure.UpdatedSystems = 0;
                historyFailure.DeletedSustems = 0;
                historyFailure.Pilots = 0;
                historyFailure.UpdateTime = DateTime.UtcNow;

                return historyFailure;
            }
            
        }


        public MapUpdateHistory PublishDeadLetter(Map map, string mapKey, string pilot, string systemFrom, string systemTo)
        {
            Log.DebugFormat("[MapApiFunctions.PublishDeadLetter] start");

            try
            {
                var address = _mapServerAddress + "/api/Signatures?mapKey=" + mapKey + "&pilot=" + pilot + "&systemFrom=" + systemFrom + "&systemTo=" + systemTo + "&ticks=" + map.GetLastUpdate() + "";

                _apiCallsLog.Info(address);

                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.DeathNotice(map.Key, map.ActivePilot, systemFrom, systemTo, map.GetLastUpdate());
                    }

                    _commandsLog.InfoFormat("[MapApiFunctions.PublishDeadLetter] PublishDeadLetter in system {2}, previous syste, {3} with map key ='{0}' for pilot ='{1}'", mapKey, pilot, systemTo, systemFrom);

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.DebugFormat("[MapApiFunctions.PublishDeadLetter] end");

                    return PrapairData(map, updatedData);
                }
            }
            catch (Exception ex)
            {
                _errorsLog.ErrorFormat("[MapApiFunctions.PublishDeadLetter] PublishDeadLetter in system {2}, previous syste, {3} with map key ='{0}' for pilot ='{1}' exception is {4}", mapKey, pilot, systemTo, systemFrom, ex);

                MapUpdateHistory historyFailure;

                historyFailure.UpdatedSystems = 0;
                historyFailure.DeletedSustems = 0;
                historyFailure.Pilots = 0;
                historyFailure.UpdateTime = DateTime.UtcNow;

                return historyFailure;
            }
        }

        public MapUpdateHistory PublishSignatures(Map map, string pilotName, string key, string system, List<CosmicSignature> signatures)
        {
            Log.DebugFormat("[MapApiFunctions.PublishSignatures] start");

            try
            {
                var signaturesJson = JsonConvert.SerializeObject(signatures, Formatting.Indented);

                var address = _mapServerAddress + "/api/PublishSignatures?pilotName=" + pilotName + "&key=" + key + "&system=" + system + "&signatures=" + signaturesJson + "&ticks=" + map.GetLastUpdate() + ""; ;

                _apiCallsLog.Info(address);

                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.PublishSignatures(map.ActivePilot,map.Key,  system, signaturesJson, map.GetLastUpdate());
                    }

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.DebugFormat("[MapApiFunctions.PublishSignatures] end");

                    return PrapairData(map, updatedData);
                }
            }
            catch(Exception ex)
            {
                _errorsLog.ErrorFormat("[MapApiFunctions.PublishSignatures] MapKey = {3} SolarSystemName = {2} Signatures = {1}  Critical error {0}", ex, signatures, system, key);
            }

            MapUpdateHistory historyFailure;

            historyFailure.UpdatedSystems = 0;
            historyFailure.DeletedSustems = 0;
            historyFailure.Pilots = 0;
            historyFailure.UpdateTime = DateTime.UtcNow;

            return historyFailure;
        }

        public MapUpdateHistory DeleteSignature(Map map, string pilotName, string key, string system, string code)
        {
            Log.DebugFormat("[MapApiFunctions.DeleteSignature] start");

            try
            {
                var address = _mapServerAddress + "/api/DeleteSignature?pilotName=" + pilotName + "&key=" + key + "&system=" + system + "&code=" + code + "&ticks=" + map.GetLastUpdate() + ""; ;

                _apiCallsLog.Info(address);

                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.DeleteSignature(map.ActivePilot, map.Key, system, code, map.GetLastUpdate());
                    }

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.DebugFormat("[MapApiFunctions.DeleteSignature] end");

                    return PrapairData(map, updatedData);
                }
            }
            catch(Exception ex)
            {
                MapUpdateHistory historyFailure;

                historyFailure.UpdatedSystems = 0;
                historyFailure.DeletedSustems = 0;
                historyFailure.Pilots = 0;
                historyFailure.UpdateTime = DateTime.UtcNow;

                return historyFailure;
            }
        }

        public MapUpdateHistory DeleteConnectionBetweenSolarSystems(Map map, string pilotName, string key, string systemFrom, string systemTo)
        {
            Log.DebugFormat("[MapApiFunctions.DeleteConnectionBetweenSolarSystems] start");

            var address = _mapServerAddress + "/api/DeathNotice?mapKey=" + key + "&pilot=" + pilotName + "&solarSystemFrom=" + systemFrom + "&solarSystemTo=" + systemTo + "&ticks=" + map.GetLastUpdate() + ""; ;

            _apiCallsLog.Info(address);

            try
            {
                using (var client = new WebClient())
                {
                    string dataVerification;

                    if (map.IsPublic)
                    {
                        dataVerification = client.DownloadString(address);
                    }
                    else
                    {
                        dataVerification = MapRouter.DeathNotice(map.Key, map.ActivePilot,  systemFrom, systemTo, map.GetLastUpdate());
                    }

                    var updatedData = JsonConvert.DeserializeObject(dataVerification).ToString();

                    Log.DebugFormat("[MapApiFunctions.DeleteConnectionBetweenSolarSystems] end");

                    return PrapairData(map, updatedData);
                }
            }
            catch (Exception ex)
            {
                _errorsLog.ErrorFormat("[MapApiFunctions.DeleteConnectionBetweenSolarSystems] MapKey = {3} systemFrom = {2} systemTo = {1}  Critical error {0}", ex, systemTo, systemFrom, key);
            }

            MapUpdateHistory historyFailure;

            historyFailure.UpdatedSystems = 0;
            historyFailure.DeletedSustems = 0;
            historyFailure.Pilots = 0;
            historyFailure.UpdateTime = DateTime.UtcNow;

            return historyFailure;
        }
    }
}
