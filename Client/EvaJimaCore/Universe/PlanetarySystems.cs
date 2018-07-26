using System.Collections;

namespace EveJimaCore.Universe
{
    public class PlanetarySystems
    {
        private readonly EsiApi _api;
        readonly Hashtable _systems = new Hashtable();
        readonly Hashtable _ids = new Hashtable();
        private readonly EveJimaUniverse.UniverseEntity _space;

        public PlanetarySystems(EsiApi esiApi, EveJimaUniverse.UniverseEntity space)
        {
            _api = esiApi;
            _space = space;
        }

        public PlanetarySystem GetPlanetarySystemById(string id)
        {
            if (_systems[id] == null)
            {
                return AddPlanetarySystem(int.Parse(id), _api);
            }
            return _systems[id] as PlanetarySystem;
        }



        public PlanetarySystem GetPlanetarySystemByName(string name)
        {
            if(_ids[name] == null)
            {
                var id = _api.GetSolarSystemId(name);

                return AddPlanetarySystem(int.Parse(id), _api);
            }

            return GetPlanetarySystemById(_ids[name].ToString());
        }

        private PlanetarySystem AddPlanetarySystem(int id, EsiApi esiApi)
        {
            var planetarySystem = CreatePlanetarySystem(id.ToString(), esiApi);

            _systems.Add(planetarySystem.Id, planetarySystem);
            _ids.Add(planetarySystem.Name, planetarySystem.Id);

            return planetarySystem;
        }

        private PlanetarySystem CreatePlanetarySystem(string id, EsiApi esiApi)
        {

            var solarSystem = _space.GetSystemById(id);

            var system = new PlanetarySystem
            {
                Id = id,
                Class = solarSystem.Class,
                Effect = solarSystem.Effect,
                Static = solarSystem.Static,
                Static2 = solarSystem.Static2,
                Sun = solarSystem.Sun,
                Security = solarSystem.Security
            };


            var infoAboutSolarSystem = esiApi.GetSolarSystemInfo(id);

            system.Name = infoAboutSolarSystem.name.ToString();
            system.ConstelationId = infoAboutSolarSystem.constellation_id.ToString();
            system.SecurityNumber = float.Parse(infoAboutSolarSystem.security_status.ToString()).ToString();
            system.StarId = infoAboutSolarSystem.star_id.ToString();

            foreach (var planet in infoAboutSolarSystem.planets)
            {
                system.Planets++;
            }

            var constellationInfo = esiApi.GetConstellationInfo(system.ConstelationId);

            system.Constelation = constellationInfo.name.ToString();

            system.RegionId = constellationInfo.region_id.ToString();

            var regionInfo = esiApi.GetRegionInfo(system.RegionId);

            system.Region = regionInfo.name.ToString();

            return system;
        }

    }
}
