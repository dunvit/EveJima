using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using EveJimaUniverse;

namespace EveJimaServerMap
{
    public class MapTools
    {
        public static bool IsWSpaceSystem(string systemName)
        {
            var numbersInSystemName = Regex.Match(systemName, @"\d+").Value;

            if (numbersInSystemName == "") return false;

            return systemName.Replace(numbersInSystemName, "") == "J";
        }

        private static EveJimaUniverse.System GetSystem(ConcurrentDictionary<string, EveJimaUniverse.System> systems, string system)
        {
            return systems[system];
            //return systems.FirstOrDefault(solarSystem => solarSystem.Name == system);
        }

        public static string GetSystemType(ConcurrentDictionary<string, EveJimaUniverse.System> systems, string system)
        {
            if (IsWSpaceSystem(system))
            {
                return "A";
            }

            var systemPrevious = GetSystem(systems, system);

            var isNeedAddSolarSystemToMap = false;

            foreach (var connected in systemPrevious.ConnectedSolarSystems)
            {
                if (IsWSpaceSystem(connected))
                {
                    return "B";
                }
            }

            foreach (var connected in systemPrevious.ConnectedSolarSystems)
            {
                var connectedSystem = GetSystem(systems, connected);

                foreach (var connectedOfConnected in connectedSystem.ConnectedSolarSystems)
                {
                    if (IsWSpaceSystem(connectedOfConnected))
                    {
                        return "C";
                    }
                }
            }

            return "D";
        }
    }
}
