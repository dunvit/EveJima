using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EveJimaCore.WhlControls;

namespace EveJimaCore.UiTools
{
    public class MessageBoxLoader
    {
        public static void Show(string message, Control parent)
        {
            var messageBox = new windowMessage { Message = message };

            var parentForm = GetParentForm(parent);


            var parentIsTopMost = parentForm.TopMost;

            parentForm.TopMost = false;

            messageBox.ShowDialog();

            parentForm.TopMost = parentIsTopMost;
        }

        private static Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form != null)
            {
                return form;
            }
            if (parent != null)
            {
                // Walk up the control hierarchy
                return GetParentForm(parent.Parent);
            }
            return null; // Control is not on a Form
        }
    }
}
