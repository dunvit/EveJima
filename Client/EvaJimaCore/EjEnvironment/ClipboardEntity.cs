
using System.Windows.Forms;
using log4net;

namespace EveJimaCore.EjEnvironment
{
    public class ClipboardEntity
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        private string _startedValue;
        private string _previousValue;
        private string _currentValue;

        public ClipboardEntity()
        {
            _startedValue = Clipboard.GetText().Trim();

            Log.DebugFormat("Started Clipboard value is {0}", _startedValue);
        }

        public string GetValue()
        {
            if(_previousValue != _currentValue)
            {
                _previousValue = _currentValue;
            }

            _currentValue = Clipboard.GetText().Trim();

            Log.DebugFormat("Get Clipboard value is {0}", _currentValue);

            return _currentValue;
        }
        public string GetStartedValue()
        {
            return _startedValue;
        }


        public string GetPreviousValue()
        {
            return string.IsNullOrEmpty(_previousValue) ? string.Empty : _previousValue;
        }
    }
}
