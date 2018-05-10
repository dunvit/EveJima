using EveJimaCore;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class ApiZKillboardTests
    {
        private ILog logger = LogManager.GetLogger(typeof(ApiZKillboardTests));

        [TestMethod]
        public void TestMethod1()
        {
            log4net.Config.XmlConfigurator.Configure();

            var pilotExist = ZKillboardApi.IsCharacter("2112098220", logger);

            Assert.IsTrue(pilotExist);

            var pilotNotExist = ZKillboardApi.IsCharacter("21120982209121312312", logger);

            Assert.IsFalse(pilotNotExist);

            var corporationExist = ZKillboardApi.IsCorporation("98459743", logger);

            Assert.IsTrue(corporationExist);

            var corporationNotExist = ZKillboardApi.IsCorporation("98459743500352", logger);

            Assert.IsFalse(corporationNotExist);

            var solarSystemExist = ZKillboardApi.IsSolarSystem("30002187", logger);

            Assert.IsTrue(solarSystemExist);

            var solarSystemNotExist = ZKillboardApi.IsSolarSystem("3000218712312312", logger);

            Assert.IsFalse(solarSystemNotExist);

            var allianceExist = ZKillboardApi.IsAlliance("1354830081", logger);

            Assert.IsTrue(allianceExist);

            var allianceNotExist = ZKillboardApi.IsAlliance("1354830081313213123", logger);

            Assert.IsFalse(allianceNotExist);
        }
    }
}
