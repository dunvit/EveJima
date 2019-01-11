
using System.Drawing;

namespace EveJimaCore.Main
{
    public class PanelMetaData
    {
        public string Name { get; set; }

        public string LabelKey { get; set; }

        public Size Size { set; get; }

        public bool IsResizeEnabled { get; set; }

        public bool Enabled { get; set; } = true;

        public string ParentElement { get; set; }

        public bool IsComboElement { get; set; } = false;

        public bool IsCombo { get; set; } = false;

        public bool IsDefaultPanel { get; set; } = false;

        public int Index { get; set; } = -1;

        public int ComboIndex { get; set; } = -1;
    }
}
