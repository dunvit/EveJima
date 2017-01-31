//Goga Claudia
//WBrowser 2009
//Email : goga.claudia@gmail.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WBrowser
{
    public partial class RenameLink : Form
    {
        String oldName;

        public RenameLink(string oldName)
        {
            this.oldName = oldName;
            InitializeComponent();
        }

        private void RenameLink_Load(object sender, EventArgs e)
        {
            newName.Text = oldName; 
        }
    }
}
