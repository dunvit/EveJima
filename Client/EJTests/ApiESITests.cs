using System;
using EveJimaCore;
using EveJimaIGB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class ApiESITests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = Zkillboard.GetZkillboardUrlByName("Nix Axer");
        }
    }
}
