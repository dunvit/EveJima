using System;
using EveJimaCore.BLL.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJTests
{
    [TestClass]
    public class InterceptorTests
    {
        [TestMethod]
        public void FullFlow()
        {
            var interceptor = new Interceptor(true);

            interceptor.StartIntercepting();
            interceptor.StopIntercepting();
        }
    }
}
