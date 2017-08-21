using System.Collections.Generic;
using System.Drawing;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    /// <summary>
    /// Summary description for MapViewTests
    /// </summary>
    [TestClass]
    public class MapViewTests
    {
        private Map GenerateMapObject()
        {
            var map = new Map();

            map.Systems.Add(new EveJimaUniverse.System { Name = "J213734", ConnectedSolarSystems = new List<string> { "J213735", "J213736" }, LocationInMap = new Point(5000, 5000)});
            map.Systems.Add(new EveJimaUniverse.System { Name = "J213735", ConnectedSolarSystems = new List<string> { "J213734" }, LocationInMap = new Point(5200, 5300) });
            map.Systems.Add(new EveJimaUniverse.System { Name = "J213736", ConnectedSolarSystems = new List<string> { "J213734" }, LocationInMap = new Point(4800, 4990) });

            map.LocationSolarSystemName = "J213734";

            return map;
        }


        [TestMethod]
        public void ForceRefreshTests()
        {
            var map = GenerateMapObject();

            var mapForView = map.Clone();

            Assert.IsTrue(map.Systems.Count == mapForView.Systems.Count);

            map.Systems.Add(new EveJimaUniverse.System { Name = "J213737", ConnectedSolarSystems = new List<string> { "J213736" }, LocationInMap = new Point(4700, 4790) });

            Assert.IsFalse(map.Systems.Count == mapForView.Systems.Count);



            var mapView = new MapView();

            mapView.ForceRefresh(mapForView);

            Assert.IsTrue(mapForView.Systems.Count == mapView.SolarSystems.Count);





        }
    }
}
