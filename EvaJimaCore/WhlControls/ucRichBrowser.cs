using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class ucRichBrowser : UserControl
    {

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

            richBrowser.Navigate(url);
        }

        public void ResizeWebBrowser(int width, int height)
        {
            Width = width - 24;

            Height = height - 110;

        }

        public void BrowserOpen()
        {

        }



        public void DisposeBrowser()
        {
            richBrowser.DisposeBrowser();
        }
    }
}
