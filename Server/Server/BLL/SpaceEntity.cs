using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using CsvHelper;
using EveJimaUniverse;

namespace Server.BLL
{
    public class SpaceEntity
    {
        public readonly Dictionary<string, WormholeEntity> WormholeTypes = new Dictionary<string, WormholeEntity>();

        public readonly Dictionary<string, StarSystemEntity> SolarSystems = new Dictionary<string, StarSystemEntity>();

        public readonly Dictionary<string, string> BasicSolarSystems = new Dictionary<string, string>();

        public SpaceEntity()
        {
            

            LoadEmpireSolarSystems();

            LoadWormholeTypes();

            LoadWormholeStarSystems();

            LoadSolarSystemsIDs();
        }

        public StarSystemEntity GetSolarSystem(string systemName)
        {
            if (SolarSystems.ContainsKey(systemName))
            {
                var location = SolarSystems[systemName];

                return location.Clone() as StarSystemEntity;
            }

            return new StarSystemEntity { Id = "-1", SolarSystemName = systemName };
        }

        public StarSystemEntity SolarSystem(string systemName)
        {
            if (SolarSystems.ContainsKey(systemName))
            {
                return SolarSystems[systemName];
            }

            return new StarSystemEntity { Id = "-1", SolarSystemName = systemName };
        }

        private void LoadEmpireSolarSystems()
        {

            try
            {
                var dataFile = HttpContext.Current.Server.MapPath("~/Data/WSpaceSystemInfo - Base Solar Systems.csv");

                using (var sr = new StreamReader(dataFile))
                {
                    var records = new CsvReader(sr).GetRecords<BaseSolarSystem>();

                    foreach (var record in records)
                    {
                        var solarSystem = new StarSystemEntity
                        {
                            SolarSystemName = record.System,
                            Class = null,
                            ConnectedSolarSystems = new List<string>(),
                            Constelation = null,
                            Effect = null,
                            Moons = null,
                            Planets = null,
                            Region = record.Region,
                            Static = null,
                            Static2 = null,
                            Sun = null
                        };

                        solarSystem.Security = GetStatus(record.SecurityRating);

                        SolarSystems.Add(solarSystem.SolarSystemName.Trim(), solarSystem);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[SpaceEntity.LoadBasicSolarSystems] Critical error = {0}", ex);
            }
        }

        public static SecurityStatus GetStatus(double securityStatus)
        {
            if (securityStatus < 0) return SecurityStatus.Nullsec;

            if (securityStatus > 0 && securityStatus < 0.45) return SecurityStatus.Lowsec;

            if (securityStatus >= 0.45) return SecurityStatus.Highsec;

            return SecurityStatus.WSpace;
        }

        private void LoadSolarSystemsIDs()
        {
            try
            {
                var dataFile = HttpContext.Current.Server.MapPath("~/Data/WSpaceSystemInfo - Basic Solar Systems.csv");

                using (var sr = new StreamReader(dataFile))
                {
                    var records = new CsvReader(sr).GetRecords<BasicSolarSystem>();

                    foreach (var record in records)
                    {
                        var solarSystem = SolarSystem(record.Name.ToUpper());

                        solarSystem.Id = record.Id;




                        BasicSolarSystems.Add(record.Name.Trim().ToUpper(), record.Id.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[SpaceEntity.LoadBasicSolarSystems] Critical error = {0}", ex);
            }



        }

        private void LoadWormholeTypes()
        {
            try
            {
                var dataFile = HttpContext.Current.Server.MapPath("~/Data/WSpaceSystemInfo - Wormholes.csv");

                using (var sr = new StreamReader(dataFile))
                {
                    var records = new CsvReader(sr).GetRecords<WormholeEntity>();

                    foreach (var record in records)
                    {
                        WormholeTypes.Add(record.Name.Trim(), record);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[SpaceEntity.LoadWormholes] Critical error = {0}", ex);
            }


        }

        private void LoadWormholeStarSystems()
        {
            //Log.Debug("[SpaceEntity.LoadStarSystems] Read csv file \"Data/WSpaceSystemInfo - Systems.csv\". ");

            

            try
            {
                var dataFile = HttpContext.Current.Server.MapPath("~/Data/WSpaceSystemInfo - Systems.csv");

                using (var sr = new StreamReader(dataFile))
                {
                    var records = new CsvReader(sr).GetRecords<StarSystem>();

                    foreach (var record in records)
                    {

                        var solarSystem = new StarSystemEntity
                        {
                            Id = record.Id,
                            SolarSystemName = record.SolarSystemName,
                            Class = record.Class,
                            ConnectedSolarSystems = new List<string>(),
                            Constelation = record.Constelation,
                            Effect = record.Effect,
                            Moons = record.Moons,
                            Planets = record.Planets,
                            Region = record.Region,
                            Static = record.Static,
                            Static2 = record.Static2,
                            Sun = record.Sun,
                            Security = SecurityStatus.WSpace
                        };


                        SolarSystems.Add(record.SolarSystemName.Trim(), solarSystem);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[SpaceEntity.LoadStarSystems] Critical error = {0}", ex);
            }


        }
    }
}