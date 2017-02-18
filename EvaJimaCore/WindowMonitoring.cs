using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvaJimaCore;
using EvaJimaCore.Ui;
using EveJimaCore.BLL;
using EveJimaCore.Properties;
using EveJimaCore.Ui;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore
{
    public partial class WindowMonitoring : Form
    {

        #region private variables
        private static readonly ILog Log = LogManager.GetLogger(typeof(WindowMonitoring));
        private bool _windowIsPinned;
        private bool _windowIsMinimaze;
        #endregion

        public Tabs ContainerTabs { get; set; }

        private readonly whlPilotInfo _containerPilotInfo = new whlPilotInfo();
        private whlBookmarks _containerBookmarks;
        private whlSolarSystem _containerSolarSystem;
        private whlTravelHistory _containerTravelHistory;
        private whlAuthorization _containerAuthorization;
        private whlSolarSystemOffline _containerSolarSystemOffline;
        private whlVersion _containerVersion;
        private ucRichBrowser _containerBrowser;

        #region WinAPI

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public bool IsWebBrowserMaximize = false; 

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        public WindowMonitoring()
        {
            try
            {
                InitializeComponent();

                ContainersInitialization();

                ContainerTabs = new Tabs { Parent = this };

                ContainerTabs.OnChangeTab += Event_OnChangeActiveTab;

                ContainerTabs.AddTab("Authorization", TabSize.Small, cmdAuthirizationPanel, _containerAuthorization);
                ContainerTabs.AddTab("Location", TabSize.Small, cmdLocation, _containerSolarSystem);
                ContainerTabs.AddTab("SolarSystem", TabSize.Small, cmdShowContainerSolarSystem, _containerSolarSystemOffline);
                ContainerTabs.AddTab("Pilots", TabSize.Small, cmdShowContainerPilots, _containerPilotInfo);
                ContainerTabs.AddTab("Bookmarks", TabSize.Small, cmdShowContainerBookmarks, _containerBookmarks);
                ContainerTabs.AddTab("Signatures", TabSize.Small, null, _containerTravelHistory);
                ContainerTabs.AddTab("WebBrowser", TabSize.Large, cmdOpenWebBrowser, _containerBrowser);
                ContainerTabs.AddTab("Version", TabSize.Large, cmdVersion, _containerVersion);

                ContainerTabs.Activate("Authorization");

                Size = ContainerTabs.Active().Size;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WindowMonitoring.WindowMonitoring] Critical error {0}", ex);
            }
        }

        private void Event_OnChangeActiveTab(string tabName)
        {
            if (tabName == "WebBrowser")
            {
                if (_containerBrowser.isMaxMode == false)
                {
                    btnOpenBrowserAndStartUrl.Visible = false;
                    btnBrowserMin.Location = btnOpenBrowserAndStartUrl.Location;
                    btnBrowserMin.Visible = false;
                    btnBrowserMax.Location = btnOpenBrowserAndStartUrl.Location;
                    btnBrowserMax.Visible = true;
                }
                else
                {
                    btnOpenBrowserAndStartUrl.Visible = false;
                    btnBrowserMax.Location = btnOpenBrowserAndStartUrl.Location;
                    btnBrowserMax.Visible = false;
                    btnBrowserMin.Location = btnOpenBrowserAndStartUrl.Location;
                    btnBrowserMin.Visible = true;
                }
            }
            else
            {
                btnBrowserMax.Visible = false;
                btnOpenBrowserAndStartUrl.Visible = true;
            }
        }

        private void ContainersInitialization()
        {
            DelegateShowTravelHistory showTravelHistory = ShowContainer_TravelHistory;
            DelegateShowLocation showLocation = ShowContainer_Location;
            DelegateChangeSolarSystemInfo changeSolarSystemInfo = ChangeSolarSystemInfo;

            _containerSolarSystem = new whlSolarSystem(showTravelHistory, changeSolarSystemInfo);

            _containerTravelHistory = new whlTravelHistory(showLocation);

            _containerBrowser = new ucRichBrowser();

            _containerSolarSystemOffline = new whlSolarSystemOffline();

            _containerVersion = new whlVersion();

            _containerBookmarks = new whlBookmarks();

            _containerAuthorization = new whlAuthorization();

            _containerAuthorization.OnChangeSelectedPilot += Event_ChangeSelectedPilot;

            pnlContainer.Controls.Add(_containerPilotInfo);
            pnlContainer.Controls.Add(_containerBookmarks);
            pnlContainer.Controls.Add(_containerSolarSystem);
            pnlContainer.Controls.Add(_containerTravelHistory);
            pnlContainer.Controls.Add(_containerSolarSystemOffline);
            pnlContainer.Controls.Add(_containerVersion);
            pnlContainer.Controls.Add(_containerAuthorization);

            _containerBrowser.ChangeViewMode += ChangeViewMode;

            pnlContainer.Controls.Add(_containerBrowser);

            _containerSolarSystem.OnBrowserNavigate += Event_BrowserNavigate;
            _containerPilotInfo.OnBrowserNavigate += Event_BrowserNavigate;
            _containerSolarSystemOffline.OnBrowserNavigate += Event_BrowserNavigate;
        }

        private void WindowMonitoring_Load(object sender, EventArgs e)
        {
            lblVersionID.Text = Global.Settings.CurrentVersion;

            Log.DebugFormat("[WindowMonitoring] Version: {0}", lblVersionID.Text);
            
            CreateTooltipsForStatics();

            DelegateStartProcess startProcessFunction = StartPilotAuthorizeFlow;

            new Thread(() => new CrestApiListener().ListenLocalhost(startProcessFunction)) { IsBackground = true }.Start();

            SetStyle(ControlStyles.ResizeRedraw, true);

            _containerAuthorization.RefreshAuthorizationStatus();

            if (IsNeedUpdateApplication() == false)
            {
                ContainerTabs.Activate("Authorization");
                OpenAuthorizationPanel();
            }
            else
            {
                ContainerTabs.Activate("Version");
            }

            Size = ContainerTabs.Active().Size;
            Global.Metrics.PublishOnApplicationStart(Global.Settings.CurrentVersion);
        }

        private void Event_BrowserNavigate(string address)
        {
            _containerBrowser.BrowserUrlExecute(address);
        }

        private void Event_ChangeSelectedPilot()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Event_ChangeSelectedPilot()));
            }
            try
            {
                Log.DebugFormat("[WindowMonitoring.Event_ChangeSelectedPilot] Global.Pilots.Selected.Location.Id {0}", Global.Pilots.Selected.Location.Id);
                if (Global.Pilots.Selected.Location.Id != null)
                {
                    cmdLocation.IsActive = true;
                    RefreshSolarSystemInformation(Global.Pilots.Selected.Location);
                }
                else
                {
                    cmdLocation.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WindowMonitoring.Event_ChangeSelectedPilot] Critical error. Exception {0}", ex);
            }
            
        }


        private void ChangeViewMode(bool ismax)
        {
            IsWebBrowserMaximize = ismax;

            _containerBrowser.isMaxMode = ismax;

            if (ismax)
            {
                FixBrowserSize();
            }
            else
            {
                pnlContainer.Location = new Point(11, 63);

                btnOpenBrowserAndStartUrl.Visible = true;
            }

            ContainerTabs.Activate("WebBrowser");

            TitleBar.BringToFront();
        }

        private void FixBrowserSize()
        {
            var positionLeft = 5;

            if (_containerBrowser.IsShowFavorites)
            {
                pnlContainer.Location = new Point(positionLeft - 148, -57);
                pnlContainer.Width = Width + 140;
                pnlContainer.Height = Height + 54;
            }
            else
            {
                pnlContainer.Location = new Point(positionLeft, -57);
                pnlContainer.Width = Width - 8;
                pnlContainer.Height = Height + 54;
            }

            _containerBrowser.Size = pnlContainer.Size;
            _containerBrowser.FixSize(true);

            pnlContainer.BringToFront();
        }

        private void ChangeSolarSystemInfo(string info)
        {
            lblSolarSystemName.Text = info;

            if (Visible == false)
            {
                crlNotificay.BalloonTipTitle = @"EvJima";
                crlNotificay.BalloonTipText = @"Active pilot enter to new location. " + info;

                crlNotificay.Visible = true;
                crlNotificay.ShowBalloonTip(500);
            }
        }


        private void ShowContainer_TravelHistory()
        {
            if (Global.Pilots.Count() == 0 || Global.Pilots.Selected == null || Global.Pilots.Selected.Location == null || Global.Pilots.Selected.Location.System == "unknown") return;

            ContainerTabs.Activate("Signatures");
        }


        private void ShowContainer_Location()
        {
            if (Global.Pilots.Count() == 0 || Global.Pilots.Selected == null || Global.Pilots.Selected.Location == null || Global.Pilots.Selected.Location.System == "unknown") return;
            
            ContainerTabs.Activate("Location");
        }

        private bool IsNeedUpdateApplication()
        {
            try
            {
                if (Global.Settings.Version != Global.Settings.CurrentVersion.Trim())
                {
                    Log.DebugFormat("Current version is {0}", Global.Settings.CurrentVersion);
                    Log.DebugFormat("Evajime last version is {0}", Global.Settings.Version);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WindowMonitoring.CheckVersion] Critical error. Exception {0}", ex);
            }

            return false;
        }

        protected override void WndProc(ref Message m)
        {
            if (ContainerTabs == null || ContainerTabs.Active() == null) return;

            if (ContainerTabs.Active().Name != "WebBrowser")
            {
                base.WndProc(ref m);
                return;
            }

            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                    {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                    {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }

            }

            if (!handled)
                base.WndProc(ref m);
        }

        private void DrawPilotPanel(PilotEntity pilot)
        {
            if (pilot.Location != null && pilot.Location.System != "unknown")
            {
                cmdLocation.IsActive = true;
                cmdLocation.Refresh();
            }
        }

        private void CreateTooltipsForStatics()
        {
            var toolTipUrlButton = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTipUrlButton.SetToolTip(btnOpenBrowserAndStartUrl, "Open WHL brouser and start url");

            var toolTipHideButton = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTipHideButton.SetToolTip(cmdHide, "Hide");
        }

        public void StartPilotAuthorizeFlow(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(StartPilotAuthorizeFlow), value);
                return;
            }

            Log.DebugFormat("[WindowMonitoring.StartPilotAuthorizeFlow] get value: {0}", value);

            _containerAuthorization.PilotAuthorizeFlow(value);

            BringApplicationToFront();

            RefreshSolarSystemInformation(Global.Pilots.Selected.Location);

            DrawPilotPanel(Global.Pilots.Selected);

            OpenAuthorizationPanel();
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


        private void OpenAuthorizationPanel()
        {
            ContainerTabs.Activate("Authorization");

            if (Global.Pilots.Selected != null)
            {
                _containerAuthorization.RefreshPilotInfo();
            }
        }

        private void Event_OpenBrowserContainer(object sender, EventArgs e)
        {
            ContainerTabs.Activate("WebBrowser");

            var urlFromClipboard = Clipboard.GetText();

            if (urlFromClipboard.StartsWith("http"))
            {
                _containerBrowser.BrowserUrlExecute(urlFromClipboard);
            }

            _windowIsMinimaze = false;
            cmdMinimazeRestore.Image = Resources.minimize;
        }


        


        #region GUI

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width, 28);

            e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 2), 0, 0, Width, Height);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            if (_windowIsPinned)
            {
                _windowIsPinned = false;
                cmdPin.Image = Resources.pin;
                TopMost = false;
            }
            else
            {
                _windowIsPinned = true;
                cmdPin.Image = Resources.unpin;
                TopMost = true;
            }
        }

        private void cmdMinimazeRestore_Click(object sender, EventArgs e)
        {
            if (_windowIsMinimaze)
            {
                _windowIsMinimaze = false;
                cmdMinimazeRestore.Image = Resources.minimize;
                Size = ContainerTabs.Active().Size;
            }
            else
            {
                _windowIsMinimaze = true;
                cmdMinimazeRestore.Image = Resources.restore;
                Size = ContainerTabs.Active().CompactSize;
            }

        }


        #endregion



        private void Event_WindowResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void Event_WindowDoubleClick(object sender, EventArgs e)
        {
            if (_windowIsMinimaze)
            {
                _windowIsMinimaze = false;
                cmdMinimazeRestore.Image = Resources.minimize;
                Size = new Size(ContainerTabs.Active().Size.Width, ContainerTabs.Active().Size.Height);
            }
            else
            {
                _windowIsMinimaze = true;
                cmdMinimazeRestore.Image = Resources.restore;
                Size = new Size( ContainerTabs.Active().CompactSize.Width, ContainerTabs.Active().CompactSize.Height);
            }

        }

        private void Event_TitleBarDoubleClick(object sender, EventArgs e)
        {
            if (_windowIsMinimaze)
            {
                _windowIsMinimaze = false;
                cmdMinimazeRestore.Image = Resources.minimize;
                Size = ContainerTabs.Active().Size;
            }
            else
            {
                _windowIsMinimaze = true;
                cmdMinimazeRestore.Image = Resources.restore;
                Size = ContainerTabs.Active().CompactSize;
            }
        }

        private void Event_TitleBarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void RefreshSolarSystemInformation(StarSystemEntity location)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RefreshSolarSystemInformation(location)));
            }

            if (Global.Pilots.Count() > 0)
            {
                _containerSolarSystem.RefreshSolarSystem(location);
                _containerTravelHistory.RefreshSolarSystem(location);
            }
        }

        private void WindowMonitoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            _containerVersion.DisposeBrowser();
            _containerVersion = null;

            _containerBrowser.DisposeBrowser();
            _containerBrowser = null;
        }

        private void btnBrowserMax_Click(object sender, EventArgs e)
        {
            ChangeViewMode(true);
        }

        private void btnBrowserMin_Click(object sender, EventArgs e)
        {
            ChangeViewMode(false);
        }

        private void crlNotificay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Event_Hide(object sender, EventArgs e)
        {
            crlNotificay.BalloonTipTitle = "EveJima";
            crlNotificay.BalloonTipText = @"EveJima waits actions in tray.";

            crlNotificay.Visible = true;
            crlNotificay.ShowBalloonTip(500);
            Hide();
        }

        private void Event_WindowResize(object sender, EventArgs e)
        {
            if (_windowIsMinimaze) return;

            TitleBar.Width = Width;

            VersionBar.Width = Width;
            VersionBar.Location = new Point(0, Height - 32);

            if (ContainerTabs.Active().Name == "WebBrowser")
            {
                if (IsWebBrowserMaximize)
                {
                    FixBrowserSize();
                    ContainerTabs.Activate("WebBrowser");
                    ContainerTabs.Active().Size = new Size(Width, Height);
                    TitleBar.BringToFront();
                }
                else
                {
                    ContainerTabs.Active().Size = new Size(Width, Height);
                    ContainerTabs.Resize();
                }
            }
        }

        private void RefreshTokenTimer_Tick(object sender, EventArgs e)
        {
            if (Global.Pilots.Count() > 0)
            {
                foreach (var pilot in Global.Pilots)
                {
                    Task.Run(() =>
                    {
                        Log.DebugFormat("[WindowMonitoring.RefreshTokenTimer_Tick] starting get location info for pilot = {0}", pilot.Name);
                        pilot.RefreshInfo();
                    });
                }

                if (_containerSolarSystem.SolarSystem != null && _containerSolarSystem.SolarSystem.System != Global.Pilots.Selected.Location.System)
                {
                    RefreshSolarSystemInformation(Global.Pilots.Selected.Location);
                }
            }
        }

        private void Event_RefreshActivePilot(object sender, EventArgs e)
        {
            if (Global.Pilots.Count() > 0)
            {
                try
                {
                    var activeProgramName = Tools.GetActiveWindowTitle();

                    Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] Active title {0}", activeProgramName);

                    if (!activeProgramName.StartsWith("EVE - ")) return;

                    var pilotName = activeProgramName.Replace("EVE - ", "") + "";

                    Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] pilotName {0}", pilotName);
                    Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] Global.Pilots.Selected.Name {0}", Global.Pilots.Selected.Name);

                    if (pilotName == Global.Pilots.Selected.Name) return;

                    Global.Pilots.Activate(pilotName);

                    _containerAuthorization.SelectPilot(pilotName);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[WindowMonitoring.Event_RefreshActivePilot] Critical error. Exception {0}", ex);
                }
            }
        }


    }
}
