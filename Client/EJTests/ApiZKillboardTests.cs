using EveJimaCore;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveJimaCore.API;

namespace EJTests
{
    [TestClass]
    public class ApiZKillboardTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            log4net.Config.XmlConfigurator.Configure();

            var pilotExist = Zkillboard.IsCharacter("2112098220");

            Assert.IsTrue(pilotExist);

            var pilotNotExist = Zkillboard.IsCharacter("21120982209121312312");

            Assert.IsFalse(pilotNotExist);

            var corporationExist = Zkillboard.IsCorporation("98459743");

            Assert.IsTrue(corporationExist);

            var corporationNotExist = Zkillboard.IsCorporation("98459743500352");

            Assert.IsFalse(corporationNotExist);

            var solarSystemExist = Zkillboard.IsSolarSystem("30002187");

            Assert.IsTrue(solarSystemExist);

            var solarSystemNotExist = Zkillboard.IsSolarSystem("3000218712312312");

            Assert.IsFalse(solarSystemNotExist);

            var allianceExist = Zkillboard.IsAlliance("1354830081");

            Assert.IsTrue(allianceExist);

            var allianceNotExist = Zkillboard.IsAlliance("1354830081313213123");

            Assert.IsFalse(allianceNotExist);
        }
    }
}
