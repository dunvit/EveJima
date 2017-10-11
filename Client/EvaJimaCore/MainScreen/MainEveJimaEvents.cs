using System;
using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.Properties;

namespace EveJimaCore
{
    public partial class MainEveJima
    {
        public void BringApplicationToFront()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(BringApplicationToFront));
            }
            else
            {
                var topMost = TopMost;

                TopMost = true;
                Focus();
                BringToFront();
                System.Media.SystemSounds.Beep.Play();
                TopMost = topMost;
            }
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Event_Close();
        }

        private void Event_ResizeWindowEnd(object sender, EventArgs e)
        {
            
            Refresh();
        }

        private void Event_TitleBarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            Parametrs.IsPinned = !Parametrs.IsPinned;
            SetPinned();
        }

        private void Event_ActivateWindow(object sender, EventArgs e)
        {
            if (Parametrs.IsLoaded == false)
            {
                Location = new Point(Global.WorkEnvironment.LocationMaximizeX, Global.WorkEnvironment.LocationMaximizeY);
                Parametrs.IsLoaded = true;

                Parametrs.IsPinned = Global.WorkEnvironment.IsPinned;

                SetPinned();
            }
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            crlNotificay.BalloonTipTitle = @"EveJima";
            crlNotificay.BalloonTipText = @"EveJima waits actions in tray.";

            crlNotificay.Visible = true;
            crlNotificay.ShowBalloonTip(200);
            Hide();
        }

        private void crlNotificay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Event_LocationChangedWindow(object sender, EventArgs e)
        {
            if (Parametrs.IsLoaded == false) return;

            Global.WorkEnvironment.LocationMaximizeX = Location.X;
            Global.WorkEnvironment.LocationMaximizeY = Location.Y;

            Global.ApplicationSettings.Save();
        }

        private void Event_TitleBarDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Parametrs.IsMinimaze)
                {
                    Parametrs.IsMinimaze = false;
                    cmdMinimazeRestore.Image = Resources.minimize;
                    Size = new Size(Parametrs.SizeBeforeMinimizate.Width, Parametrs.SizeBeforeMinimizate.Height);
                }
                else
                {
                    Parametrs.IsMinimaze = true;
                    cmdMinimazeRestore.Image = Resources.restore;
                    Parametrs.SizeBeforeMinimizate = new Size(Size.Width, Size.Height);
                    Size = new Size(350, 28);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[MainEveJima.cmdMinimazeRestore_Click] Critical error {0}", ex);
            }
        }
    }
}
