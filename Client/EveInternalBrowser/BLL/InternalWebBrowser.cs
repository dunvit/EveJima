using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CefSharp;

namespace EveJimaIGB.BLL
{
    public delegate void DelegateOnBrowserTitleChanged(TabPage id, string title);

    public class InternalWebBrowser
    {
        public int Id { get; set; }

        public string Url { get; private set; }

        public string Address { get; private set; }

        public DelegateOnBrowserTitleChanged OnTitleChanged;

        public IWebBrowserControl Control { get; set; }

        public TabPage TabPage { get; set; }

        public event Action<TabPage, int, string> OnDocumentComplete;

        public bool IsCanMovePrevious
        {
            get
            {
                if( _history.Count < 2 ) return false;

                var firstElement = _history.Last();

                return _currentHistoryUrl != firstElement;
            }
        }

        public bool IsCanMoveNext
        {
            get
            {
                if(_history.Count == 0) return false;

                var value = _history.First();

                return _currentHistoryUrl != value;
            }
        }

        public int HistoryUrlsCount => _history.Count;

        private string _currentHistoryUrl = string.Empty;

        private readonly Stack<string> _history = new Stack<string>();

        public InternalWebBrowser() : this(string.Empty)
        {

            
            
        }

        public InternalWebBrowser(string url) 
        {
            //Url = url;
            Id = (int)DateTime.Now.Ticks;

            BuildWebBrowser(Url);

            Navigate(url);

            
        }

        private void BuildWebBrowser(string address)
        {
            Control = WebBrowserFactory.GetWebBrowserControl(address, Global.Configuration.BrowserType);
            Control.DocumentComplete += OnBrowserDocumentComplete;
            Control.TitleChanged += OnBrowserTitleChanged;
        }

        private void OnBrowserDocumentComplete(string address)
        {
            OnDocumentComplete?.Invoke(TabPage, Id, address);

            if(Url != address)
            {
                _history.Push(address);
                _currentHistoryUrl = address;

                Url = address;
            }
        }

        public void Navigate(string url)
        {
            if(_currentHistoryUrl != string.Empty && url != "about:blank") ClearStack(_currentHistoryUrl);

            Control.Execute(url);
        }

        private void ClearStack(string url)
        {
            if(_history.Count == 0) return;

            var value = _history.First();

            if(value != url)
            {
                _history.Pop();
                ClearStack(url);
            }
        }

        public void NavigatePrevious()
        {
            var isNextElementWanted = false;

            foreach (var element in _history)
            {
                if(isNextElementWanted)
                {
                    _currentHistoryUrl = element;
                    Url = element;
                    Control.Execute(Url);
                    break;
                }

                if(_currentHistoryUrl == element) isNextElementWanted = true;
            }
        }

        public void NavigateNext()
        {
            var previousUrl = string.Empty;

            foreach (var element in _history)
            {
                if (_currentHistoryUrl == element)
                {
                    _currentHistoryUrl = previousUrl;
                    Url = previousUrl;
                    Control.Execute(Url);
                    break;
                }

                previousUrl = element;
            }
        }

        private void OnBrowserTitleChanged(string title)
        {
            try
            {
                if(title.Length > 20)
                {
                    var titleAfterRebuild = title.Substring(0, 20);

                    OnTitleChanged(TabPage, titleAfterRebuild);
                }
                else
                {
                    OnTitleChanged(TabPage, title);

                   

                }
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("[whlBrowser.InvokeOnUiThreadIfRequired] Critical error. Exception {0}", ex);
            }
        }

        public void Dispose()
        {
            //Cef.Shutdown();
        }
    }
}
