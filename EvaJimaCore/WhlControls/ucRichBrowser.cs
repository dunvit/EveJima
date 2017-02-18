using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public delegate void DelegateChangeBrowserMode(bool isMax);

    public partial class ucRichBrowser : baseContainer
    {
        
        public DelegateChangeBrowserMode ChangeViewMode;

        private static readonly ILog Log = LogManager.GetLogger(typeof(ucRichBrowser));

        WBrowser.WBrowser richBrowser = new WBrowser.WBrowser();

        public OpenWebBrowser OnOpenWebBrowser;

        public ucRichBrowser()
        {
            InitializeComponent();
            richBrowser.TopLevel = false;
            richBrowser.Location = new Point(5, 5);
            richBrowser.Size = new Size(800, 900);
            richBrowser.FormBorderStyle = FormBorderStyle.None;
            richBrowser.Visible = true;
            richBrowser.Dock = DockStyle.Fill;


            Controls.Add(richBrowser);
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

            richBrowser.OpenNewTab(url);
        }

        public bool IsShowFavorites
        {
            get 
            {
                return richBrowser.IsShowFavorites;
            }
        }

        public void FixSize(bool ismax)
        {

            richBrowser.Size = new Size(Width,Height);

            richBrowser.FixSize(ismax);
        }

        public void DisposeBrowser()
        {
            richBrowser.DisposeBrowser();
        }
    }
}
