
using System.Drawing;

namespace EveJimaCore.Logic.ToolBar
{
    public class PanelMetaData
    {
        public Size Size { set; get; }

        public bool IsResizeEnabled { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
