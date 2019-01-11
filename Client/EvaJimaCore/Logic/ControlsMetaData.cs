using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using EveJimaCore.WhlControls;

namespace EveJimaCore.Main
{
    public class ControlsMetaData
    {
        public readonly Hashtable Tabs = new Hashtable();

        public List<ejcComboboxItem> ComboElements = new List<ejcComboboxItem>();

        public ControlsMetaData()
        {
            var width = int.Parse(GetConfigOptionalStringValue("ClientWidth", "564"));
            var height = int.Parse(GetConfigOptionalStringValue("ClientHeight", "325"));

            var standardSize = new Size(width, height);
            var locationControlSize = new Size(1050, 612);


            Tabs.Add("Authorization", new PanelMetaData {Name = "Authorization", Size = new Size(584, 345) });
            //+
            Tabs.Add("Location", new PanelMetaData { Name = "Location", Size = locationControlSize, IsResizeEnabled = false, Enabled = false });
            Tabs.Add("Browser", new PanelMetaData { Name = "Browser", Size = new Size(900, 700), IsResizeEnabled = true, Enabled = true });
            //+
            Tabs.Add("Bookmarks", new PanelMetaData { Name = "Bookmarks", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            //+
            Tabs.Add("SolarSystem", new PanelMetaData { Name = "SolarSystem", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Tabs.Add("Settings", new PanelMetaData { Name = "Settings", Size = new Size(705, 320), IsResizeEnabled = false, Enabled = true });
            Tabs.Add("Pathfinder", new PanelMetaData { Name = "Pathfinder", Size = new Size(900, 450), IsResizeEnabled = false, Enabled = false });
            Tabs.Add("Version", new PanelMetaData { Name = "Version", Size = new Size(900, 500), IsResizeEnabled = false, Enabled = true });
            Tabs.Add("Router", new PanelMetaData { Name = "Router", Size = standardSize, IsResizeEnabled = false, Enabled = false });
            Tabs.Add("WormholeInfo", new PanelMetaData { Name = "WormholeInfo", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Tabs.Add("TravelHistory", new PanelMetaData { Name = "TravelHistory", Size = standardSize, IsResizeEnabled = false, Enabled = false });
            Tabs.Add("PilotInfo", new PanelMetaData { Name = "PilotInfo", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Tabs.Add("NeedLoadPilot", new PanelMetaData { Name = "NeedLoadPilot", Size = standardSize, IsResizeEnabled = false, Enabled = true });
            Tabs.Add("EditPilots", new PanelMetaData { Name = "EditPilots", Size = standardSize, IsResizeEnabled = false, Enabled = true });



            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_Information", "Information"), Value = "SolarSystem" });
            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_Location"), Value = "Location" });
            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_Router"), Value = "Router" });
            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_TravelHistory"), Value = "TravelHistory" });

            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_PilotsInfo"), Value = "PilotInfo" });
            ComboElements.Add(new ejcComboboxItem { Text = Localization.Messages.Get("Tab_WormholeInfo"), Value = "WormholeInfo" });

        }

        private string GetConfigOptionalStringValue(string keyName, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(keyName)) return defaultValue;

            if (ConfigurationManager.AppSettings.Get(keyName) != null)
                return ConfigurationManager.AppSettings.Get(keyName);

            return defaultValue;
        }
    }
}
