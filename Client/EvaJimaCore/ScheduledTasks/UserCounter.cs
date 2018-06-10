using System;
using System.Timers;
using log4net;
using Timer = System.Timers.Timer;

namespace EveJimaCore.ScheduledTasks
{
    public class UserCounter
    {
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);

        private readonly Timer _workerTimer;

        public event Action<string> OnNavigate;

        public string CounterAddress { get; set; }

        public UserCounter()
        {
            _logger.Debug("[UserCounter.UserCounter] Started update user counter in address " + CounterAddress);

            CounterAddress = "http://evejima.mikotaj.com/VisitorsCounter.html";

            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 30000;
            _workerTimer.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            _workerTimer.Enabled = false;


            _logger.Debug("[UserCounter.Event_Refresh] Updated user counter in address " + CounterAddress);

            OnNavigate?.Invoke(CounterAddress);

            _workerTimer.Enabled = true;
        }

        public void ModuleTravelHistoryUse()
        {
            _workerTimer.Enabled = false;

            var address = "http://evejima.mikotaj.com/VisitorsCounterTravelHistory.html";

            _logger.Debug("[UserCounter.ModuleTravelHistoryUse] Updated user counter in address " + address);

            OnNavigate?.Invoke(address);

            _workerTimer.Enabled = true;
        }
    }
}
