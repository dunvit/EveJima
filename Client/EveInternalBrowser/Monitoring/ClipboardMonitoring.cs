using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using log4net;
using Timer = System.Timers.Timer;

namespace EveJimaIGB.BLL
{
    public class ClipboardMonitoring
    {
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);

        public event Action<string> GetValueFromClipboard;

        private readonly Timer _workerTimer;

        private string _startedValue;
        private string _previousValue;
        private string _currentValue;

        private Config _config;

        public ClipboardMonitoring(Config config)
        {
            _startedValue = Clipboard.GetText().Trim();

            _config = config;

            _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] Started Clipboard value is {0}", _startedValue);

            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 100;
            _workerTimer.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            _logger.Debug("[ClipboardMonitoring.Event_Refresh] Start monitoring.");

            _workerTimer.Enabled = false;

            var activeProgramName = Tools.GetActiveWindowTitle();

            _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] activeProgramName = '{0}'", activeProgramName);

            if (activeProgramName == null)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

                _workerTimer.Enabled = true;
                return;
            }

            _currentValue = GetClipBoradData().Trim();

            if (_previousValue == _currentValue)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

                _workerTimer.Enabled = true;
                return;
            }


            //if (!activeProgramName.StartsWith(_config.EveOnlineTitle))
            //{
            //    _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

            //    _workerTimer.Enabled = true;
            //    return;
            //}

            if (_startedValue == _currentValue)
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

                _workerTimer.Enabled = true;
                return;
            }

            if (string.IsNullOrEmpty(_currentValue))
            {
                _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] No need action. Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

                _workerTimer.Enabled = true;
                return;
            }

            _previousValue = _currentValue;

            _startedValue = "[Removed]";

            _logger.DebugFormat("[ClipboardMonitoring.Event_Refresh] Value is '{0}' Previous Value is '{1}' Started Value is '{2}'", _currentValue, _previousValue, _startedValue);

            GetValueFromClipboard?.Invoke(_currentValue);

            _workerTimer.Enabled = true;
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
