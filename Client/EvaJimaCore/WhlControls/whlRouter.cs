using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlRouter : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        public DelegateContainerActivate OnContainerActivate;

        public whlRouter()
        {
            InitializeComponent();

            gridAllRoutes.BackgroundColor = Color.Black;

            SystemsIdInRoute = new List<string>();

            label3.Text = Global.Messages.Get("Tab_Router_CreateRoute");
            cmdStartRoute.Text = Global.Messages.Get("Tab_Router_SetDestination");
            ejButton1.Text = Global.Messages.Get("Tab_Router_LoadFromFile");
        }

        public override void ActivateContainer()
        {
            txtPilotName.Text = Global.Pilots.Selected.Name;
        }

        private List<string> SystemsIdInRoute;

        private void RouteLoad(string fileName)
        {
            if (File.Exists(fileName) == false) return;

            SystemsIdInRoute = new List<string>();

            gridAllRoutes.Rows.Clear();

            foreach (string line in File.ReadLines(fileName))
            {
                if (line.Trim() != string.Empty)
                {

                    var systemId = Global.Space.GetSystemByName(line.Trim().ToUpper()).Id;

                    SystemsIdInRoute.Add(systemId + ";" + line.Trim());

                    gridAllRoutes.Rows.Add(line.Trim());
                }
            }
        }

        private void ejButton1_Click(object sender, EventArgs e)
        {
            
            var result = openRouteFile.ShowDialog();
            if (result == DialogResult.OK) 
            {
                var file = openRouteFile.FileName;
                try
                {
                    RouteLoad(file);

                    if(SystemsIdInRoute.Count > 0)
                    {
                        cmdStartRoute.Enabled = true;
                        gridAllRoutes.ClearSelection();
                        lblExample.Visible = false;
                    }
                    else
                    {
                        cmdStartRoute.Enabled = false;
                        lblExample.Visible = false;
                    }

                    
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[whlRouter.ejButton1_Click] Critical error. Exception is {0}",  ex.Message);
                }
            }
        }


        private void cmdStartRoute_Click_1(object sender, EventArgs e)
        {
            if (SystemsIdInRoute.Count == 0) return;

            try
            {
                cmdStartRoute.Enabled = false;
                ejButton1.Enabled = false;

                var systemsCount = 0;

                gridAllRoutes.Rows.Clear();

                Global.Pilots.Selected.EsiData.SetWaypoint("false", "true", Global.Space.GetSystemByName("KF1-DU").Id);

                //CrestApiFunctions.SetWaypoint(Global.Pilots.Selected, "true", Global.Space.GetSystemByName("KF1-DU").Id);

                foreach (var solarSystem in SystemsIdInRoute)
                {
                    var solarSystemId = solarSystem.Split(';')[0];
                    var solarSystemName = solarSystem.Split(';')[1];

                    var clearOtherWaypoints = systemsCount != 0 ? "false" : "true";

                    systemsCount++;

                    Global.Pilots.Selected.EsiData.SetWaypoint("true", clearOtherWaypoints, solarSystemId);

                    Thread.Sleep(1000);

                    

                    gridAllRoutes.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        gridAllRoutes.Rows.Add("Added solar system '" + solarSystemName + "' for way point " + systemsCount);
                        gridAllRoutes.Refresh();
                    });

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlRouter.cmdStartRoute_Click_1] Critical error. Exception is {0}", ex.Message);
            }

            ejButton1.Enabled = true;
        }

        private void whlRouter_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
