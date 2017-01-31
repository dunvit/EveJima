using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore
{
    public class InternalBrowser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InternalBrowser));

        //public whlBrowser Browser;
        public ucRichBrowser Browser;

        private readonly string cache_dir = Application.StartupPath + "\\tmp";

        public InternalBrowser()
        {
            InitializeChromium();
        }

        private void InitializeChromium()
        {
            try
            {
                //Browser= new whlBrowser();
                Browser = new ucRichBrowser();
                Directory.CreateDirectory(cache_dir);

                var settings = new CefSettings();
                settings.UserAgent = "pipiscrew_browser_v" + Cef.CefSharpVersion;

                settings.CachePath = cache_dir;

                //To persist session cookies (cookies without an expiry date or validity interval)
                settings.CefCommandLineArgs.Add("persist_session_cookies", "1");

                Cef.Initialize(settings);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[InternalBrowser.InitializeChromium] Critical error. Exception {0}", ex);
            }

            
        }

        public void Dispose()
        {
            //Cef.Shutdown();
            //Browser.
        }
    }
}
