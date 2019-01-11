namespace EveJimaCore
{
    public class InternalBrowser
    {
        public BrowserNavigate OnBrowserNavigate;

        public void Navigate(string url)
        {
            OnBrowserNavigate(url);
        }


        public void Dispose()
        {
            //Cef.Shutdown();
            //Cef.Shutdown();
            //Browser.
        }
    }
}
