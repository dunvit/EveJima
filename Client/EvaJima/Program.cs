using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace EveJima
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            var log = LogManager.GetLogger(typeof(Program));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log.Debug("----------------------------------------------------------------------------");
            log.Debug("[Program.Main] Start application EvaJima");

            EvaJimaCore.Global.Initialization();

            Application.Run(new EveJimaCore.WindowMonitoring());
        }

    }
}
