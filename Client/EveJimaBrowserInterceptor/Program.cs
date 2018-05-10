using System;
using System.IO;
using System.Windows.Forms;

namespace EveJimaBrowserInterceptor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"Browser\History\";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            if (args.Length == 3)
            {
                path = path + DateTime.Now.Ticks + ".url";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(args[2]);
                    }
                }
            }

            Application.Exit();
        }
    }
}
