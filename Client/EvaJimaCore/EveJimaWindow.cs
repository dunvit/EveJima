using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using EveJimaCore.BLL;
using EveJimaCore.Main;
using EveJimaCore.Monitoring;
using EveJimaCore.Tools;
using EveJimaCore.Window;
using log4net;
using Global = EvaJimaCore.Global;
using Timer = System.Timers.Timer;

namespace EveJimaCore
{
    public sealed partial class EveJimaWindow : EveJimaBaseWindow
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        private readonly EveJimaTabsMetaData _controlsCollection = new EveJimaTabsMetaData();

        private readonly EventsMonitoring _eventsMonitoring = new EventsMonitoring();

        private readonly Timer _workerTimer;

        public EveJimaWindow()
        {
            InitializeComponent();

            if(!Common.IsAppicationModeRuntime()) return;

            // From here only run time commands ----------------------------------------------------

            Text = @"EveJima " + Global.ApplicationSettings.CurrentVersion;

            crlTitlebar.OnCloseApplication += Event_ApplicationClose;
            crlTitlebar.Initialize(this, Parametrs);
            crlTitlebar.MouseDown += Event_TitlebarMouseDown;
            crlTitlebar.OnHideToTray += Event_HideApplicationToTray;

            Global.Pilots.OnActivatePilot += GlobalEvent_ActivatePilot;
            Global.Presenter.OnEnterToSolarSystem += Event_EnterToSolarSystem;
            Global.Presenter.OnCloseApplication += Event_ApplicationClose;

            Global.Presenter.OnChangeScreen += Event_ChangeScreen;

            eveJimaToolbar1.OnSelectElement += Event_ResizeWindow;



            DelegateStartProcess startProcessFunction = Event_StartPilotAuthorizeFlow;
            new Thread(() => new CrestApiListener().ListenLocalhost(startProcessFunction)) { IsBackground = true }.Start();

            Global.InternalBrowser.OnBrowserNavigate += Event_BrowserNavigate;

            eveJimaToolbar1.Initialize(_controlsCollection);

            

            ClipboardMonitoring.GetValueFromClipboard += Event_RunBrowserPage;
            ClipboardMonitoring.GetUnknownSpaceSolarSystemFromClipboard += Event_GetUnknownSpaceSolarSystemFromClipboard;

            Global.Presenter.ChangeScreen(Global.ApplicationSettings.IsNeedUpdateVersion ? "Version" : "Authorization");

            _workerTimer = new Timer();
            _workerTimer.Elapsed += Event_Refresh;
            _workerTimer.Interval = 5000;
            _workerTimer.Enabled = false;

            _workerTimer.Enabled = true;
        }

        private List<Bitmap> patterns;

        private void Event_Refresh(object sender, ElapsedEventArgs e)
        {
            if (Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled == false) return;


            if (patterns == null)
            {
                patterns = new List<Bitmap>();

                var patternsFolder = Path.Combine(Environment.CurrentDirectory, "Patterns");

                var patternFolder = Path.Combine(patternsFolder, "Signatures".Replace("/", "\\"));

                FillFilesInDirectory(patternFolder, patterns);
            }

            var monitoringPilots = ":" + Global.ApplicationSettings.Common.Monitoring.PilotsList + ":";

            var clients = Clients.Active.GetList(Global.ApplicationSettings.Common.EveOnlineTitle);

            foreach (var client in clients)
            {
                var searchPilot = ":" + client.Name.Trim() + ":";

                if (monitoringPilots.Contains(searchPilot))
                {
                    var screen = (Bitmap) CaptureWindow(client.HWnd);

                    if (GraphTools.FindObjectInScreen(patterns, screen, 0))
                    {

                        if (Parametrs.IsMinimaze)
                        {
                            crlTitlebar.ChangeState();
                        }

                        Thread.Sleep(2000);

                        SetForegroundWindow(client.HWnd);

                        Global.ApplicationSettings.Common.Monitoring.IsMonitoringEnabled = false;

                        Global.ApplicationSettings.Common.Monitoring.Message = " Alert: " + client.Name.Trim();

                        Global.Presenter.ChangeScreen("NewSignature");


                        //var result = MessageBoxEx.Show(@"Alarm", @"New signature on window " + client.Name.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static Image CaptureWindow(IntPtr handle)
        {
            try
            {
                // get te hDC of the target window
                IntPtr hdcSrc = User32.GetWindowDC(handle);
                // get the size
                User32.RECT windowRect = new User32.RECT();
                User32.GetWindowRect(handle, ref windowRect);
                int width = windowRect.right - windowRect.left;
                int height = windowRect.bottom - windowRect.top;
                // create a device context we can copy to
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                // bitblt over
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                // restore selection
                GDI32.SelectObject(hdcDest, hOld);
                // clean up 
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);
                // get a .NET image object for it
                Image img = Image.FromHbitmap(hBitmap);
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);
                return img;
            }
            catch (Exception e)
            {
                return null;
            }


        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }

        private static void FillFilesInDirectory(string folder, ICollection<Bitmap> result)
        {
            foreach (var file in new DirectoryInfo(folder).GetFiles())
            {
                result.Add(new Bitmap(file.FullName));
            }

            foreach (var directory in new DirectoryInfo(folder).GetDirectories())
            {
                FillFilesInDirectory(directory.FullName, result);
            }
        }

        private void Event_GetUnknownSpaceSolarSystemFromClipboard(string solarSystemName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Event_GetUnknownSpaceSolarSystemFromClipboard(solarSystemName)));
                return;
            }

            if(Parametrs.IsMinimaze)
            {
                crlTitlebar.ChangeState();
            }

            Global.Presenter.ChangeScreen("SolarSystem");
            Global.Presenter.RequestSolarSystemInformation(solarSystemName);

            Focus();
        }

        private void Event_ChangeScreen(string windowName)
        {
            eveJimaToolbar1.ActivatePanel(windowName);
        }

        private void Event_StartPilotAuthorizeFlow(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Event_StartPilotAuthorizeFlow), value);
                return;
            }

            Log.DebugFormat("[MainEveJima.StartPilotAuthorizeFlow] get value: {0}", value);

            Global.Pilots.Authorize(value);

            Global.Presenter.ChangeScreen("Authorization");

            BringApplicationToFront();

            if (Global.ApplicationSettings.IsUseMap == false) return;

            Global.Pilots.Selected.Key = Global.Pilots.Selected.Name;
        }

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

        private void Event_ApplicationClose()
        {
            _eventsMonitoring.Dispose();
            Global.Dispose();
            Close();
        }


        private void GlobalEvent_ActivatePilot(PilotEntity pilot)
        {
            Log.InfoFormat("[MainEveJima.GlobalEvent_ActivatePilot] Pilot: {0} Location: {1}", pilot.Name, Global.Pilots.Selected.Location.Id);

            eveJimaToolbar1.SelectPilotSetAllTabsEnabled();
        }

        private void Event_EnterToSolarSystem(string obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Event_EnterToSolarSystem), obj);
                return;
            }

            Log.InfoFormat("[MainEveJima.Event_EnterToSolarSystem] Pilot: {0} Location: {1}", Global.Pilots.Selected.Name, Global.Pilots.Selected.Location.Id);

            crlTitlebar.RefreshLocationInfo();
            crlTitlebar.Refresh();
            Refresh();
        }

        private void Event_HideApplicationToTray()
        {
            crlNotificay.BalloonTipTitle = @"EveJima";
            crlNotificay.BalloonTipText = @"EveJima waits actions in tray.";

            crlNotificay.Visible = true;
            crlNotificay.ShowBalloonTip(200);
            Hide();
        }


        private void Event_ResizeWindow(PanelMetaData moduleData)
        {
            if(Parametrs.IsMinimaze == false)
            {
                Size = new Size(moduleData.Size.Width+4, moduleData.Size.Height + 32);
            }

            RsizeTabControlForShowWindowBorders();

            Parametrs.IsResizebleMode = moduleData.IsResizeEnabled;
        }

        

        private void RsizeTabControlForShowWindowBorders()
        {
            eveJimaToolbar1.Width = Width - 4;
            eveJimaToolbar1.Height = Height - 32;
        }

        private void EveJimaWindow_Resize(object sender, EventArgs e)
        {
            RsizeTabControlForShowWindowBorders();

            _controlsCollection.ResizeElement(eveJimaToolbar1.ActivePanelName, eveJimaToolbar1.Width, eveJimaToolbar1.Height);

            //eveJimaToolbar1.ResizeActivePanel();
        }

        
        private void Event_RunBrowserPage(string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Event_RunBrowserPage(address)));
                return;
            }

            Global.InternalBrowser.Navigate(address);
        }

        private void Event_BrowserNavigate(string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Event_BrowserNavigate(address)));
                return;
            }

            if (Global.ApplicationSettings.IsUseBrowser)
            {
                if (Parametrs.IsMinimaze)
                {
                    crlTitlebar.ChangeState();
                }

                eveJimaToolbar1.BrowserNavigate(address);

                Focus();
                return;
            }

            System.Diagnostics.Process.Start(address);
        }

        private void Event_RestoreApplicationFromTray(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Event_LocationChange(object sender, EventArgs e)
        {
            if (Parametrs.IsLoaded == false) return;

            Global.WorkEnvironment.LocationMaximizeX = Location.X;
            Global.WorkEnvironment.LocationMaximizeY = Location.Y;

            Global.ApplicationSettings.Save();
        }

        private void Event_ActivateWindow(object sender, EventArgs e)
        {
            if(IsInitializated == false)
            {
                Location = new Point(Global.WorkEnvironment.LocationMaximizeX, Global.WorkEnvironment.LocationMaximizeY);
                Parametrs.IsLoaded = true;

                _eventsMonitoring.Activate();

                IsInitializated = true;
            }
        }

        private void Event_keyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Global.Presenter.ChangeScreen("NewSignature");
            }
        }
    }
}
