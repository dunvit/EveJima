using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore.Logic.ToolBar
{
    public partial class MapToolbarControl : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        readonly Dictionary<string, Control> _toolbarControls = new Dictionary<string, Control>();

        readonly Hashtable _metadata = new Hashtable();

        public event Action<string, PanelMetaData> OnSelectTab;

        private Action<PanelMetaData> _refreshOwnerWindow;
        public string SelectedTab { get; set; }

        public MapToolbarControl()
        {
            InitializeComponent();

            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_Information"), Value = "SolarSystem" });
            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_Location"), Value = "Location" });
            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_Router"), Value = "Router" });
            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_TravelHistory"), Value = "TravelHistory" });
            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_PilotsInfo"), Value = "PilotInfo" });
            cmdMenuElements.AddItem(new ejcComboboxItem { Text = Global.Messages.Get("Tab_WormholeInfo"), Value = "WormholeInfo" });

            cmdMenuElements.ElementChanged += elementChanged_Event;

            cmdAuthorization.Tag = "Authorization";
            cmdLocation.Tag = "Location";
            cmdBrowser.Tag = "Browser";
            cmdBookmarks.Tag = "Bookmarks";
            cmdMenuElements.Tag = "SolarSystem";
            cmdSettings.Tag = "Settings";
            cmdPathfinder.Tag = "Pathfinder";

            cmdAuthorization.Text = Global.Messages.Get("Tab_Pilots");
            cmdMenuElements.Text = Global.Messages.Get("Tab_Information");
            cmdBookmarks.Text = Global.Messages.Get("Tab_Bookmarks");
            cmdPathfinder.Text = Global.Messages.Get("Tab_Pathfinder");
            cmdBrowser.Text = Global.Messages.Get("Tab_Browser");
            cmdSettings.Text = Global.Messages.Get("Tab_Settings");

            RelocateToolbarButtons();


            _toolbarControls.Add("Authorization", cmdAuthorization);
            _toolbarControls.Add("Location", cmdLocation);
            _toolbarControls.Add("Browser", cmdBrowser);
            _toolbarControls.Add("Bookmarks", cmdBookmarks);
            _toolbarControls.Add("SolarSystem", cmdMenuElements);
            _toolbarControls.Add("Settings", cmdSettings);
            _toolbarControls.Add("Pathfinder", cmdPathfinder);


            var width = int.Parse( GetConfigOptionalStringValue("ClientWidth", "564") );
            var height = int.Parse(GetConfigOptionalStringValue("ClientHeight", "325"));

            var standardSize = new Size(width, height);

            var panelBrowser = new PanelMetaData { Size = new Size(900, 700), IsResizeEnabled = true, Enabled = true };

            _metadata.Add("Authorization", new PanelMetaData { Size = new Size(564, 325) });


            var locationControlSize = new Size(1050, 612);

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (Global.ApplicationSettings.IsUseMap == false) locationControlSize = standardSize;
            }

            _metadata.Add("Location", new PanelMetaData { Size = locationControlSize, IsResizeEnabled = false, Enabled = false });
            _metadata.Add("Browser", panelBrowser);
            _metadata.Add("Bookmarks", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });
            _metadata.Add("SolarSystem", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });
            _metadata.Add("Settings", new PanelMetaData { Size = new Size(675, 325), IsResizeEnabled = false, Enabled = true });
            _metadata.Add("Pathfinder", new PanelMetaData { Size = new Size(900, 450), IsResizeEnabled = false, Enabled = false });
            _metadata.Add("Version", new PanelMetaData { Size = new Size(900, 500), IsResizeEnabled = false, Enabled = true });
            _metadata.Add("Router", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = false });
            _metadata.Add("WormholeInfo", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });
            _metadata.Add("TravelHistory", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = false });
            _metadata.Add("PilotInfo", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });
            _metadata.Add("NeedLoadPilot", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });
            _metadata.Add("EditPilots", new PanelMetaData { Size = standardSize, IsResizeEnabled = false, Enabled = true });

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (Global.ApplicationSettings.IsUseBrowser == false) panelBrowser.Enabled = false;
            }

            InitializeEvents();

            
        }

        private string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings.Get(keyName);

            return defaultValue;
        }

        private void RelocateToolbarButtons()
        {
            if (IsInDesignMode() == false)
            {
                cmdAuthorization.AutoSize = true;

                cmdMenuElements.Left = cmdAuthorization.Left + cmdAuthorization.Width;
                cmdMenuElements.AutoSize = true;
                

                cmdBookmarks.Left = cmdMenuElements.Left + cmdMenuElements.Width;
                cmdBookmarks.AutoSize = true;
                

                cmdPathfinder.Left = cmdBookmarks.Left + cmdBookmarks.Width;
                cmdPathfinder.AutoSize = true;
                

                cmdBrowser.Left = cmdPathfinder.Left + cmdPathfinder.Width;
                cmdBrowser.AutoSize = true;
                

                cmdSettings.Left = cmdBrowser.Left + cmdBrowser.Width;
                cmdSettings.AutoSize = true;
                
            }
        }

        private void elementChanged_Event(object sender, EventArgs e)
        {
            var element = cmdMenuElements.Value;

            var panelMetaData = (PanelMetaData)_metadata[element];

            RelocateToolbarButtons();

            if(panelMetaData.Enabled == false)
            {
                ActivatePanel("NeedLoadPilot");
                return;
            }

            ActivatePanel(element);

            cmdMenuElements.Refresh();

            
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
            try
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

                if (_toolbarControls.ContainsKey(panelName)) _toolbarControls[panelName].ForeColor = Color.DarkGoldenrod;

                if(cmdMenuElements.IsContaintItem(panelName))
                {
                    cmdMenuElements.ActivateItem(panelName);
                    cmdMenuElements.ForeColor = Color.DarkGoldenrod;
                }

                SetOwnerSize(panelName);

                var metaData = (PanelMetaData)_metadata[panelName];

                OnSelectTab?.Invoke(panelName, metaData);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[MapToolbarControl.ActivatePanel] Critical error = {0}", ex);
            }



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


        public bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }

    }
}
