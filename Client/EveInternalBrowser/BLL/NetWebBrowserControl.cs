using System;
using System.Drawing;
using System.Windows.Forms;

namespace EveJimaIGB.BLL
{
    public class NetWebBrowserControl : IWebBrowserControl
    {
        public WebBrowser InternalBrowser { get; set; }

        public NetWebBrowserControl(string url)
        {
            InternalBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DimGray,
                Visible = true,
                ScriptErrorsSuppressed = true
            };

            InternalBrowser.DocumentTitleChanged += OnTitleChanged;
            InternalBrowser.DocumentCompleted += OnDocumentCompleted;

            InternalBrowser.Navigate(url);

            Instance = InternalBrowser;
        }

        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            DocumentComplete?.Invoke(InternalBrowser.Url.ToString());
        }

        private void OnTitleChanged(object sender, EventArgs e)
        {
            TitleChanged?.Invoke(InternalBrowser.DocumentTitle);
        }

        public override void Execute(string url)
        {
            InternalBrowser.Navigate(url);
        }

        public override event Action<string> TitleChanged;

        public override event Action<string> DocumentComplete;

        public override void DisposeBrowser()
        {
        }
    }
}
