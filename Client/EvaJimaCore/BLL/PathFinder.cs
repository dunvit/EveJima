using System;
using System.Collections.Generic;
using EveJimaCore.BLL.Navigator;
using EveJimaUniverse;

namespace EveJimaCore.BLL
{
    public class PathFinder
    {
        private readonly Universe _universe;

        public PathFinder(Universe universe)
        {
            _universe = universe;
        }

        public List<Path> GetPathes(List<Bookmark> bookmarks, string locationSystemName, int range)
        {
            var solarSystem = _universe.GetSystemByName(locationSystemName);

            var linkedSolarSystems = GetSystems(_universe, solarSystem.Id, range, 0, new List<string> { solarSystem.Id });

            return GetBookmarks(bookmarks, linkedSolarSystems);
        }

        private List<Path> GetBookmarks(IEnumerable<Bookmark> bookmarks, List<string> systems)
        {
            var pathes = new List<Path>();

            foreach (var bookmark in bookmarks)
            {
                foreach(var system in systems)
                {
                    if(bookmark.SystemId != system) continue;

                    try
                    {
                        var path = new Path
                        {
                            Name = bookmark.Name,
                            Note = bookmark.Note,
                            SystemName = _universe.GetSystemById(system).Name,
                            ShipKills = "0",
                            NpcKills = "0",
                            PodKills = "0"
                        };

                        var kills = EsiAuthorization.GetSystemKills(system);

                        if (kills != null)
                        {
                            path.ShipKills = kills.Item1;
                            path.NpcKills = kills.Item2;
                            path.PodKills = kills.Item3;
                        }

                        pathes.Add(path);
                    }
                    catch(Exception ex)
                    {
                        
                    }
                    
                }
            }

            return pathes;
        }

        public List<string> GetSystems(Universe universe, string solarSystemId, int range, int currentRange, List<string> systems)
        {
            currentRange = currentRange + 1;

            if (currentRange > range) return systems;

            var linkedSystems = universe.GetLinkedSystems(solarSystemId);

            foreach (var system in linkedSystems.LinkedSystems)
            {
                var linkedSystem = universe.GetSystemById(system);

                if (systems.Contains(linkedSystem.Id) == false)
                {
                    systems.Add(linkedSystem.Id);

                    GetSystems(universe, linkedSystem.Id, range, currentRange, systems);
                }
            }

            return systems;
        }
    }
}
