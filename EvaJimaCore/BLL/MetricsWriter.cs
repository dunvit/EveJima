using System;
using System.Net;
using System.Threading.Tasks;

namespace EveJimaCore.BLL
{
    public class MetricsWriter
    {
        private const string MetricsServer = "http://www.evajima-storage.somee.com";

        private const string ApplicationStartAddress = "{0}/api/version/%22{1}%22";
        private const string InitializationAddress = "{0}/api/initialization/{1}";

        public void PublishOnApplicationStart(string version)
        {
            SendRequest(string.Format(ApplicationStartAddress, MetricsServer, version.Replace(".", ",")));
        }

        public void PublishOnPilotInitialization(long pilotId)
        {
            SendRequest(string.Format(InitializationAddress, MetricsServer, pilotId));
        }

        private Task<string> SendRequest(string url)
        {
            return (new WebClient()).DownloadStringTaskAsync(new Uri(url));
        }
    }
}
