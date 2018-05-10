using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    public partial class ejcComboBox : UserControl
    {
        private bool _autoSize;

        public event EventHandler ElementChanged;

        public ejcComboBox()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int width = 0;

            foreach (ejcComboboxItem comboBox1Item in comboBox1.Items)
            {
                lblSizeOwner.Text = comboBox1Item.Text;
                lblSizeOwner.AutoSize = true;
                if (lblSizeOwner.Width > width) width = lblSizeOwner.Width;
            }

            comboBox1.Width = width + 10;
            
            comboBox1.Visible = true;
            comboBox1.DroppedDown = true;
        }


        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            cmdPathfinder.Text = comboBox1.Text;

            if (ElementChanged != null)
                ElementChanged(sender, e);
        }

        private void cmdPathfinder_Click(object sender, EventArgs e)
        {
            if (ElementChanged != null)
                ElementChanged(sender, e);
        }


        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public override string Text
        {
            get
            {
                return cmdPathfinder.Text;
            }

            set
            {
                cmdPathfinder.Text = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public string Value
        {
            get
            {
                return (comboBox1.SelectedItem as ejcComboboxItem).Value.ToString();
            }

        }

        

        [Category("Appearance")]
        public override bool AutoSize
        {
            get { return _autoSize; }
            set
            {
                _autoSize = value;

                int width = 0;

                foreach(ejcComboboxItem comboBox1Item in comboBox1.Items)
                {
                    lblSizeOwner.Text = comboBox1Item.Text;
                    lblSizeOwner.AutoSize = true;
                    if (lblSizeOwner.Width > width) width = lblSizeOwner.Width;
                }

                if (_autoSize)
                {
                    cmdPathfinder.AutoSize = true;
                    Width = cmdPathfinder.Left + 2 + cmdPathfinder.Width;
                }

                Invalidate(); // causes control to be redrawn
            }
        }

        public void AddItem(ejcComboboxItem item)
        {
            comboBox1.Items.Add(item);

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty( comboBox1.SelectedText) )
            {

                comboBox1.Visible = false;
                cmdPathfinder.Text = comboBox1.Text;

                if (ElementChanged != null)
                    ElementChanged(sender, e);
            }
        }
    }

    public class ejcComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
