using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EveJimaCore.Monitoring.Tests
{
    [TestClass()]
    public class BookmarksMonitoringTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            var applicationSettings = new ApplicationSettings();

            var bookmarksMonitoring = new BookmarksMonitoring(applicationSettings);

            var result = bookmarksMonitoring.Execute("AQD-172	Cosmic Signature			0.0%	4.85 AU");

            Assert.Fail();
        }
    }
}