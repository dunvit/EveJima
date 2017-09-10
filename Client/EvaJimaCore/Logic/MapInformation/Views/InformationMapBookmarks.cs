using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.Map;
using EveJimaCore.BLL.Navigator;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.Logic.MapInformation.Views
{
    public partial class InformationMapBookmarks : UserControl, IMapInformationControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");
        private string _location;
        private BindingSource gridDataSource = new BindingSource();

        public InformationMapBookmarks()
        {
            InitializeComponent();

            FillBookmarksContainer(new List<Path>());
        }

        public void ForceRefresh(Map spaceMap)
        {
            _location = spaceMap.LocationSolarSystemName;

            try
            {
                cmdRefreshBookmarks.Value = "Reload";
                cmdRefreshBookmarks.Visible = true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[InformationMapBookmarks.ForceRefresh] Critical error. Exception {0}", ex);
            }

        }

        private void Event_RefreshBookmarks(object sender, EventArgs e)
        {
            Log.InfoFormat("[InformationMapBookmarks.Event_RefreshBookmarks] Critical error. Location {0}", _location);

            dataGridView1.DataSource = null;

            var patches = GetPathes(_location, Global.Space, Global.Pilots.Selected);

            FillBookmarksContainer(patches);
        }

        private void FillBookmarksContainer(IEnumerable<Path> pathes)
        {
            gridDataSource = new BindingSource();

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
                //gridDataSource.Add(path);
            }

            dataGridView1.Columns.Clear();

            DataGridViewColumn Jumps = new DataGridViewTextBoxColumn();
            Jumps.Width = 20;
            Jumps.DataPropertyName = "Jumps";
            Jumps.Name = "Jumps";
            Jumps.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Jumps);

            

            DataGridViewColumn code = new DataGridViewTextBoxColumn();
            code.Width = 60;
            code.DataPropertyName = "SystemName";
            code.Name = "System";
            code.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(code);

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 80;
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(column);

            DataGridViewColumn Note = new DataGridViewTextBoxColumn();
            Note.Width = 40;
            Note.DataPropertyName = "Note";
            Note.Name = "Note";
            Note.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Note);

            

            DataGridViewColumn Pilotes = new DataGridViewTextBoxColumn();
            Pilotes.Width = 30;
            Pilotes.DataPropertyName = "Pilotes";
            Pilotes.Name = "Pilotes";
            Pilotes.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(Pilotes);

            DataGridViewColumn ShipKills = new DataGridViewTextBoxColumn();
            ShipKills.Width = 30;
            ShipKills.DataPropertyName = "ShipKills";
            ShipKills.Name = "Ship";
            ShipKills.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(ShipKills);

            DataGridViewColumn NpcKills = new DataGridViewTextBoxColumn();
            NpcKills.Width = 30;
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

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                var color = Color.FromArgb(14, 14, 14);
                Brush brush = new SolidBrush(color);

                e.PaintBackground(e.CellBounds, true);
                e.Graphics.FillRectangle(brush, e.CellBounds);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Silver, 5, 5);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }

        private IEnumerable<Path> GetPathes(string location, Universe universe, PilotEntity pilot)
        {
            try
            {
                var pathFinder = new PathFinder(universe);
                var bookmarksFolderId = "0";
                var bookmarksFoldersFromApi = pilot.EsiData.GetBookmarksFolders(pilot.Id);

                foreach(var bookmark in bookmarksFoldersFromApi.Where(bookmark => bookmark.Item1 == "[EveJima]"))
                {
                    bookmarksFolderId = bookmark.Item2;
                }

                var bookmarksFromApi = pilot.EsiData.GetBookmarks(pilot.Id, bookmarksFolderId);

                return pathFinder.GetPathes(bookmarksFromApi, location, 5);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[InformationMapBookmarks.GetPathes] Critical error. location {1} Exception {0}", ex, location);

                return null;
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var solarSystemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                var solarSystem = Global.Space.GetSystemByName(solarSystemName);

                if(solarSystem != null)
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
