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
            Logger.Debug("[ClipboardMonitoring.Event_Refresh] Start monitoring.");

            var activeProgramName = Tools.GetActiveWindowTitle();

            Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] activeProgramName = '{0}'", activeProgramName);

            if (activeProgramName == null)
            {
                if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Active Program Name is null. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "********", "********", "********");
                }
                else
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Active Program Name is null. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                }

                return;
            }



            _currentValue = GetClipBoradData().Trim();


            if (_currentValue.Contains("[")) return;

            if (_previousValue == _currentValue)
            {
                if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is old value. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "******", "******", "******");
                }
                else
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is old value. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                }
                return;
            }

            if(Debugger.IsAttached == false)
            {
                if (!activeProgramName.StartsWith(Global.Configuration.EveOnlineTitle))
                {
                    if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
                    {
                        Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is not EVE window. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "******", "******", "******");
                    }
                    else
                    {
                        Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is not EVE window. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                    }

                    return;
                }
            }
            

            if (_startedValue == _currentValue)
            {
                if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is started value. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "******", "******", "******");
                }
                else
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This is started value. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                }

                return;
            }

            if (string.IsNullOrEmpty(_currentValue))
            {
                if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This value is empty. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "******", "******", "******");
                }
                else
                {
                    Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. This value is empty. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
                }
                return;
            }

            _previousValue = _currentValue;

            if (Tools.IsWSpaceSystem(_currentValue.Trim()))
            {
                GetUnknownSpaceSolarSystemFromClipboard?.Invoke(_currentValue.Trim());
                return;
            }

            _startedValue = "[Removed]";

            if (EvaJimaCore.Global.ApplicationSettings.Security.IsPrintClipboardDataToLog)
            {
                Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", "******", "******", "******");
            }
            else
            {
                Logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);
            }
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

        public ClipboardMonitoring(ApplicationSettings settings) : base(settings)
        {
        }
    }
}
