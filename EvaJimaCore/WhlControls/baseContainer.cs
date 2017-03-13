using System.Drawing;
using System.Windows.Forms;

namespace EveJimaCore.WhlControls
{
    public class baseContainer : UserControl
    {

        public baseContainer()
        {
            //Visible = false;
            BackColor = Color.Black;
            //Location = new Point(11, 63);
            Location = new Point(0, 0);

            Size = new Size(564, 325);
        }

        public virtual void ActivateContainer()
        {
            var a = "a";
        }

    }
}
