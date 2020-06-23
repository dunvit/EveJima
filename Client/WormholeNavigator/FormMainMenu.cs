using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace WormholeNavigator
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private WindowStatus windowStatus = new WindowStatus();
        

        //Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;

            ReDrawSizeButton();

            ActivateButton(CommandShowPilots, RGBColors.color1);
        }

        

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(124, 77, 110);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                //iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
        }
        
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Command_ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeWindowStatus()
        {
            Size = windowStatus.Resize();
            ReDrawSizeButton();
        }

        private void ReDrawSizeButton()
        {
            if (windowStatus.IsWindowMaximized == false)
            {
                CommandWindowMaximize.Visible = true;
                CommandWindowMinimaze.Visible = false;

                CommandWindowMaximize.Location = CommandMinMaxPosition.Location;
                CommandWindowMinimaze.Location = CommandMinMaxPosition.Location;
            }
            else
            {
                CommandWindowMaximize.Visible = false;
                CommandWindowMinimaze.Visible = true;

                CommandWindowMaximize.Location = CommandMinMaxPosition.Location;
                CommandWindowMinimaze.Location = CommandMinMaxPosition.Location;
            }

            if (windowStatus.IsWindowPinned)
            {
                CommandWindowUnPin.Visible = false;
                CommandWindowPin.Visible = true;

                CommandWindowPin.Location = CommandPinUnpinPosition.Location;
                CommandWindowUnPin.Location = CommandPinUnpinPosition.Location;
            }
            else
            {
                CommandWindowPin.Visible = false;
                CommandWindowUnPin.Visible = true;

                CommandWindowPin.Location = CommandPinUnpinPosition.Location;
                CommandWindowUnPin.Location = CommandPinUnpinPosition.Location;
            }

            TopMost = windowStatus.IsWindowPinned;

        }

        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void Event_ShowPilots(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormDashboard());
        }

        private void Event_ShowInformation(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void Event_ShowBookmarks(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void Event_ShowLocation(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void Event_ShowBrowser(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void Event_ShowSettings(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }

        private void Event_ShowWormholes(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
        }

        private void Event_TitlebarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                Size = new Size(windowStatus.Width, windowStatus.Height);
                ChangeWindowStatus();
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Event_WindowMaximaze(object sender, EventArgs e)
        {
            Size = windowStatus.Maximize();
            ReDrawSizeButton();
        }

        private void Event_WindowMinimize(object sender, EventArgs e)
        {
            Size = windowStatus.Minimize();
            ReDrawSizeButton();
        }

        private void Event_WindowUnPin(object sender, EventArgs e)
        {
            windowStatus.UnPin();
            ReDrawSizeButton();
        }

        private void Event_WindowPin(object sender, EventArgs e)
        {
            
            windowStatus.Pin();
            ReDrawSizeButton();
        }

        
    }
}
