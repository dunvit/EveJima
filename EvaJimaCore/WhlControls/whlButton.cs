using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EveJimaCore
{
    public partial class whlButton : UserControl
    {
        public new event EventHandler Click;

        bool _isActive;

        private bool _isTabControlButton;

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                label1.ForeColor = value;
            }
        }

        [Description("Value"), Category("Data")]
        public string Value
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;

                Refresh();
            }
        }

        [Description("Is active button"), Category("Data")]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;

                if (_isActive)
                {
                    label1.ForeColor = Color.LightGray;
                    label1.Cursor = Cursors.Hand;
                }
                else
                {
                    label1.ForeColor = Color.DimGray;
                    label1.Cursor = Cursors.Arrow;
                }

                Refresh();
            }
        }

        [Description("Is tabControl button"), Category("Data")]
        public bool IsTabControlButton
        {
            get { return _isTabControlButton; }
            set
            {
                _isTabControlButton = value;

                Refresh();
            }
        }

        public whlButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_isTabControlButton)
            {
                e.Graphics.DrawLine(new Pen(Color.DimGray, 1), 0, 0, Width-1, 0);
                e.Graphics.DrawLine(new Pen(Color.DimGray, 1), Width - 1, 0, Width - 1, Height);
                e.Graphics.DrawLine(new Pen(Color.DimGray, 1), 0, 0, 0, Height - 1);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(Color.DimGray, 2), 0, 0, Width, Height);

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        private void whlButton_Resize(object sender, EventArgs e)
        {
            label1.Width = Width - 8;
            Refresh();
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (IsActive)
            {
                label1.ForeColor = Color.Bisque;

                Refresh();
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (IsActive)
            {
                label1.ForeColor = Color.LightGray;
                Refresh();
            }
        }
    }
}
