using System;
using System.IO;
using System.Windows.Forms;
using EvaJimaCore;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EveJimaCore
{
    public class WorkEnvironment
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WorkEnvironment));

        public bool IsShowFavorites { get; set; }

        public bool IsPinned { get; set; }

        public int LocationMaximizeX { get; set; }
        public int LocationMaximizeY { get; set; }

        public WorkEnvironment()
        {
            Log.Debug("[WorkEnvironment.WorkEnvironment] Start load settings");

            try
            {
                IsShowFavorites = Global.ApplicationSettings.Browser_IsShowFavorites;
                LocationMaximizeX = Global.ApplicationSettings.Browser_LocationMaximizeX;
                LocationMaximizeY = Global.ApplicationSettings.Browser_LocationMaximizeY;
                IsPinned = Global.ApplicationSettings.Browser_IsPinned;

                var screenCounts = Screen.AllScreens.Length;

                if (screenCounts == 1)
                {
                    if (LocationMaximizeX < 0) LocationMaximizeX = 0;
                    if (LocationMaximizeX > Screen.PrimaryScreen.WorkingArea.Width) LocationMaximizeX = 0;
                    
                    if (LocationMaximizeY < 0) LocationMaximizeY = 0;
                    if (LocationMaximizeY > Screen.PrimaryScreen.WorkingArea.Height) LocationMaximizeY = 0;
                }

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WorkEnvironment.WorkEnvironment] Critical error. Exception {0}", ex);
            }
        }

    }
}
