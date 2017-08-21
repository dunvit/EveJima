using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvaJimaCore;

namespace EveJimaCore.WhlControls
{
    public partial class whlPilotInfo : BaseContainer
    {
        public BrowserNavigate OnBrowserNavigate;

        public whlPilotInfo()
        {
            InitializeComponent();
        }

        [Description("Pilot name"), Category("Data")]
        public string PilotName
        {
            get { return txtSelectedPilotName.Text; }
            set
            {
                txtSelectedPilotName.Text = value;

                Refresh();
            }
        }

        private void txtSelectedPilotName_TextChanged(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty( txtSelectedPilotName.Text.Trim() ))
            {
                cmdShowEveHunt.IsActive = false;
                cmdShowZkillboard.IsActive = false;
                cmdEverate.IsActive = false;
            }
             else
            {
                cmdShowEveHunt.IsActive = true;
                cmdShowZkillboard.IsActive = true;
                cmdEverate.IsActive = true;
            }
        }

        private void cmdCopyPilotsFromClipboard_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var txtInClip = Clipboard.GetText();

            if (string.IsNullOrEmpty(txtInClip))
            {
                return;
            }

            string[] pilots;

            pilots = txtInClip.Split(new[] { '\n' }, StringSplitOptions.None);

            foreach (var pilot in pilots)
            {
                listBox1.Items.Add(pilot);
            }

            Refresh();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            txtSelectedPilotName.Text = listBox1.Text;
        }

        private void cmdShowZkillboard_Click(object sender, EventArgs e)
        {
            if (crlPilotsHistory.Items.Contains(txtSelectedPilotName.Text.Trim()) == false)
            {
                crlPilotsHistory.Items.Add(txtSelectedPilotName.Text.Trim());
            }

            var characterId = Global.Infrastructure.EveXmlApi.GetPilotIdByName(txtSelectedPilotName.Text.Trim());

            if (crlPilotsHistory.Items.Contains(txtSelectedPilotName.Text.Trim()) == false)
            {
                crlPilotsHistory.Items.Add(txtSelectedPilotName.Text.Trim());
            }

            OnBrowserNavigate("https://zkillboard.com/character/" + characterId + "/");
        }

        private void cmdShowEveHunt_Click(object sender, EventArgs e)
        {
            if (crlPilotsHistory.Items.Contains(txtSelectedPilotName.Text.Trim()) == false)
            {
                crlPilotsHistory.Items.Add(txtSelectedPilotName.Text.Trim());
            }

            OnBrowserNavigate("http://eve-hunt.net/hunt/" + txtSelectedPilotName.Text.Trim() + "/");
        }

        private void cmdClearHistory_Click(object sender, EventArgs e)
        {
            crlPilotsHistory.Items.Clear();
        }

        private void Event_PilotsHistoryClick(object sender, EventArgs e)
        {
            if (crlPilotsHistory.SelectedItem == null) return;

            if (crlPilotsHistory.SelectedItem.ToString() != String.Empty)
            {
                txtSelectedPilotName.Text = crlPilotsHistory.SelectedItem.ToString();
            }
        }

        private void Event_ShowEverate(object sender, EventArgs e)
        {
            if (crlPilotsHistory.Items.Contains(txtSelectedPilotName.Text.Trim()) == false)
            {
                crlPilotsHistory.Items.Add(txtSelectedPilotName.Text.Trim());
            }

            OnBrowserNavigate("http://everate.ru/userinfo.php?name=" + txtSelectedPilotName.Text.Trim().Replace(" ", "+") + "");
        }
    }
}
