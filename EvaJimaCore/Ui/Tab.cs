using System.Drawing;
using EveJimaCore.WhlControls;

namespace EveJimaCore.Ui
{
    public class Tab
    {
        public baseContainer Container { get; set; }

        public whlButton Button { get; set; }

        public string Name { get; set; }

        public Size Size { get; set; }

        public Size CompactSize = new Size(300, 29);

        public bool IsMinimized { get; set; }

        public bool IsActive { get; set; }
    }
}
