using System;
using System.Drawing;
using System.Linq;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.LostAndFound;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class whlLostAndFoundOffice : baseContainer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(whlLostAndFoundOffice));

        public DelegateShowSolarSystem OnShowSolarSystem;

        

        public whlLostAndFoundOffice()
        {
            InitializeComponent();

            ShowDataContainer();
        }

        public void ShowMessage(string message)
        {
            lblMessage.Text = message;

            dataGridView1.Visible = false;
            containerRemove.Visible = false;
            containerPublish.Visible = false;

            containerMessage.Location = new Point(3, 3);
            containerMessage.Visible = true;
        }

        public void Refresh(PilotEntity pilot)
        {
            if (pilot.Location.System == "unknown")
            {
                cmdRemove.Enabled = false;
                cmdShow.Enabled = false;

                ShowDataContainer();
            }
            else
            {
                cmdRemove.Enabled = true;
                cmdShow.Enabled = true;
            }
        }

        private void Event_Return(object sender, EventArgs e)
        {
            OnShowSolarSystem();
        }

        private void Event_Show(object sender, EventArgs e)
        {
            ShowDataContainer();
        }

        private void Event_ShowPublishContainer(object sender, EventArgs e)
        {
            ShowPublishContainer();
        }

        private void ShowDataContainer()
        {
            containerMessage.Visible = false;
            containerPublish.Visible = false;
            containerRemove.Visible = false;

            dataGridView1.Location = new Point(3,3);
            dataGridView1.Visible = true;

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = Global.LostAndFoundOffice.List.Values.ToList();
            dataGridView1.Refresh();
        }

        private void ShowPublishContainer()
        {
            txtPublishWormholeName.Text = ""; 
            txtPublisherName.Text = "";
            txtPublishWormholeReward.Text = "";

            containerMessage.Visible = false;
            dataGridView1.Visible = false;
            containerRemove.Visible = false;

            containerPublish.Location = new Point(3, 3);
            containerPublish.Visible = true;
            try
            {
                txtPublisherName.Text = Global.Pilots.Selected.Name;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[whlLostAndFoundOffice.ShowPublishContainer] Critical error. Exception {0}", ex);
            }
            
        }

        private void ShowRemoveContainer()
        {
            txtRemoveWormholeName.Text = "";
            txtRemoveWormholePublisher.Text = "";

            containerMessage.Visible = false;
            dataGridView1.Visible = false;
            containerPublish.Visible = false;

            containerRemove.Location = new Point(3, 3);
            containerRemove.Visible = true;

            txtRemoveWormholePublisher.Text = Global.Pilots.Selected.Name;
        }

        private void Event_Publish(object sender, EventArgs e)
        {
            var wormhole = new LostSolarSystem { 
                Name = txtPublishWormholeName.Text, 
                Publisher = txtPublisherName.Text,
                Reward = txtPublishWormholeReward.Text,
                Date = DateTime.UtcNow
            };

            Global.LostAndFoundOffice.PublishWormhole(wormhole);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Global.LostAndFoundOffice.List.Values.ToList();
            dataGridView1.Refresh();
            ShowDataContainer();
        }

        private void Event_RemoveOperation(object sender, EventArgs e)
        {
            var wormhole = new LostSolarSystem
            {
                Name = txtRemoveWormholeName.Text,
                Publisher = txtRemoveWormholePublisher.Text,
                Reward = "",
                Date = DateTime.UtcNow
            };

            Global.LostAndFoundOffice.RemoveWormhole(wormhole);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Global.LostAndFoundOffice.List.Values.ToList();
            dataGridView1.Refresh();
            ShowDataContainer();
        }

        private void Event_ShowRemoveContainer(object sender, EventArgs e)
        {
            containerMessage.Visible = true;

            ShowRemoveContainer();
        }

        private void Event_CloseMessageContainer(object sender, EventArgs e)
        {
            ShowDataContainer();
        }

        
    }
}
