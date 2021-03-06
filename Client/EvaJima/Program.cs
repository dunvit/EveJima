﻿using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EvaJimaCore;
using EveJimaCore;
using log4net;

namespace EveJima
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var log = LogManager.GetLogger(typeof(Program));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log.Debug("----------------------------------------------------------------------------");
            log.Debug("[Program.Main] Start application EvaJima");

            try
            {
                Application.Run(new WormholeNavigator.FormMainMenu());
            }
            catch(Exception e)
            {
                log.Error("[Program.Main] Critical error: " + e);
            }
        }

        private static void InitializeBrowserEmulation()
        {
            if (!WebEmulator.IsBrowserEmulationSet())
            {
                WebEmulator.SetBrowserEmulationVersion();
            }
        }

        private static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings.Get(keyName);

            return defaultValue;
        }

    }
}
