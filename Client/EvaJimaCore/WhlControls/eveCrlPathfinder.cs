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
        private BindingSource _gridDataSource = new BindingSource();

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
            _gridDataSource = new BindingSource();

            if(pathes != null)
            {
                foreach (var path in pathes.OrderBy(data => data.Jumps))
                {
                    _gridDataSource.Add(new Path
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

            DataGridViewColumn jumps = new DataGridViewTextBoxColumn
            {
                Width = 60,
                DataPropertyName = "Jumps",
                Name = "Jumps"
            };
            jumps.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(jumps);



            DataGridViewColumn code = new DataGridViewTextBoxColumn
            {
                Width = 120,
                DataPropertyName = "SystemName",
                Name = "System"
            };
            code.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(code);

            DataGridViewColumn column = new DataGridViewTextBoxColumn
            {
                Width = 280,
                DataPropertyName = "Name",
                Name = "Name"
            };
            column.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(column);

            DataGridViewColumn note = new DataGridViewTextBoxColumn
            {
                Width = 240,
                DataPropertyName = "Note",
                Name = "Note"
            };
            note.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(note);



            DataGridViewColumn pilots = new DataGridViewTextBoxColumn
            {
                Width = 50,
                DataPropertyName = "Pilotes",
                Name = "Pilotes"
            };
            pilots.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(pilots);

            DataGridViewColumn shipsKills = new DataGridViewTextBoxColumn
            {
                Width = 50,
                DataPropertyName = "ShipKills",
                Name = "Ships"
            };
            shipsKills.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(shipsKills);

            DataGridViewColumn npcKills = new DataGridViewTextBoxColumn
            {
                Width = 50,
                DataPropertyName = "NpcKills",
                Name = "Npc"
            };
            npcKills.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns.Add(npcKills);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _gridDataSource;

            dataGridView1.ClearSelection();
        }

        private IEnumerable<Path> GetPathes(string location, EveJimaUniverse.UniverseEntity universeEntity, PilotEntity pilot)
        {
            try
            {
                var pathFinder = new PathFinder(universeEntity);
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
