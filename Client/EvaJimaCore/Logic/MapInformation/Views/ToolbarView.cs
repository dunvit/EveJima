using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;

namespace TestPlatform.Logic
{
    public partial class ToolbarView : UserControl
    {
        readonly Dictionary<string, Button> _toolbarControls = new Dictionary<string, Button>();

        public string SelectedTab { get; set; }

        public event Action<string> OnSelectTab;

        public ToolbarView()
        {
            InitializeComponent();


        }

        private void ActivatePanel(string panelName)
        {
            foreach (var control in _toolbarControls.Values)
            {
                control.ForeColor = Color.Silver;
            }

            _toolbarControls[panelName].ForeColor = Color.DarkGoldenrod;

            if (OnSelectTab != null) OnSelectTab(panelName);

            SelectedTab = panelName;
        }

        private void Event_SelectToolBarElement(object sender, MouseEventArgs e)
        {
            var element = ((Control)sender).Tag as string;

            ActivatePanel(element);
        }

        public void ForceRefresh()
        {
            
        }

        private void ToolbarView_Load(object sender, EventArgs e)
        {
            cmdSystemInformation.Tag = "SolarSystem";
            cmdMapSignatures.Tag = "MapSignatures";
            cmdMapSettings.Tag = "MapSettings";
            cmdPilotes.Tag = "Pilotes";
            cmdBookmarks.Tag = "Bookmarks";

            _toolbarControls.Add("SolarSystem", cmdSystemInformation);
            _toolbarControls.Add("MapSignatures", cmdMapSignatures);
            _toolbarControls.Add("MapSettings", cmdMapSettings);
            _toolbarControls.Add("Pilotes", cmdPilotes);
            _toolbarControls.Add("Bookmarks", cmdBookmarks);

            cmdSystemInformation.Text = Global.Messages.Get("Tab_Map_Information");
            cmdMapSignatures.Text = Global.Messages.Get("Tab_Map_Signatures");
            cmdPilotes.Text = Global.Messages.Get("Tab_Map_Pilot");
            cmdMapSettings.Text = Global.Messages.Get("Tab_Map_Settings");

            ActivatePanel("SolarSystem");
        }
    }
}
