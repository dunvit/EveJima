using System.Timers;
using log4net;

namespace EveJimaCore.Events
{
    public abstract class AbstractMonitor
    {
        public readonly ILog _logger = LogManager.GetLogger(string.Empty);

        private readonly Timer _workerTimer;

        protected AbstractMonitor()
        {
            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 100;
            _workerTimer.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            _logger.Debug("[BaseEventMonitor.Event_Refresh] Monitoring.");

            _workerTimer.Enabled = false;

            EraseEvent();

            _workerTimer.Enabled = true;
        }

        public abstract void EraseEvent();
        
    }
}
