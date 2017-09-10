using System;
using System.Collections.Generic;
using EveJimaCore;
using EveJimaCore.BLL;
using EveJimaUniverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class PathFinderTests
    {
        [TestMethod]
        public void TestFullFlowTest()
        {
            var universe = new Universe();
            universe.Initialization();

            var jita = universe.GetSystemByName("Jita");

            var kills = EsiAuthorization.GetSystemKills(jita.Id);

            var hek = universe.GetSystemByName("Hek");

            var esiAPI = new EsiAuthorization("e136434f8a0c484ab802666f378cac09", "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY");

            esiAPI.Refresh("VCajl13JWXZmJoZ0UxVJ4u3AHKh9FaNcb0bQ2mdQkGFfaLRhMrs0hw7_7xUjvJVPy6oHzIridqpUClbAOvBuSQ2");

            esiAPI.SetWaypoint("false", "true", hek.Id);

            var bookmarksFoldersFromApi = esiAPI.GetBookmarksFolders(95089319);

            var bookmarksFromApi = esiAPI.GetBookmarks(95089319, "2210679");

            var solarSystemGare = universe.GetSystemByName("4YO-QK");

            var bookmarks = new List<Bookmark>
            {
                new Bookmark { Name = "LMM7-L", Note = "", SystemId = "30000615" },
                new Bookmark { Name = "RV5-TT", Note = "", SystemId = "30000651" },
                new Bookmark { Name = "995-3G", Note = "", SystemId = "30000616" },
                new Bookmark { Name = "4YO-QK", Note = "", SystemId = "30000646" },
                new Bookmark { Name = "8-BIE3", Note = "", SystemId = "30000614" }
            };

            var pathFinder = new PathFinder(universe);


            var solarSystem = universe.GetSystemByName("2-2EWC");

            var linkedSolarSystems = pathFinder.GetSystems(universe, solarSystem.Id, 3, 0, new List<Tuple<string, int>> { new Tuple<string, int>(solarSystem.Id, 0) });

            Assert.AreEqual(linkedSolarSystems.Count, 13);

            var data = pathFinder.GetPathes(bookmarks, "2-2EWC", 3);

            var data2 = pathFinder.GetPathes(bookmarksFromApi, "Jita", 3);

            Assert.AreEqual(data2.Count, 1);
        }
    }
}
