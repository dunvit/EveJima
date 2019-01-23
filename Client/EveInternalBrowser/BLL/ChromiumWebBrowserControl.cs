using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace EveJimaIGB.BLL
{
    public class ChromiumWebBrowserControl : IWebBrowserControl
    {
        public ChromiumWebBrowser InternalBrowser { get; set; }

        public ChromiumWebBrowserControl(string address)
        {
            InternalBrowser = new ChromiumWebBrowser(address)
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DimGray
            };

            InternalBrowser.CreateControl();

            InternalBrowser.TitleChanged += OnTitleChanged;
            InternalBrowser.LoadingStateChanged += OnDocumentComplete;

            Instance = InternalBrowser;
        }

        private void OnDocumentComplete(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                DocumentComplete?.Invoke(InternalBrowser.Address);
            }
        }

        private void OnTitleChanged(object sender, TitleChangedEventArgs args)
        {
            TitleChanged?.Invoke(args.Title);
        }

        public override void Execute(string url)
        {
            InternalBrowser.Load(url);
        }

        public override event Action<string> TitleChanged;

        public override event Action<string> DocumentComplete;

        public override void DisposeBrowser()
        {
            
        }
    }
}
