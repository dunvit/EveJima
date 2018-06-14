

namespace EveJimaIGB.BLL
{
    public class WebBrowserFactory
    {
        public static IWebBrowserControl GetWebBrowserControl(string url, string type)
        {
            switch(type)
            {
                case "chromiumWebBrowser":
                    return new ChromiumWebBrowserControl(url);

                case "netWebBrowser":
                    return new NetWebBrowserControl(url);
            }

            return null;
        }
    }
}
