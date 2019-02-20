using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class ToolsTests
    {
        [TestMethod]
        public void Test_Tools_IsWSpaceSystem()
        {
            Assert.AreEqual(EveJimaCore.Tools.Common.IsWSpaceSystem("J567345"), true);
            Assert.AreEqual(EveJimaCore.Tools.Common.IsWSpaceSystem("Jita"), false);
            Assert.AreEqual(EveJimaCore.Tools.Common.IsWSpaceSystem("SBL5-R"), false);
            Assert.AreEqual(EveJimaCore.Tools.Common.IsWSpaceSystem("AW1-2I"), false); 
        }
    }
}
