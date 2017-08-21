using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EJTests
{
    [TestClass]
    public class ApiServerTests
    {
        private string addresGetGuID = "http://localhost:51135/api/GUID";

        [TestMethod]
        public void TestApiVersion()
        {
            var address = "http://localhost:51135/api/version/%22123%22";

            using (var client = new WebClient())
            {
                var dataVerification = client.DownloadString(address);

                Assert.IsTrue(dataVerification == "\"Complete\"");
            }
        }

        
    }
}
