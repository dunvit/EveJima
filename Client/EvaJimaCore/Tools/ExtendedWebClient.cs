using System;
using System.Net;
using System.Net.Cache;
using System.Reflection;

namespace EveJimaCore.Tools
{
    public class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }
        public string UserAgent { get; set; }
        public string Referer { get; set; }

        public string ContentType { get; set; }

        public ExtendedWebClient(string userAgent, string referer)
        {
            Timeout = 5000;
            UserAgent = userAgent;
            Referer = referer;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = request.GetResponse() as HttpWebResponse;

            if (response != null)
                ContentType = response.ContentType;

            return base.GetWebResponse(request);
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;

            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            request.CookieContainer = new CookieContainer();
            CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

            var sp = request.ServicePoint;
            var prop = sp.GetType().GetProperty("HttpBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(sp, (byte)0, null);


            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";

            request.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru-RU;q=0.8,ru;q=0.7");

            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("Cache-Control", "max-age=0");
            Headers.Add("Vary", "Accept");
            request.UserAgent = UserAgent;
            request.Referer = Referer;
            request.Timeout = Timeout;

            return request;
        }
    }
}
