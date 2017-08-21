using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL.Map;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.Logic.MapInformation.Views
{
    public partial class InformationPilotesView : UserControl, IMapInformationControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InformationPilotesView));

        private BindingSource _pilotsSource = new BindingSource();

        Map SpaceMap { get; set; }

        public InformationPilotesView()
        {
            InitializeComponent();
        }

        public void ForceRefresh(Map spaceMap)
        {
            Log.DebugFormat($"[InformationPilotesView.ForceRefresh] start for map {spaceMap.Key} and pilot {spaceMap.ActivePilot}");

            FillPilotsContainer(spaceMap.Pilotes);

            Log.DebugFormat($"[InformationPilotesView.ForceRefresh] end for map {spaceMap.Key} and pilot {spaceMap.ActivePilot}");

            SpaceMap = spaceMap;
        }

        private void FillPilotsContainer(List<PilotLocation> pilots)
        {
            _pilotsSource = new BindingSource();

            foreach (var pilot in pilots)
            {
                _pilotsSource.Add(new Pilot { Name = pilot.Name, Location = pilot.System, LastUpdate = pilot.LastUpdate.ToShortTimeString() });
            }

            if (dataGridView1.Columns.Contains("Name")) dataGridView1.Columns.Remove("Name");
            if (dataGridView1.Columns.Contains("Location")) dataGridView1.Columns.Remove("Location");
            if (dataGridView1.Columns.Contains("LastUpdate")) dataGridView1.Columns.Remove("LastUpdate");

            DataGridViewColumn columnName = new DataGridViewTextBoxColumn();
            columnName.Width = 130;
            columnName.DataPropertyName = "Name";
            columnName.Name = "Name";
            dataGridView1.Columns.Add(columnName);

            DataGridViewColumn location = new DataGridViewTextBoxColumn();
            location.Width = 65;
            location.DataPropertyName = "Location";
            location.Name = "Location";
            dataGridView1.Columns.Add(location);

            DataGridViewColumn lastUpdate = new DataGridViewTextBoxColumn();
            lastUpdate.Width = 70;
            lastUpdate.DataPropertyName = "LastUpdate";
            lastUpdate.Name = "LastUpdate";
            dataGridView1.Columns.Add(lastUpdate);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _pilotsSource;

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            var system = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            var solarSystem = SpaceMap.GetSystem(system);

            FillInformationForCurrentSolarSystems(solarSystem);

            Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName = system;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FillInformationForCurrentSolarSystems(EveJimaUniverse.System solarSystem)
        {
            if (solarSystem == null) return;

            if (InvokeRequired)
            {
                Invoke(new Action(() => FillInformationForCurrentSolarSystems(solarSystem)));
                return;
            }

            try
            {
                txtSolarSystemName.Text = solarSystem.Name;


                txtSolarSystemClass.Text = solarSystem.Class;

                if (solarSystem.Effect != null)
                {
                    txtSolarSystemEffect.Text = solarSystem.Effect.Trim() == "" ? "None" : solarSystem.Effect.Trim();
                }
                else
                {
                    txtSolarSystemEffect.Text = "";
                }

                if (solarSystem.Region != null)
                {
                    txtSolarSystemRegion.Text = solarSystem.Region.Replace(" Unknown (", "").Replace(")", "");
                }
                else
                {
                    txtSolarSystemRegion.Text = "";
                }


                txtSolarSystemStaticI.Text = "";
                txtSolarSystemStaticII.Text = "";

                txtSolarSystemStaticI.Visible = false;
                txtSolarSystemStaticII.Visible = false;

                label1.Visible = false;

                txtSolarSystemName.ForeColor = Tools.GetColorBySolarSystem(solarSystem.Security.ToString());

                if (string.IsNullOrEmpty(solarSystem.Static) == false)
                {
                    var wormholeI = Global.Space.WormholeTypes[solarSystem.Static.Trim()];

                    txtSolarSystemStaticI.Text = wormholeI.Name + " " + wormholeI.LeadsTo;
                    txtSolarSystemStaticI.Visible = true;
                    txtSolarSystemStaticI.ForeColor = Tools.GetColorBySolarSystem(wormholeI.LeadsTo);

                    //toolTip1.SetToolTip(txtSolarSystemStaticI, "Max Stable Mass=" + wormholeI.TotalMass + "\r\nMax Jump  Mass=" + wormholeI.SingleMass + "\r\nMax Life time =" + wormholeI.Lifetime);
                }

                if (string.IsNullOrEmpty(solarSystem.Static2) == false)
                {
                    label1.Visible = true;
                    var wormholeII = Global.Space.WormholeTypes[solarSystem.Static2.Trim()];

                    txtSolarSystemStaticII.Text = wormholeII.Name + " " + wormholeII.LeadsTo;
                    txtSolarSystemStaticII.Visible = true;
                    txtSolarSystemStaticII.ForeColor = Tools.GetColorBySolarSystem(wormholeII.LeadsTo);

                    //toolTip2.SetToolTip(txtSolarSystemStaticII, "Max Stable Mass=" + wormholeII.TotalMass + "\r\nMax Jump  Mass=" + wormholeII.SingleMass + "\r\nMax Life time =" + wormholeII.Lifetime);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[SolarSystemInformationControl.FillInformationForCurrentSolarSystems] Critical error. Exception {0}", ex);
            }
        }
    }

    internal struct Pilot
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string LastUpdate { get; set; }
    }
}
