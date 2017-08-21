using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using EveJimaUniverse;
using log4net;
using Newtonsoft.Json;

namespace EveJimaServerMap
{
    public class Router
    {
        readonly ILog _log = LogManager.GetLogger("All");

        public Server Server { get; set; }

        public Router(string type)
        {
            switch(type)
            {
                case "server":
                    Server = new Server(MapType.Server);
                    break;

                case "client":
                    Server = new Server(MapType.Client);
                    break;
            }
        }

        public string DeleteSignature(string pilotName, string key, string system, string code, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var dtTime = new DateTime(ticks);

                var map = Server.GetMap(key, pilotName);

                map.DeleteSignature(system, code);

                _log.InfoFormat("[DeleteSignature] For map with key {0} system {1} signature code {2}", key, system, code);

                map.Save();

                return Server.BuildUpdateString(key, pilotName, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[DeleteSignature] Critical error with map key {0} system {2} exception {1}", key, ex, system);
                return "Failure";
            }

        }

        public string DeleteSolarSystem(string mapKey, string system, string pilotName, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var dtTime = new DateTime(ticks);

                var map = Server.GetMap(mapKey, pilotName);

                map.DeleteSolarSystem(system);

                _log.InfoFormat("[DeleteSolarSystem] Delete solar system {1} on map with key {0} ", mapKey, system);

                return Server.BuildUpdateString(mapKey, pilotName, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[DeleteSolarSystem] Delete solar system {2} on map with key {0} exception {1}", mapKey, ex, system);
                return "Failure";
            }
        }

        public string GetAllUpdates(string mapKey, string pilot, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                return Server.BuildUpdateString(mapKey, pilot, ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[GetUpdatedSystems] Get updates (systems) with key {0} ticks {2} exception {1}", mapKey, ex, ticks);
                return "Failure";
            }
        }


        //DeathNotice
        public string DeathNotice(string mapKey, string pilot, string systemFrom, string systemTo, long ticks)
        {
            var dtTime = new DateTime(ticks);

            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var map = Server.GetMap(mapKey, pilot, systemFrom, systemTo);

                map.DeleteSolarSystemConnection(systemTo, systemFrom);

                return Server.BuildUpdateString(mapKey, pilot, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[DeathNotice] Death notice with key {0} systemFrom {2} systemTo {3} exception {1}", mapKey, ex, systemFrom, systemTo);
                return "Failure";
            }
        }

        public string PublishSolarSystem(string pilot, string mapKey, string systemFrom, string systemTo, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var dtTime = new DateTime(ticks);

                // First login to EveJima
                if ( string.IsNullOrEmpty(systemFrom) )
                {
                    Server.RelocatePilot(mapKey, pilot, systemTo);
                }

                _log.InfoFormat("[PublishSolarSystem] Relocate pilot '{3}' system with key '{0}' from '{1}' to '{2}' ", mapKey, systemFrom, systemTo, pilot);

                var map = Server.GetMap(mapKey, pilot, systemFrom, systemTo);

                map.AddSolarSystem(systemFrom, systemTo);

                _log.InfoFormat("[PublishSolarSystem] Publish system with key {0} from {1} to {2} for pilot {3}", mapKey, systemFrom, systemTo, pilot);

                Server.RelocatePilot(mapKey, pilot, systemTo);

                if (string.IsNullOrEmpty(systemFrom)) dtTime = new DateTime(2015, 5, 5);

                return Server.BuildUpdateString(mapKey, pilot, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[PublishSolarSystem] Publish system with key {0} from {1} to {2} exception {3}", mapKey, systemFrom, systemTo, ex);
                return "Failure";
            }

        }

        public string PublishSignatures(string pilotName, string key, string system, string signatures, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var dtTime = new DateTime(ticks);

                var map = Server.GetMap(key, pilotName);

                var listSignatures = JsonConvert.DeserializeObject<List<CosmicSignature>>(signatures);

                map.UpdateSignatures(system, listSignatures);

                _log.InfoFormat("[PublishSignatures] For map with key {0} system {1} ", key, system);

                map.Save();

                var updatedSystems = map.GetUpdates(dtTime);

                _log.InfoFormat("[PublishSignatures] Get updated systems after publish system with key {0} for {1} for pilot {2}. Count updated systems is {3}", key, system, pilotName, updatedSystems.Count);

                return Server.BuildUpdateString(key, pilotName, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[PublishSignatures] Critical error with map key {0} system {2} exception {1}", key, ex, system);
                return "Failure";
            }
        }

        public string UpdateSolarSystemCoordinates(string mapKey, string system, string pilot, int positionX, int positionY, long ticks)
        {
            //_log.InfoFormat(HttpContext.Current.Request.Url.ToString());

            try
            {
                var dtTime = new DateTime(ticks);

                var map = Server.GetMap(mapKey, pilot);

                var solarSystem = map.GetSystem(system);

                solarSystem.LocationInMap = new Point(positionX, positionY);

                _log.InfoFormat("[UpdateSolarSystemCoordinates] For map with key {0} system {2} set oordinates {1}", mapKey, positionX + ":" + positionY, system);

                map.Save();

                return Server.BuildUpdateString(mapKey, pilot, dtTime.Ticks);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("[UpdateSolarSystemCoordinates] Load map with key {0} system {2} exception {1}", mapKey, ex, system);
                return "Failure";
            }
        }
    }
}
