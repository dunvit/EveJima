using System;
using System.IO;
using System.Windows.Forms;
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
                using (var reader = new StreamReader("EveJimaEnvironment.txt"))
                {
                    dynamic data = JObject.Parse(reader.ReadToEnd());

                    IsShowFavorites = data.IsShowFavorites != "false";

                    try
                    {
                        LocationMaximizeX = data.LocationMaximizeX;
                        LocationMaximizeY = data.LocationMaximizeY;
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("[WorkEnvironment.WorkEnvironment] Critical error. Exception {0}", ex);
                    }

                    try
                    {
                        IsPinned = data.IsPinned;
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("[WorkEnvironment.WorkEnvironment] Critical error. Exception {0}", ex);
                    }

                }

                var screenCounts = 0;

                foreach (var screen in Screen.AllScreens)
                {
                    screenCounts++;
                }

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

        public void SaveChanges()
        {
            File.WriteAllText(@"EveJimaEnvironment.txt", JsonConvert.SerializeObject(this));
        }
    }
}
