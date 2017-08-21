using System;
using System.Windows.Forms;

namespace EveJimaCore.Logic
{
    public partial class MapInformationControl : Form ,  IAMapInformationView
    {
        public MapInformationControl()
        {
            InitializeComponent();
        }

        private void MapInformationControl_Load(object sender, EventArgs e)
        {
            crlToolbarView.OnSelectTab += Event_OnSelectTab;
        }

        private void Event_OnSelectTab(string obj)
        {
            crlInformationContainer.ActivatePanel(obj);
        }

        public void ShowInformationPanel(string panelName)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crlToolbarView.ForceRefresh();
        }
    }
}
