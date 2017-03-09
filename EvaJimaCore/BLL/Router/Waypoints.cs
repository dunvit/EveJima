using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.BLL.Router
{
    public class Waypoints
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Waypoints));

        public List<string> List { get; set; }

        public Waypoints()
        {
            LoadWaypoints();
        }

        private void LoadWaypoints()
        {
            List = new List<string>();

            if (Directory.Exists(@"Data/Routes/") == false)
            {
                Directory.CreateDirectory(@"Data/Routes/");
            }

            var files = new DirectoryInfo(@"Data/Routes/").GetFiles("*.*"); //Getting Text files

            foreach (var file in files)
            {
                List.Add(file.Name);
            }
        }

        public void Create(string name, List<string> weypoints)
        {
            if (Directory.Exists(@"Data/Routes/") == false)
            {
                Directory.CreateDirectory(@"Data/Routes/");
            }

            if (File.Exists(@"Data/Routes/" + name))
            {
                File.Delete("Data/Routes/" + name);
            }

            using (TextWriter tw = new StreamWriter(@"Data/Routes/" + name))
            {
                foreach (String s in weypoints.ToArray())
                    tw.WriteLine(s);
            }

            LoadWaypoints();
        }

        public void Delete(string route)
        {
            if (File.Exists(@"Data/Routes/" + route))
            {
                File.Delete("Data/Routes/" + route);

                LoadWaypoints();
            }
        }

        public List<string> GetWaypointsForRoute(string selectedRoute)
        {
            var waypoints = new List<string>();

            if (File.Exists(@"Data/Routes/" + selectedRoute) == false) return waypoints;

            waypoints.AddRange(File.ReadLines(@"Data/Routes/" + selectedRoute).Where(line => line.Trim() != string.Empty));

            return waypoints;
        }

        public int SetDestinationByRoute(string selectedRoute, PilotEntity pilot)
        {
            var systemsCount = 0;

            if (File.Exists(@"Data/Routes/" + selectedRoute) == false) return systemsCount;

            CrestApiFunctions.SetWaypoint(pilot, "true", Global.Space.BasicSolarSystems["KF1-DU"]);

            foreach (string line in File.ReadLines(@"Data/Routes/" + selectedRoute))
            {
                if (line.Trim() != string.Empty)
                {
                    var clearOtherWaypoints = systemsCount != 0 ? "false" : "true";

                    systemsCount++;

                    var systemId = Global.Space.BasicSolarSystems[line.ToUpper()];

                    CrestApiFunctions.SetWaypoint(pilot, clearOtherWaypoints, systemId);

                    Thread.Sleep(1000);
                }
            }

            return systemsCount;
        }
    }
}
