using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Linq;
using EvaJimaCore;

namespace EveJimaCore.Main
{
    public sealed class EveJimaTabsMetaData : Hashtable
    {
        public int DefaultWidth;
        public int DefaultHeight;

        public void ResizeElement(string panelName, int width, int height)
        {
            var panel = GetPanelMetaDataByName(panelName);

            if(panel == null) return;

            if (panel.IsResizeEnabled)
            {
                panel.Size = new Size(width, height);
            }
        }

        public PanelMetaData GetPanelMetaDataByName(string panelName)
        {
            return Values.Cast<PanelMetaData>().FirstOrDefault(x => x.Name == panelName);
        }

        public PanelMetaData GetDefaultPanelMetaData()
        {
            return Values.Cast<PanelMetaData>().FirstOrDefault(x => x.IsDefaultPanel);
        }

        public EveJimaTabsMetaData()
        {
            DefaultWidth = int.Parse(GetConfigOptionalStringValue("ClientWidth", "564"));
            DefaultHeight = int.Parse(GetConfigOptionalStringValue("ClientHeight", "295"));

            var standardSize = new Size(DefaultWidth, DefaultHeight);

            Add("Authorization", new PanelMetaData
            {
                Name = "Authorization",
                LabelKey = "Tab_Pilots",
                Size = new Size(564, 295),
                Index = 0,
                IsDefaultPanel = true
            });

            // Combo field 
            Add("SolarSystem", new PanelMetaData
            {
                Name = "SolarSystem",
                LabelKey = "Tab_Information",
                IsComboElement = true,
                ParentElement = "MenuElements",
                Size = standardSize,
                IsResizeEnabled = false,
                Enabled = true,
                ComboIndex = 1
            });

            // Combo field 
            Add("Router", new PanelMetaData
            {
                Name = "Router",
                LabelKey = "Tab_Router",
                IsComboElement = true,
                ParentElement = "MenuElements",
                Size = standardSize,
                IsResizeEnabled = false,
                Enabled = false,
                ComboIndex = 3
            });

            // Combo field 
            Add("TravelHistory", new PanelMetaData
            {
                Name = "TravelHistory",
                LabelKey = "Tab_TravelHistory",
                IsComboElement = true,
                ParentElement = "MenuElements",
                Size = standardSize,
                IsResizeEnabled = false,
                Enabled = false,
                ComboIndex = 4
            });

            // Combo field 
            Add("WormholeInfo", new PanelMetaData
            {
                Name = "WormholeInfo",
                LabelKey = "Tab_WormholeInfo",
                Size = standardSize,
                IsComboElement = true,
                ParentElement = "MenuElements",
                IsResizeEnabled = false,
                ComboIndex = 6
            });

            // Combo field 
            Add("PilotInfo", new PanelMetaData
            {
                Name = "PilotInfo",
                LabelKey = "Tab_PilotsInfo",
                IsComboElement = true,
                ParentElement = "MenuElements",
                Size = standardSize,
                IsResizeEnabled = false,
                ComboIndex = 5
            });

            Add("Browser", new PanelMetaData
            {
                Name = "Browser",
                LabelKey = "Tab_Browser",
                Size = new Size(900, 700),
                IsResizeEnabled = true,
                Enabled = Global.ApplicationSettings.IsUseBrowser,
                Index = 4
            });
            
            Add("Bookmarks", new PanelMetaData
            {
                Name = "Bookmarks",
                LabelKey = "Tab_Bookmarks",
                Size = standardSize,
                IsResizeEnabled = false,
                Index = 2
            });
            
            Add("Settings", new PanelMetaData
            {
                Name = "Settings",
                LabelKey = "Tab_Settings",
                Size = new Size(705, 320),
                IsResizeEnabled = false,
                Index = 5
            });

            Add("Location", new PanelMetaData { Name = "Location", LabelKey = "Tab_Location", Size = standardSize, IsResizeEnabled = false, Enabled = false, Index = 3 });
            Add("Version", new PanelMetaData { Name = "Version", Size = new Size(882, 542), IsResizeEnabled = false, Enabled = true});
            Add("NeedLoadPilot", new PanelMetaData { Name = "NeedLoadPilot", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Add("EditPilots", new PanelMetaData { Name = "EditPilots", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Add("Pattern", new PanelMetaData { Name = "Pattern", Size = new Size(705, 320), IsResizeEnabled = false, Enabled = true });
            Add("NewSignature", new PanelMetaData { Name = "NewSignature", Size = new Size(705, 320), IsResizeEnabled = false, Enabled = true });
            Add("ComboElement", new PanelMetaData{Name = "MenuElements", LabelKey = "Tab_Information", Index = 1, IsCombo = true});
        }

        private static string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            return ConfigurationManager.AppSettings.Get(keyName) ?? defaultValue;
        }
    }
}
