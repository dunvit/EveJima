using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using log4net;

namespace EveJimaCore.WhlControls
{
    public class BaseContainer : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_NO_APP_ASSOCIATED = 1155;

        private readonly WebBrowser _browserCounter = new WebBrowser();

        public BaseContainer()
        {
            //Visible = false;
            BackColor = Color.Black;
            //Location = new Point(11, 63);
            Location = new Point(0, 0);

            Size = new Size(564, 325);

            _browserCounter.ScriptErrorsSuppressed = true;
        }

        public virtual void ActivateContainer()
        {
            //var a = "a";
        }

        public void EventNavigateInternalBrowser(string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(EventNavigateInternalBrowser), address);
                return;
            }

            try
            {
                if (_browserCounter.IsBusy) return;

                _browserCounter.Navigate(address);
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND || e.NativeErrorCode == ERROR_ACCESS_DENIED || e.NativeErrorCode == ERROR_NO_APP_ASSOCIATED)
                {
                    Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical error on updated user counter in address " + address + " Exception is " + e.Message);
                }
            }
            catch (Exception exception)
            {
                Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical error on updated user counter in address " + address + " Exception is " + exception.Message);
            }
            catch
            {
                Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical unexcepted error on updated user counter in address " + address + " ");
            }

        }

    }
}
