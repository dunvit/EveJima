using System;
using System.Threading;
using log4net;
using Microsoft.Win32;

namespace EveJimaCore.BLL.Browser
{
    public class Interceptor
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public bool IsStarted;

        private readonly string _path;


        private readonly bool _isActive;

        public Interceptor(bool isActive)
        {
            _isActive = isActive;
            // Remove old reg intercept actions.
            StopIntercepting();

            _path = AppDomain.CurrentDomain.BaseDirectory + @"EveJimaBrowserInterceptor.exe";
        }

        public void StopIntercepting()
        {
            StopIntercepting("chrome.exe");

            StopIntercepting("firefox.exe");
        }

        private void StopIntercepting(string browser)
        {
            string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + browser;

            try
            {
                Thread.Sleep(500);

                using (var key = Registry.LocalMachine.OpenSubKey(keyName, true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("Debugger");
                    }
                }
            }
            catch (Exception e)
            {
                if(e.Message != "No value exists with that name.")
                {
                    Log.Error("[Interceptor.StopIntercepting] Critical error " + e + "");
                }
            }

            IsStarted = false;
        }

        public void StartIntercepting()
        {
            StartIntercepting("chrome.exe");
            StartIntercepting("firefox.exe");
        }

        private void StartIntercepting(string browser)
        {
            try
            {
                var mykey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + browser);

                if (mykey == null) return;

                Log.Error("[Interceptor.StartIntercepting] mykey " + mykey + "");
                Log.Error("[Interceptor.StartIntercepting] path " + _path + "");

                mykey.SetValue("Debugger", _path);
                mykey.Close();
            }
            catch (Exception e)
            {
                Log.Error("[Interceptor.StartIntercepting] Critical error " + e + "");
            }


            IsStarted = true;
        }
    }
}
