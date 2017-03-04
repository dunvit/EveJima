using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EvaJimaCore;
using log4net;

namespace EveJimaCore
{
    public delegate void DelegateStartProcess(string value);

    class CrestApiListener
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CrestApiListener));

        public void ListenLocalhost(DelegateStartProcess StartPilotAuthorizeFlow)
        {
            try
            {
                var web = new HttpListener();
                const string url = "http://localhost";
                string port = Global.Settings.CCPSSO_AUTH_PORT;
                var prefix = string.Format("{0}:{1}/", url, port);
                
                web.Prefixes.Add(prefix);

                Log.DebugFormat("Listening new ..");

                web.Start();

                while (true)
                {
                    var context = web.GetContext();

                    Task.Run(() =>
                    {
                        var code = "";

                        Log.DebugFormat("Get new request.");

                        foreach (var key in context.Request.QueryString.Keys.Cast<object>().Where(key => key.ToString() == "code"))
                        {
                            code = context.Request.QueryString[key.ToString()];
                        }

                        using (var writer = new StreamWriter(context.Response.OutputStream))
                        {
                            writer.WriteLine("Wormhole Locator authorize complete. Close this tab and return to application.");
                        }
                        context.Response.OutputStream.Close();

                        if (string.IsNullOrEmpty(code) == false)
                        {
                            StartPilotAuthorizeFlow(code);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                //Global.Settings.IsAuthorizationEnabled = false;
                Log.ErrorFormat("[CrestApiListener.ListenLocalhost] IsAuthorizationEnabled set FALSE Critical error = {0}", ex);
            }

            

        }
    }
}
