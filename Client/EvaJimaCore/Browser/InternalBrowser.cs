using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using EveJimaCore.BLL.Browser;
using log4net;

namespace EveJimaCore
{
    public class InternalBrowser
    {
        public BrowserNavigate OnBrowserNavigate;

        //private static readonly ILog Log = LogManager.GetLogger(typeof(InternalBrowser));

        

        //private readonly string cache_dir = Application.StartupPath + "\\tmp";

        public InternalBrowser()
        {
            InitializeChromium();
        }



        private void InitializeChromium()
        {
            
        }

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
