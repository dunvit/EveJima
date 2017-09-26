using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.Navigator;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class EveCrlPathfinder : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");
        private string _location;
        private BindingSource gridDataSource = new BindingSource();

        public EveCrlPathfinder()
        {
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Bisque;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridView1.EnableHeadersVisualStyles = false;

            FillBookmarksContainer(new List<Path>());
        }

        private void FillBookmarksContainer(IEnumerable<Path> pathes)
        {
            gridDataSource = new BindingSource();

            if(pathes != null)
            {
                foreach (var path in pathes.OrderBy(data => data.Jumps))
                {
                    gridDataSource.Add(new Path
                    {
                        SystemName = path.SystemName,
                        Name = path.Name,
                        Note = path.Note,
                        Jumps = path.Jumps,
                        Pilotes = path.Pilotes,
                        ShipKills = path.ShipKills,
                        PodKills = path.PodKills,
                        NpcKills = path.NpcKills
                    });
                }
                
            }

            dataGridView1.Columns.Clear();

            DataGridViewColumn Jumps = new DataGridViewTextBoxColumn();
            Jumps.Width = 60;
            Jumps.DataPropertyName = "Jumps";
            Jumps.Name = "Jumps";
            Jumps.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Jumps);



            DataGridViewColumn code = new DataGridViewTextBoxColumn();
            code.Width = 120;
            code.DataPropertyName = "SystemName";
            code.Name = "System";
            code.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(code);

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 280;
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(column);

            DataGridViewColumn Note = new DataGridViewTextBoxColumn();
            Note.Width = 240;
            Note.DataPropertyName = "Note";
            Note.Name = "Note";
            Note.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Note);



            DataGridViewColumn Pilotes = new DataGridViewTextBoxColumn();
            Pilotes.Width = 50;
            Pilotes.DataPropertyName = "Pilotes";
            Pilotes.Name = "Pilotes";
            Pilotes.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Pilotes);

            DataGridViewColumn ShipKills = new DataGridViewTextBoxColumn();
            ShipKills.Width = 50;
            ShipKills.DataPropertyName = "ShipKills";
            ShipKills.Name = "Ship";
            ShipKills.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(ShipKills);

            DataGridViewColumn NpcKills = new DataGridViewTextBoxColumn();
            NpcKills.Width = 50;
            NpcKills.DataPropertyName = "NpcKills";
            NpcKills.Name = "Npc";
            NpcKills.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(NpcKills);



            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = gridDataSource;


            dataGridView1.ClearSelection();
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private IEnumerable<Path> GetPathes(string location, Universe universe, PilotEntity pilot)
        {
            try
            {
                var pathFinder = new PathFinder(universe);
                var bookmarksFolderId = "0";
                var bookmarksFoldersFromApi = pilot.EsiData.GetBookmarksFolders(pilot.Id);

                foreach (var bookmark in bookmarksFoldersFromApi.Where(bookmark => bookmark.Item1 == "[EveJima]"))
                {
                    bookmarksFolderId = bookmark.Item2;
                }

                var bookmarksFromApi = pilot.EsiData.GetBookmarks(pilot.Id, bookmarksFolderId);

                return pathFinder.GetPathes(bookmarksFromApi, Global.Pilots.Selected.LocationCurrentSystemName, 5);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[InformationMapBookmarks.GetPathes] Critical error. location {1} Exception {0}", ex, location);

                return null;
            }

        }

        private void Event_RefreshBookmarks(object sender, EventArgs e)
        {
            Log.InfoFormat("[InformationMapBookmarks.Event_RefreshBookmarks] Critical error. Location {0}", _location);

            dataGridView1.DataSource = null;

            var patches = GetPathes(_location, Global.Space, Global.Pilots.Selected);

            FillBookmarksContainer(patches);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var solarSystemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                var solarSystem = Global.Space.GetSystemByName(solarSystemName);

                if (solarSystem != null)
                {
                    Global.Pilots.Selected.EsiData.SetWaypoint("false", "true", solarSystem.Id);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[InformationMapBookmarks.dataGridView1_CellDoubleClick] Critical error. Exception {0}", ex);
            }
        }
    }
}
