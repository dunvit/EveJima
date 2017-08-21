using System;
using System.Drawing;
using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    public partial class windowMessage : Form
    {
        public string Message { get; set; }

        public windowMessage()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width, 28);

            e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 2), 0, 0, Width, Height);
        }

        private void Event_CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private void windowMessage_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Message;
        }
    }
}
