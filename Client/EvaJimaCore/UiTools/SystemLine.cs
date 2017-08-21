using System.Drawing;
using System.Drawing.Drawing2D;

namespace EveJimaCore.UiTools
{
    public class SystemLine
    {
        public Color Color { get; set; }
        public Point PointFrom { get; set; }

        public DashStyle Style { get; set; }

        public Point PointTo { get; set; }

        public string Type { get; set; }
    }
}
