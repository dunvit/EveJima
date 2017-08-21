using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveJimaBrowser
{
    public partial class frmMain : Form
    {
        WBrowser.WBrowser f2 = new WBrowser.WBrowser();

        public frmMain()
        {
            InitializeComponent();
            
            f2.TopLevel = false;
            f2.Location = new Point(5, 5);
            f2.Size = new Size(800,900);
            f2.FormBorderStyle = FormBorderStyle.None;
            f2.Visible = true;
            f2.Dock = DockStyle.Fill;
            this.Controls.Add(f2);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            f2.DisposeBrowser();
        }
    }
}
