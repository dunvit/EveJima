using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestPlatform.Logic.Views
{
    public partial class InformationView : UserControl
    {
        readonly Dictionary<string, Panel> _informationControls = new Dictionary<string, Panel>();

        readonly InformationSystemsView _informationSystemsView = new InformationSystemsView { Visible = true, Dock = DockStyle.Fill };
        readonly InformationSignaturesView _informationSignaturesView = new InformationSignaturesView { Visible = true, Dock = DockStyle.Fill };
        readonly InformationMapSettingsView _informationMapSettingsView = new InformationMapSettingsView { Visible = true, Dock = DockStyle.Fill };

        public InformationView()
        {
            InitializeComponent();

            var systemInfoPanel = new Panel {Location = new Point(0,0), Tag = "SolarSystem", Visible = false , Dock = DockStyle.Fill };
            var signaturesPanel = new Panel { Location = new Point(0, 0), Tag = "MapSignatures", Visible = false, Dock = DockStyle.Fill };
            var mapSettingsPanel = new Panel { Location = new Point(0, 0), Tag = "MapSettings", Visible = false, Dock = DockStyle.Fill };
            
            systemInfoPanel.Controls.Add(_informationSystemsView);
            signaturesPanel.Controls.Add(_informationSignaturesView);
            mapSettingsPanel.Controls.Add(_informationMapSettingsView);

            _informationControls.Add("SolarSystem", systemInfoPanel);
            _informationControls.Add("MapSignatures", signaturesPanel);
            _informationControls.Add("MapSettings", mapSettingsPanel);

            Controls.Add(systemInfoPanel);
            Controls.Add(signaturesPanel);
            Controls.Add(mapSettingsPanel);

            ActivatePanel("SolarSystem");
        }

        public void ActivatePanel(string panelName)
        {
            foreach (var control in _informationControls.Values)
            {
                if(control.Visible) control.Visible = false;
            }

            _informationControls[panelName].Visible = true;
            _informationControls[panelName].Show();

            //if (OnSelectTab != null) OnSelectTab(panelName);

            //SelectedTab = panelName;
        }
    }
}
