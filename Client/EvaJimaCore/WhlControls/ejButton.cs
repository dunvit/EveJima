using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    public class ejButton : Button
    {
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
