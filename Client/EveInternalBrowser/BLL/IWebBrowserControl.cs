using System;

namespace EveJimaIGB.BLL
{
    public abstract class IWebBrowserControl
    {
        public abstract void Execute(string url);

        public abstract event Action<string> TitleChanged;

        public abstract event Action<string> DocumentComplete;

        public abstract void DisposeBrowser();

        public System.Windows.Forms.Control Instance;
    }
}
