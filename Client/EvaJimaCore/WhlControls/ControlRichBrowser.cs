using System;
using System.Windows.Forms;
using log4net;
using Global = EvaJimaCore.Global;

namespace EveJimaCore.WhlControls
{
    public delegate void DelegateChangeBrowserMode(bool isMax);

    public partial class ControlRichBrowser : BaseContainer
    {
        public event Action OnForceResize;

        public DelegateChangeBrowserMode ChangeViewMode;

        private static readonly ILog Log = LogManager.GetLogger(typeof(ControlRichBrowser));
        

        public OpenWebBrowser OnOpenWebBrowser;

        public ControlRichBrowser()
        {
            InitializeComponent();

            if (IsDebug) return;

            Global.InternalBrowser.OnBrowserNavigate += Event_Navigate;

            igBrowser1.Initialization();
            igBrowser1.OnForceResize += Event_ForceResize;
            igBrowser1.OnBrowserBeforeShowDialog += Event_BrowserBeforeShowDialog;
            igBrowser1.OnBrowserAfterShowDialog += Event_BrowserAfterBeforeShowDialog;

            if(Global.ApplicationSettings != null)
                igBrowser1.IsOpenKillBoardInNewTab = Global.ApplicationSettings.Browser_IsOpenKillboardInNewTab;

            


            igBrowser1.OpenNewTab("https://github.com/dunvit/EveJima/releases");
            
        }

        private void Event_Navigate(string address)
        {
            BrowserUrlExecute(address);
        }

        private void Event_ForceResize()
        {
            OnForceResize?.Invoke();
        }


        private bool parentIsTopMost = false;

        private void Event_BrowserBeforeShowDialog()
        {
            parentIsTopMost = ParentWindow.TopMost;

            ParentWindow.TopMost = false;
        }

        private void Event_BrowserAfterBeforeShowDialog()
        {
            ParentWindow.TopMost = parentIsTopMost;
        }

        public bool isMaxMode = false;

        public void BrowserUrlExecute(string url)
        {
            if (OnOpenWebBrowser != null)
            {
                try
                {
                    OnOpenWebBrowser();
                }
                catch (Exception ex)
                {
                    Log.Error("[ucRichBrowser.BrowserUrlExecute] Critical error. Exception = " + ex);
                }
            }

            igBrowser1.OpenNewTab(url);
        }

        public void DisposeBrowser()
        {
            //richBrowser.DisposeBrowser();
        }

        private void ucRichBrowser_Load(object sender, EventArgs e)
        {
            
        }

        private void ControlRichBrowser_Resize(object sender, EventArgs e)
        {
            //igBrowser1.Size = new Size(Width,Height+64);
        }
    }
}
