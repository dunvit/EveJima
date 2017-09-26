using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;

namespace EveJimaCore.Logic.ToolBar
{
    public partial class MapToolbarControl : UserControl
    {
        readonly Dictionary<string, Button> _toolbarControls = new Dictionary<string, Button>();

        readonly Hashtable _metadata = new Hashtable();

        public event Action<string, PanelMetaData> OnSelectTab;

        private Action<PanelMetaData> _refreshOwnerWindow;
        public string SelectedTab { get; set; }

        public MapToolbarControl()
        {
            InitializeComponent();

            cmdAuthorization.Tag = "Authorization";
            cmdLocation.Tag = "Location";
            cmdBrowser.Tag = "Browser";
            cmdBookmarks.Tag = "Bookmarks";
            cmdSolarSystem.Tag = "SolarSystem";
            cmdSettings.Tag = "Settings";
            cmdPathfinder.Tag = "Pathfinder";

            _toolbarControls.Add("Authorization", cmdAuthorization);
            _toolbarControls.Add("Location", cmdLocation);
            _toolbarControls.Add("Browser", cmdBrowser);
            _toolbarControls.Add("Bookmarks", cmdBookmarks);
            _toolbarControls.Add("SolarSystem", cmdSolarSystem);
            _toolbarControls.Add("Settings", cmdSettings);
            _toolbarControls.Add("Pathfinder", cmdPathfinder);

            var panelBrowser = new PanelMetaData { Size = new Size(900, 700), IsResizeEnabled = true, Enabled = true };

            _metadata.Add("Authorization", new PanelMetaData { Size = new Size(564, 325) });


            var locationControlSize = new Size(1050, 612);

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (Global.ApplicationSettings.IsUseMap == false) locationControlSize = new Size(564, 325);
            }

            _metadata.Add("Location", new PanelMetaData { Size = locationControlSize, IsResizeEnabled = true, Enabled = false });
            _metadata.Add("Browser", panelBrowser);
            _metadata.Add("Bookmarks", new PanelMetaData { Size = new Size(564, 325), IsResizeEnabled = false, Enabled = true });
            _metadata.Add("SolarSystem", new PanelMetaData { Size = new Size(564, 325), IsResizeEnabled = false, Enabled = true });
            _metadata.Add("Settings", new PanelMetaData { Size = new Size(564, 325), IsResizeEnabled = false, Enabled = true });
            _metadata.Add("Pathfinder", new PanelMetaData { Size = new Size(900, 450), IsResizeEnabled = false, Enabled = false });
            _metadata.Add("Version", new PanelMetaData { Size = new Size(900, 500), IsResizeEnabled = false, Enabled = true });

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (Global.ApplicationSettings.IsUseBrowser == false) panelBrowser.Enabled = false;
            }

            InitializeEvents();
        }

        public void InitializeEvents()
        {
            foreach (var control in _toolbarControls.Values)
            {
                control.Click += Event_ClickOnPanelOpenerButton;
            }
        }

        internal void InitializeExternalEvents(Action<PanelMetaData> resizeWindow)
        {
            _refreshOwnerWindow = resizeWindow;
        }

        private void Event_ClickOnPanelOpenerButton(object sender, EventArgs e)
        {
            var element = ((Control)sender).Tag as string;

            var panelMetaData = (PanelMetaData)_metadata[element];

            if(panelMetaData.Enabled == false) return;

            ActivatePanel(element);
        }

        public void EnablePanel(string panelName)
        {
            var metaData = (PanelMetaData)_metadata[panelName];

            metaData.Enabled = true;

            foreach (var key in _toolbarControls.Keys)
            {
                var panelMetaData = (PanelMetaData)_metadata[key];

                var button = _toolbarControls[key];

                if (panelMetaData.Enabled)
                {
                    button.ForeColor = Color.Silver;
                    button.Cursor = Cursors.Hand;
                }
                else
                {
                    button.ForeColor = Color.DimGray;
                    button.Cursor = DefaultCursor;
                }
            }

            _toolbarControls[SelectedTab].ForeColor = Color.DarkGoldenrod;
        }

        public void ActivatePanel(string panelName)
        {
            SelectedTab = panelName;

            foreach (var key in _toolbarControls.Keys)
            {
                var panelMetaData = (PanelMetaData)_metadata[key];

                var button = _toolbarControls[key];

                if (panelMetaData.Enabled)
                {
                    button.ForeColor = Color.Silver;
                }
                else
                {
                    button.ForeColor = Color.DimGray;
                    button.Cursor = DefaultCursor;
                }

            }

            if(_toolbarControls.ContainsKey(panelName)) _toolbarControls[panelName].ForeColor = Color.DarkGoldenrod;

            SetOwnerSize(panelName);

            var metaData = (PanelMetaData)_metadata[panelName];

            OnSelectTab?.Invoke(panelName, metaData);

            
        }

        private void SetOwnerSize(string panelName)
        {
            var panelMetaData = (PanelMetaData)_metadata[panelName];

            _refreshOwnerWindow?.Invoke(panelMetaData);
        }

        public void ResetOwnerSize(int width, int height)
        {
            if(SelectedTab == null) return;

            var panelMetaData = (PanelMetaData)_metadata[SelectedTab];

            if(panelMetaData.IsResizeEnabled)
                panelMetaData.Size = new Size(width, height);
        }



    }
}
