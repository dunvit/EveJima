using System.Timers;
using log4net;

namespace EveJimaCore.Events
{
    public abstract class AbstractMonitor
    {
        public ILog Logger = LogManager.GetLogger(string.Empty);

        private Timer _workerTimer;

        public ApplicationSettings Settings { get; set; }

        protected AbstractMonitor(ApplicationSettings settings)
        {
            Settings = settings;
        }

        public void Activate()
        {
            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 500;
            _workerTimer.Enabled = true;
        }

        public void Dispose()
        {
            _workerTimer.Enabled = false;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            Logger.Debug("[AbstractMonitor.Event_Refresh] Monitoring.");

            _workerTimer.Enabled = false;

            EraseEvent();

            _workerTimer.Enabled = true;
        }

        public abstract void EraseEvent();
        
    }
}
