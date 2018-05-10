using System;
using System.ComponentModel;
using System.Windows.Forms;
using log4net;
using Global = EvaJimaCore.Global;

namespace EveJimaCore.WhlControls
{
    public delegate void DelegateChangeBrowserMode(bool isMax);

    public partial class ucRichBrowser : BaseContainer
    {
        public Form ParentWindow;
        public event Action OnForceResize;
        public DelegateChangeBrowserMode ChangeViewMode;

        private static readonly ILog Log = LogManager.GetLogger(typeof(ucRichBrowser));

        

        public OpenWebBrowser OnOpenWebBrowser;

        public ucRichBrowser()
        {
            InitializeComponent();

            igBrowser1.Initialization();
            igBrowser1.OnForceResize += Event_ForceResize;
            igBrowser1.OnBrowserBeforeShowDialog += Event_BrowserBeforeShowDialog;
            igBrowser1.OnBrowserAfterShowDialog += Event_BrowserAfterBeforeShowDialog;

            igBrowser1.IsOpenKillBoardInNewTab = Global.ApplicationSettings.Browser_IsOpenKillboardInNewTab;

            if(LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                igBrowser1.OpenNewTab("https://github.com/dunvit/EveJima/releases");
            }
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

        private void Event_ShowFavoritesChange(bool isShowFavorites)
        {
            //Global.WorkEnvironment.IsShowFavorites = isShowFavorites;
            //Global.ApplicationSettings.Save();
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

        //public bool IsShowFavorites
        //{
        //    get 
        //    {
        //        return richBrowser.IsShowFavorites;
        //    }
        //}

        public void FixSize(bool ismax)
        {

            //richBrowser.Size = new Size(Width,Height);

            //richBrowser.FixSize(ismax);
        }

        public void DisposeBrowser()
        {
            //richBrowser.DisposeBrowser();
        }

        private void ucRichBrowser_Load(object sender, EventArgs e)
        {
            
        }
    }
}
