// Goga Claudia
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
    public partial class AddFavorites : Form
    {
        String url;
        public String favName, favFile;

        public AddFavorites(String url)
        {
            this.url = url;
            InitializeComponent();
        }

        private void AddFavorits_Load(object sender, EventArgs e)
        {
                textBox3.Text = url;
                comboBox1.Text = comboBox1.Items[0].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            favName = textBox3.Text;
            favFile = comboBox1.Text;
        }

       
    }
}
