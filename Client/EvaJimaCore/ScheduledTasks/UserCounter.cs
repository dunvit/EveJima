using System;
using System.Net;
using System.Timers;
using log4net;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace EveJimaCore.ScheduledTasks
{
    public class UserCounter
    {
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);

        private readonly Timer _workerTimer;

        public event Action<string> OnNavigate;

        private const string CounterAddress = "http://evejima.mikotaj.com/VisitorsCounter.html";

        public UserCounter()
        {
            _logger.Debug("[UserCounter.UserCounter] Started update user counter in address " + CounterAddress);

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
    }
}
