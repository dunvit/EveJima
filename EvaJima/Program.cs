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

            //GetApplicationMetrics();

            EvaJimaCore.Global.Initialization();

            Application.Run(new EveJimaCore.WindowMonitoring());
        }


        private static void GetApplicationMetrics()
        {
            //var log = LogManager.GetLogger(typeof(Program));

            //var version = Assembly.GetExecutingAssembly().GetName().Version;
            //log.DebugFormat("[Program.GetApplicationMetrics] Version \"EveJima.exe\" is {0}", version);

            //var assembly = Assembly.LoadFrom("EveJimaCore.dll");
            //var ver = assembly.GetName().Version;

            //log.DebugFormat("[Program.GetApplicationMetrics] Version \"EveJimaCore.dll\" is {0}", ver);

            //var assemblyEvaJimaSettings = Assembly.LoadFrom("EveJimaSettings.dll");
            //var verEvaJimaSettings = assemblyEvaJimaSettings.GetName().Version;

            //log.DebugFormat("[Program.GetApplicationMetrics] Version \"EveJimaSettings.dll\" is {0}", verEvaJimaSettings);
        }
    }
}
