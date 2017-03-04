
namespace EveJimaCore.UiTools
{
    using System.ComponentModel;
    using System.Windows.Forms;
    using System;

    public class LabelWithOptionalCopyTextOnDoubleClick : Label
    {
        private const int WM_LBUTTONDCLICK = 0x203;
        private string clipboardText;

        [DefaultValue(false)]
        [Description("Overrides default behavior of Label to copy label text to clipboard on double click")]
        public bool CopyTextOnDoubleClick { get; set; }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (!string.IsNullOrEmpty(clipboardText))
                Clipboard.SetData(DataFormats.Text, clipboardText);
            clipboardText = null;
            base.OnDoubleClick(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (!CopyTextOnDoubleClick)
            {
                if (m.Msg == WM_LBUTTONDCLICK)
                {
                    IDataObject d = Clipboard.GetDataObject();
                    if (d.GetDataPresent(DataFormats.Text))
                        clipboardText = (string)d.GetData(DataFormats.Text);
                }
            }
            base.WndProc(ref m);
        }

    }
}
