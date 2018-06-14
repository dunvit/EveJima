using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Timers;
using log4net;
using Timer = System.Timers.Timer;

namespace EveJimaIGB.Monitoring
{
    public class LinkMonitoring
    {
        private readonly ILog _logger = LogManager.GetLogger(string.Empty);

        public event Action<string> GetUrlFromFile;

        private readonly Timer _workerTimer;

        private string path = AppDomain.CurrentDomain.BaseDirectory + @"Browser\History\";

        public LinkMonitoring()
        {
            _logger.Debug("[LinkMonitoring.LinkMonitoring] Started monitoring files in folder Browser\\History\\");

            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 100;
            _workerTimer.Enabled = true;
        }

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            _workerTimer.Enabled = false;

            var directory = new DirectoryInfo(path);

            if (directory.Exists == false)
            {
                Directory.CreateDirectory(path);
                directory = new DirectoryInfo(path);
            }

            var links = new List<string>();

            foreach (var file in directory.GetFiles())
            {
                var text = File.ReadAllText(file.FullName).Replace(@"\r", "").Replace(@"\n", "").Trim();

                _logger.Debug("[Interceptor.CheckIsNeedRunHtml] Found link '" + text + "'");

                links.Add(text);

                file.Delete();
            }

            foreach (var link in links)
            {
                _logger.Debug("[Interceptor.CheckIsNeedRunHtml] Execute link '" + link + "'");

                GetUrlFromFile?.Invoke(link);

                Thread.Sleep(100);
            }

            _workerTimer.Enabled = true;
        }
    }
}
