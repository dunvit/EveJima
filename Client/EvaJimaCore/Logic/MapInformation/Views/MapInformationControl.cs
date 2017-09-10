using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation;
using EveJimaCore.Logic.MapInformation.Views;
using EveJimaUniverse;
using log4net;

namespace TestPlatform.Logic.Views
{
    public partial class MapInformationControl : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MapInformationControl));
        public string SelectedTab { get; set; }

        Dictionary<string, Panel> _informationControls;

        private SolarSystemInformationControl _solarSystemInformationControl;
        private InformationSignaturesView _informationSignaturesView;
        private InformationMapSettingsView _informationMapSettingsView;
        private InformationPilotesView _informationPilotesView;
        private InformationMapBookmarks _informationMapBookmarks;

        public event Action<string> CentreScreenSelectedSystem;

        public event Action<string> CentreScreenLocationSystem;

        public event Action<string> DeleteSelectedSystem;

        public event Action<string> DeathNotice;

        public event Action<string, List<CosmicSignature>> UpdateSignatures;

        public event Action<string> ChangeMapKey;
        public event Action<string> ReloadMap;

        public MapInformationControl()
        {
            InitializeComponent();

            _informationControls = new Dictionary<string, Panel>();
            _solarSystemInformationControl = new SolarSystemInformationControl { Visible = true, Dock = DockStyle.Fill };
            _informationSignaturesView = new InformationSignaturesView { Visible = true, Dock = DockStyle.Fill };
            _informationSignaturesView.UpdateSignatures += Event_UpdateSignatures;

            _informationMapSettingsView = new InformationMapSettingsView { Visible = true, Dock = DockStyle.Fill };
            _informationMapSettingsView.ChangeMapKey += Event_ChangeMapKey;
            _informationMapSettingsView.ReloadMap += Event_ReloadMap;

            _informationPilotesView = new InformationPilotesView { Visible = true, Dock = DockStyle.Fill };

            _informationMapBookmarks = new InformationMapBookmarks { Visible = true, Dock = DockStyle.Fill };

            _solarSystemInformationControl.CentreScreenLocationSystem += Event_CentreScreenLocationSystem;
            _solarSystemInformationControl.CentreScreenSelectedSystem += Event_CentreScreenSelectedSystem;
            _solarSystemInformationControl.DeleteSelectedSystem += Event_DeleteSelectedSystem;
            _solarSystemInformationControl.DeathNotice += Event_DeathNotice;

            var systemInfoPanel = new Panel { Location = new Point(0, 0), Tag = "SolarSystem", Visible = false, Dock = DockStyle.Fill };
            var signaturesPanel = new Panel { Location = new Point(0, 0), Tag = "MapSignatures", Visible = false, Dock = DockStyle.Fill };
            var mapSettingsPanel = new Panel { Location = new Point(0, 0), Tag = "MapSettings", Visible = false, Dock = DockStyle.Fill };
            var pilotesPanel = new Panel { Location = new Point(0, 0), Tag = "Pilotes", Visible = false, Dock = DockStyle.Fill };
            var bookmarksPanel = new Panel { Location = new Point(0, 0), Tag = "Bookmarks", Visible = false, Dock = DockStyle.Fill };

            systemInfoPanel.Controls.Add(_solarSystemInformationControl);
            signaturesPanel.Controls.Add(_informationSignaturesView);
            mapSettingsPanel.Controls.Add(_informationMapSettingsView);
            pilotesPanel.Controls.Add(_informationPilotesView);
            bookmarksPanel.Controls.Add(_informationMapBookmarks);

            _informationControls.Add("SolarSystem", systemInfoPanel);
            _informationControls.Add("MapSignatures", signaturesPanel);
            _informationControls.Add("MapSettings", mapSettingsPanel);
            _informationControls.Add("Pilotes", pilotesPanel);
            _informationControls.Add("Bookmarks", bookmarksPanel);

            Controls.Add(systemInfoPanel);
            Controls.Add(signaturesPanel);
            Controls.Add(mapSettingsPanel);
            Controls.Add(pilotesPanel);
            Controls.Add(bookmarksPanel);

            ActivatePanel("SolarSystem");
        }

        private void Event_ReloadMap(string mapKey)
        {
            ReloadMap(mapKey);
        }

        private void Event_ChangeMapKey(string mapKey)
        {
            ChangeMapKey(mapKey);
        }

        private void Event_UpdateSignatures(string arg1, List<CosmicSignature> arg2)
        {
            UpdateSignatures(arg1, arg2);
        }

        private void Event_DeathNotice(string obj)
        {
            DeathNotice(obj);
        }

        private void Event_DeleteSelectedSystem(string obj)
        {
            DeleteSelectedSystem(obj);
        }

        private void Event_CentreScreenSelectedSystem(string obj)
        {
            CentreScreenLocationSystem(obj);
        }

        private void Event_CentreScreenLocationSystem(string obj)
        {
            CentreScreenSelectedSystem(obj);
        }

        public void ChangeLocation(Map spaceMap)
        {
            if(spaceMap == null) return;

            foreach (var control in _informationControls.Values)
            {
                var controlPart = control.Controls[0] as IMapInformationControl;

                if(controlPart != null) controlPart.ForceRefresh(spaceMap);
            }
        }

        public void ActivatePanel(string panelName)
        {
            foreach (var control in _informationControls.Values)
            {
                if(control.Visible) control.Visible = false;
            }

            _informationControls[panelName].Visible = true;
            _informationControls[panelName].Show();

            SelectedTab = panelName;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapInformationControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Name = "MapInformationControl";
            this.Size = new System.Drawing.Size(269, 304);
            this.Load += new System.EventHandler(this.InformationView_Load);
            this.ResumeLayout(false);

        }


        private void InformationView_Load(object sender, System.EventArgs e)
        {
           
        }

        private void MapInformationControl_Load(object sender, System.EventArgs e)
        {

        }

        public void ForceRefresh(Map spaceMap)
        {
            Log.DebugFormat("[MapInformationControl.ForceRefresh] start");
            ChangeLocation(spaceMap);
            Log.DebugFormat("[MapInformationControl.ForceRefresh] end");
        }
    }
}
