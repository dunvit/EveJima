using System.Drawing;
using System.Windows.Forms;
using EveJimaCore.WhlControls;

namespace EveJimaCore.Ui
{
    public class Tab
    {
        public BaseContainer Container { get; set; }

        public Button Button { get; set; }

        public string Name { get; set; }

        public Size Size { get; set; }

        public Size CompactSize = new Size(300, 29);

        public bool IsMinimized { get; set; }

        public bool IsActive { get; set; }
    }
}
