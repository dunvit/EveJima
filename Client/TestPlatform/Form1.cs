using System;
using System.Drawing;
using System.Windows.Forms;
//using EveJimaCore.Logic;
using TestPlatform.Logic;

namespace TestPlatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AMapInformationPresenter Presenter { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            IAMapInformationModel model = new AMapInformationModel();

            var view = new MapInformationControl
            {
                TopLevel = false,
                Location = new Point(5, 5),
                Size = new Size(800, 900),
                FormBorderStyle = FormBorderStyle.None,
                Visible = true,
                Dock = DockStyle.Fill
            };

            Controls.Add(view);

            Presenter = new AMapInformationPresenter(model, view);

            Presenter.Run();
        }
    }
}
