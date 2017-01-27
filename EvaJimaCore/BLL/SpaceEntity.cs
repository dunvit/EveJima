using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using log4net;

namespace EveJimaCore.BLL
{
    public class SpaceEntity
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SpaceEntity));

        public readonly Dictionary<string, WormholeEntity> Wormholes = new Dictionary<string, WormholeEntity>();

        public readonly Dictionary<string, StarSystemEntity> SolarSystems = new Dictionary<string, StarSystemEntity>();

        public readonly Dictionary<string, string> BasicSolarSystems = new Dictionary<string, string>();

        public SpaceEntity()
        {
            LoadWormholes();

            LoadStarSystems();

            LoadBasicSolarSystems();
        }

        private void LoadBasicSolarSystems()
        {
            Log.Debug("[SpaceEntity.LoadBasicSolarSystems] Read csv file \"Data/WSpaceSystemInfo - Basic Solar Systems.csv\". ");

            try
            {
                using (var sr = new StreamReader(@"Data/WSpaceSystemInfo - Basic Solar Systems.csv"))
                {
                    var records = new CsvReader(sr).GetRecords<BasicSolarSystem>();

                    foreach (var record in records)
                    {
                        BasicSolarSystems.Add(record.Name.Trim(), record.Id.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadBasicSolarSystems] Critical error = {0}", ex);
            }


            
        }

        private void LoadWormholes()
        {
            Log.Debug("[SpaceEntity.LoadWormholes] Read csv file \"Data/WSpaceSystemInfo - Wormholes.csv\". ");

            try
            {
                using (var sr = new StreamReader(@"Data/WSpaceSystemInfo - Wormholes.csv"))
                {
                    var records = new CsvReader(sr).GetRecords<WormholeEntity>();

                    foreach (var record in records)
                    {
                        Wormholes.Add(record.Name.Trim(), record);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadWormholes] Critical error = {0}", ex);
            }

            
        }

        private void LoadStarSystems()
        {
            Log.Debug("[SpaceEntity.LoadStarSystems] Read csv file \"Data/WSpaceSystemInfo - Systems.csv\". ");

            try
            {
                using (var sr = new StreamReader(@"Data/WSpaceSystemInfo - Systems.csv"))
                {
                    var records = new CsvReader(sr).GetRecords<StarSystemEntity>();

                    foreach (var record in records)
                    {
                        SolarSystems.Add(record.System.Trim(), record);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SpaceEntity.LoadStarSystems] Critical error = {0}", ex);
            }

            
        }
    }
}
