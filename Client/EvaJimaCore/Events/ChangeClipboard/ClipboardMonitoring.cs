using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using EveJimaIGB;

namespace EveJimaCore
{
    public class ClipboardMonitoring : Events.AbstractMonitor
    {
        public static event Action<string> GetValueFromClipboard;
        public static event Action<string> GetUnknownSpaceSolarSystemFromClipboard;

        private string _startedValue;
        private string _previousValue;
        private string _currentValue;


        public override void EraseEvent()
        {
            _logger.Debug("[ClipboardMonitoring.Event_Refresh] Start monitoring.");

            var activeProgramName = Tools.GetActiveWindowTitle();

            _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] activeProgramName = '{0}'", activeProgramName);

            if (activeProgramName == null)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                return;
            }



            _currentValue = GetClipBoradData().Trim();


            if (_currentValue.Contains("[")) return;

            if (_previousValue == _currentValue)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                return;
            }

            if(Debugger.IsAttached == false)
            {
                if (!activeProgramName.StartsWith(Global.Configuration.EveOnlineTitle))
                {
                    _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                    return;
                }
            }
            

            if (_startedValue == _currentValue)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                return;
            }

            if (string.IsNullOrEmpty(_currentValue))
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                return;
            }

            _previousValue = _currentValue;

            if (Tools.IsWSpaceSystem(_currentValue.Trim()))
            {
                GetUnknownSpaceSolarSystemFromClipboard?.Invoke(_currentValue.Trim());
                return;
            }

            _startedValue = "[Removed]";

            _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

            var zkbUrl = Zkillboard.GetZkillboardUrlByName(_currentValue);

            if(string.IsNullOrEmpty(zkbUrl) == false)
            {
                GetValueFromClipboard?.Invoke(zkbUrl);
            }
        }

        
        private static string GetClipBoradData()
        {
            try
            {
                string clipboardData = null;
                var staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            clipboardData = Clipboard.GetText(TextDataFormat.Text);
                        }

                        catch
                        {
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return clipboardData;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
