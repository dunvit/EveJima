using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.Tools;
using EveJimaUniverse;
using log4net;

namespace EveJimaCore.WhlControls
{
    public partial class mapSolarSystem : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger("All");

        public bool IsSelected { get; set; }
        public bool IsCurrentLocation { get; set; }

        private EveJimaUniverse.System _solarSystem ;

        public mapSolarSystem()
        {
            InitializeComponent();
        }

        public void Initialize(string solarSystemName)
        {
            _solarSystem = Global.Space.GetSystemByName(solarSystemName);

            lblSolarSystemName.Text = _solarSystem.Name;
        }

        private void Event_OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var rectangle = new Rectangle(25, 25, 10, 10);
            graphics.FillEllipse(new SolidBrush(Common.GetColorBySolarSystem(_solarSystem.Security.ToString())), rectangle);
            graphics.DrawEllipse(new Pen( Color.DimGray, 1), rectangle);

            if (IsCurrentLocation)
            {
                graphics.DrawEllipse(new Pen(Color.Goldenrod, 1), new Rectangle(20, 20, 20, 20));

                graphics.DrawEllipse(new Pen(Color.Gold, 1), new Rectangle(18, 18, 24, 24));
            }

            if (IsSelected)
            {
                graphics.DrawEllipse(new Pen(Color.DarkSeaGreen, 2), new Rectangle(20, 20, 20, 20));
            }
        }
    }
}
