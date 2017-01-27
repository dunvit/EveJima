using System;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore
{
    public class InternalBrowser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InternalBrowser));

        public whlBrowser Browser;

        public InternalBrowser()
        {
            InitializeChromium();
        }

        private void InitializeChromium()
        {
            try
            {
                Browser= new whlBrowser();
                //var settings = new CefSettings();

                //Cef.Initialize(settings);
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
