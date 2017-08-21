using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Router;
using EveJimaCore.UiTools;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlRouter : BaseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlRouter));

        public DelegateContainerActivate OnContainerActivate;

        private readonly Waypoints _waypoints = new Waypoints();

        public whlRouter()
        {
            InitializeComponent();

            gridAllRoutes.BackgroundColor = Color.Black;
            gridSelectedRoute.BackgroundColor = Color.Black;
            gridWaypoints.BackgroundColor = Color.Black;

            gridSelectedRoute.RowsDefaultCellStyle = gridAllRoutes.RowsDefaultCellStyle;
            gridWaypoints.RowsDefaultCellStyle = gridAllRoutes.RowsDefaultCellStyle;

            cmdShowAllRoutes.Focus();

            
        }

        public override void ActivateContainer()
        {
            ShowContainerAllRoutes();
        }

        private void ShowContainerAllRoutes()
        {
            containerRoute.Visible = false;
            containerCreateRoute.Visible = false;

            containerShowAllRoutes.Location = new Point(123, 6);
            containerShowAllRoutes.Visible = true;

            gridAllRoutes.DataSource = null;
            gridAllRoutes.Refresh();

            gridAllRoutes.DataSource = _waypoints.List.Select(x => new { Route = x }).ToList();
            gridAllRoutes.Refresh();

            gridAllRoutes.Columns[0].Width = 332;

            gridAllRoutes.ClearSelection();
            gridAllRoutes.CurrentCell = null;

            
        }

        private void ShowContainerRoute(string selectedRoute)
        {
            containerShowAllRoutes.Visible = false;
            containerCreateRoute.Visible = false;

            containerRoute.Location = new Point(123, 6);
            containerRoute.Visible = true;

            gridSelectedRoute.DataSource = null;
            gridSelectedRoute.Refresh();

            gridSelectedRoute.DataSource = _waypoints.GetWaypointsForRoute(selectedRoute).Select(x => new { Waypoint = x }).ToList();
            gridSelectedRoute.Refresh();

            gridSelectedRoute.Columns[0].Width = 308;

            if (Global.Pilots.Selected != null)
            {
                whlButton1.Text = @"Set destination for " + Global.Pilots.Selected.Name;
            }

            gridSelectedRoute.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
            gridSelectedRoute.ClearSelection();
        }

        private void ShowContainerCreateRoute()
        {
            containerRoute.Visible = false;
            containerShowAllRoutes.Visible = false;

            txtRemoveWormholeName.Text = "";

            gridWaypoints.Rows.Clear();
            gridWaypoints.Refresh();

            gridWaypoints.Columns[0].Width = 308;

            containerCreateRoute.Location = new Point(123, 6);
            containerCreateRoute.Visible = true;
        }

        private void Event_Return(object sender, EventArgs e)
        {
            OnContainerActivate("Location");
        }

        private void Event_ShowAllRoutes(object sender, EventArgs e)
        {
            ShowContainerAllRoutes();
        }

        private void EventSetDestination(object sender, EventArgs e)
        {
            if (gridAllRoutes.CurrentCell == null)
            {
                MessageBoxLoader.Show("Please select route.", this);
                return;
            }

            if (string.IsNullOrEmpty(gridAllRoutes.CurrentCell.Value.ToString()) == false)
            {
                whlButton1.IsActive = false;
                int count = _waypoints.SetDestinationByRoute(gridAllRoutes.CurrentCell.Value.ToString(), Global.Pilots.Selected);
                whlButton1.IsActive = true;
                MessageBox.Show(String.Format("Route added to pilot {0}  with {1} waypoints.", Global.Pilots.Selected.Name, count));
                ShowContainerAllRoutes();
            }
        }

        private void Event_ShowRoute(object sender, EventArgs e)
        {
            if (gridAllRoutes.CurrentCell == null)
            {
                MessageBoxLoader.Show(@"Please select route.", this);
                return;
            }

            if (string.IsNullOrEmpty(gridAllRoutes.CurrentCell.Value.ToString()) == false)
            {
                txtRouteName.Text = gridAllRoutes.CurrentCell.Value.ToString();
                ShowContainerRoute(gridAllRoutes.CurrentCell.Value.ToString());
            }
        }

        private void Event_DeleteRoute(object sender, EventArgs e)
        {
            if (gridAllRoutes.CurrentCell == null)
            {
                MessageBoxLoader.Show(@"Please select route.", this);
                return;
            }

            if (string.IsNullOrEmpty(gridAllRoutes.CurrentCell.Value.ToString()) == false)
            {
                _waypoints.Delete(gridAllRoutes.CurrentCell.Value.ToString());

                ShowContainerAllRoutes();
            }
        }

        private void Event_SelectCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            try
            {
                if (gridAllRoutes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    var value = gridAllRoutes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (value != string.Empty)
                    {
                        cmdSetDesination.IsActive = true;
                        cmdDeleteRoute.IsActive = true;
                        cmdShowRoute.IsActive = true;
                    }
                    else
                    {
                        cmdSetDesination.IsActive = false;
                        cmdDeleteRoute.IsActive = false;
                        cmdShowRoute.IsActive = false;
                    }
                }
                else
                {
                    cmdSetDesination.IsActive = false;
                    cmdDeleteRoute.IsActive = false;
                    cmdShowRoute.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlRouter.Event_SelectCell] Critical error = {0}", ex);
            }

            
        }

        private void Event_Create(object sender, EventArgs e)
        {
            if (txtRemoveWormholeName.Text.Trim() == string.Empty)
            {
                MessageBoxLoader.Show(@"You need set name for route.", this);
                txtRemoveWormholeName.Focus();
                return;
            }

            if (gridWaypoints.Rows.Count < 1)
            {
                MessageBoxLoader.Show(@"Add waypoints to route.", this);
                return;
            }

            var data = new List<string>();

            foreach (DataGridViewRow row in gridWaypoints.Rows)
            {
                if (row.Cells["clmSolarSystemName"].Value != null)
                {
                    data.Add(row.Cells["clmSolarSystemName"].Value.ToString());
                }
            }

            _waypoints.Create(txtRemoveWormholeName.Text.Trim(), data);

            ShowContainerAllRoutes();
        }

        private void Event_ContainerShowCreateRoute(object sender, EventArgs e)
        {
            ShowContainerCreateRoute();
        }

        private void Event_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var solarSystemName = (string)e.FormattedValue;

            if (solarSystemName == "") return;

            if (Global.Space.GetSystemByName(solarSystemName.ToUpper()) == null)
            {
                e.Cancel = true;
                MessageBoxLoader.Show(string.Format("Solar system with name \"" + solarSystemName + "\" is not exist."), this);
            }
        }

        private void Event_SetDestinationForCurrentRoute(object sender, EventArgs e)
        {
            whlButton1.IsActive = false;
            int count = _waypoints.SetDestinationByRoute(txtRouteName.Text, Global.Pilots.Selected);
            whlButton1.IsActive = true;
            MessageBoxLoader.Show(String.Format("Route added to pilot {0}  with {1}  waypoints.", Global.Pilots.Selected.Name, count), this);

        }

    }
}
