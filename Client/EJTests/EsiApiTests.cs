using EveJimaCore;
using EveJimaCore.Universe;
using EveJimaUniverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class EsiApiTests
    {
        [TestMethod]
        public void GetSolarSystemIdTest()
        {
            var esiApi= new EsiApi("e136434f8a0c484ab802666f378cac09", "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY");

            var Space = new UniverseEntity();
            Space.Initialization();

            var planetarySystems = new PlanetarySystems(esiApi, Space);

            var J213734 = planetarySystems.GetPlanetarySystemByName("J213734");


            var solarSystemD61A_G = planetarySystems.GetPlanetarySystemByName("D61A-G");
           

            Assert.AreEqual("30003724", solarSystemD61A_G.Id);
            Assert.AreEqual("20000543", solarSystemD61A_G.ConstelationId);
            Assert.AreEqual(SecurityStatus.Nullsec, solarSystemD61A_G.Security);
            Assert.AreEqual("40235944", solarSystemD61A_G.StarId);
            Assert.AreEqual("D61A-G", solarSystemD61A_G.Name);
            Assert.AreEqual(10, solarSystemD61A_G.Planets);

            var solarSystemD61A_G_double = planetarySystems.GetPlanetarySystemByName("D61A-G");

            Assert.AreEqual("30003724", solarSystemD61A_G_double.Id);
            Assert.AreEqual("20000543", solarSystemD61A_G_double.ConstelationId);
            Assert.AreEqual(SecurityStatus.Nullsec, solarSystemD61A_G_double.Security);
            Assert.AreEqual("40235944", solarSystemD61A_G_double.StarId);
            Assert.AreEqual("D61A-G", solarSystemD61A_G_double.Name);
            Assert.AreEqual(10, solarSystemD61A_G_double.Planets);

            var solarSystemJita = planetarySystems.GetPlanetarySystemByName("Jita");

            Assert.AreEqual("30000142", solarSystemJita.Id);
            Assert.AreEqual("20000020", solarSystemJita.ConstelationId);
            Assert.AreEqual(SecurityStatus.Highsec, solarSystemJita.Security);
            Assert.AreEqual("40009076", solarSystemJita.StarId);
            Assert.AreEqual("Jita", solarSystemJita.Name);
            Assert.AreEqual(8, solarSystemJita.Planets);

            var solarSystem = planetarySystems.GetPlanetarySystemByName("J105934");

            Assert.AreEqual("31002487", solarSystem.Id);
            Assert.AreEqual("21000298", solarSystem.ConstelationId);
            Assert.AreEqual(SecurityStatus.WSpace, solarSystem.Security);
            Assert.AreEqual("40476319", solarSystem.StarId);
            Assert.AreEqual("J105934", solarSystem.Name);
            Assert.AreEqual(10, solarSystem.Planets);
        }

        [TestMethod]
        public void GetSolarSystemInfoTest()
        {
            var esiApi = new EsiApi("e136434f8a0c484ab802666f378cac09", "bqbIMfDvaFfI9EPOGYmrVDeih9wPkDFnH3eW7GZY");

            var space = new UniverseEntity();
            space.Initialization();

            var planetarySystems = new PlanetarySystems(esiApi, space);

            var solarSystemD61A_G = planetarySystems.GetPlanetarySystemById("30003724");

            var solarSystemD61A_G_double = planetarySystems.GetPlanetarySystemById("30003724");

            Assert.AreEqual("30003724", solarSystemD61A_G.Id);
            Assert.AreEqual("20000543", solarSystemD61A_G.ConstelationId);
            Assert.AreEqual(SecurityStatus.Nullsec, solarSystemD61A_G.Security);
            Assert.AreEqual("40235944", solarSystemD61A_G.StarId);
            Assert.AreEqual("D61A-G", solarSystemD61A_G.Name);
            Assert.AreEqual(10, solarSystemD61A_G.Planets);

            var solarSystemJita = planetarySystems.GetPlanetarySystemById("30000142");

            Assert.AreEqual("30000142", solarSystemJita.Id);
            Assert.AreEqual("20000020", solarSystemJita.ConstelationId);
            Assert.AreEqual(SecurityStatus.Highsec, solarSystemJita.Security);
            Assert.AreEqual("40009076", solarSystemJita.StarId);
            Assert.AreEqual("Jita", solarSystemJita.Name);
            Assert.AreEqual(8, solarSystemJita.Planets);

            var solarSystem = planetarySystems.GetPlanetarySystemById("31002487");

            Assert.AreEqual("31002487", solarSystem.Id);
            Assert.AreEqual("21000298", solarSystem.ConstelationId);
            Assert.AreEqual(SecurityStatus.WSpace, solarSystem.Security);
            Assert.AreEqual("40476319", solarSystem.StarId);
            Assert.AreEqual("J105934", solarSystem.Name);
            Assert.AreEqual(10, solarSystem.Planets);
        }
    }
}
