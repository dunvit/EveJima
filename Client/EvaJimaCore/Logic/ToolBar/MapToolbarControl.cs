using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveJimaCore.Logic.ToolBar
{
    public partial class MapToolbarControl : UserControl
    {
        readonly Dictionary<string, Button> _toolbarControls = new Dictionary<string, Button>();

        public event Action<string> OnSelectTab;
        public string SelectedTab { get; set; }

        public MapToolbarControl()
        {
            InitializeComponent();

            cmdAuthorization.Tag = "Authorization";
            cmdLocation.Tag = "Location";
            cmdBrowser.Tag = "Browser";

            _toolbarControls.Add("Authorization", cmdAuthorization);
            _toolbarControls.Add("Location", cmdLocation);
            _toolbarControls.Add("Browser", cmdBrowser);

            InitializeEvents();

            ActivatePanel("Authorization");
        }

        private void InitializeEvents()
        {
            foreach (var control in _toolbarControls.Values)
            {
                control.Click += Event_ClickOnPanelOpenerButton;
            }
        }

        private void Event_ClickOnPanelOpenerButton(object sender, EventArgs e)
        {
            var element = ((Control)sender).Tag as string;

            ActivatePanel(element);
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
    }
}
