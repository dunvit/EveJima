﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;
using EvaJimaCore.Ui;
using EveJimaCore.BLL;
using EveJimaCore.Logic;
using EveJimaCore.Logic.MapInformation;
using EveJimaCore.Properties;
using EveJimaCore.Ui;
using EveJimaCore.UiTools;
using EveJimaCore.WhlControls;
using EveJimaUniverse;
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
        //private crlSpaceMap _containerMap;
        private MapControl _containerMap;
        private whlLostAndFoundOffice _containerLostAndFoundOffice;
        private whlRouter _containerRouter;

        private bool isLoaded = false;

        #region WinAPI

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public bool IsWebBrowserMaximize = false; 

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        public LabelWithOptionalCopyTextOnDoubleClick lblSolarSystemName;

        public WindowMonitoring()
        {
            try
            {
                InitializeComponent();

                ContainersInitialization();

                ContainerTabs = new Tabs { Parent = this };

                ContainerTabs.OnChangeTab += Event_OnChangeActiveTab;

                ContainerTabs.AddTab("Authorization", TabSize.Small, cmdAuthirizationPanel1, _containerAuthorization);
                //ContainerTabs.AddTab("Location", TabSize.Small, cmdLocation1, _containerSolarSystem);
                ContainerTabs.AddTab("SolarSystem", TabSize.Small, cmdShowContainerSolarSystem1, _containerSolarSystemOffline);
                ContainerTabs.AddTab("Pilots", TabSize.Small, cmdShowContainerPilots1, _containerPilotInfo);
                ContainerTabs.AddTab("Bookmarks", TabSize.Small, cmdShowContainerBookmarks1, _containerBookmarks);
                //ContainerTabs.AddTab("Signatures", TabSize.Small, null, _containerTravelHistory);
                ContainerTabs.AddTab("WebBrowser", TabSize.Large, cmdOpenWebBrowser1, _containerBrowser);
                ContainerTabs.AddTab("Map", TabSize.Map, cmdMap, _containerMap);
                ContainerTabs.AddTab("Version", TabSize.Large, cmdVersion1, _containerVersion);
                //ContainerTabs.AddTab("LostAndFoundOffice", TabSize.Small, null, _containerLostAndFoundOffice);
                //ContainerTabs.AddTab("Router", TabSize.Small, null, _containerRouter);

                //cmdMap _containerMap

                ContainerTabs.Activate("Authorization");

                Size = ContainerTabs.Active().Size;

                lblSolarSystemName = new LabelWithOptionalCopyTextOnDoubleClick
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = Color.LightGray,
                    Location = new Point(6, 5),
                    Name = "lblSolarSystemName",
                    Size = new Size(252, 18),
                    TabIndex = 5
                };

                lblSolarSystemName.MouseDown += Event_TitleBarMouseDown;

                lblSolarSystemName.DoubleClick += Event_TitleBarDoubleClick;

                TitleBar.Controls.Add(lblSolarSystemName);

                Global.Pilots.OnActivatePilot += GlobalEvent_ActivatePilot;
                Global.InternalBrowser.OnBrowserNavigate += Event_BrowserNavigate;

                DelegateStartProcess startProcessFunction = StartPilotAuthorizeFlow;
                new Thread(() => new CrestApiListener().ListenLocalhost(startProcessFunction)) { IsBackground = true }.Start();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WindowMonitoring.WindowMonitoring] Critical error {0}", ex);
            }
        }

        private void GlobalEvent_ActivatePilot(PilotEntity pilot)
        {
            Log.DebugFormat("[WindowMonitoring.GlobalEvent_ActivatePilot] Before ContainerEvent_ChangeSolarSystemInfo : {0}", pilot.Name);
            ContainerEvent_ChangeSolarSystemInfo(Global.Space.GetTitle(pilot.Location));
            Log.DebugFormat("[WindowMonitoring.GlobalEvent_ActivatePilot] Before ActivateLocationTab : {0}", pilot.Name);
            ActivateLocationTab();
            Log.DebugFormat("[WindowMonitoring.GlobalEvent_ActivatePilot] End : {0}", pilot.Name);
        }

        private void ActivateLocationTab()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ActivateLocationTab()));
            }

            if(Global.Pilots.Selected.Location.Id == null)
            {
                cmdMap.ForeColor = Color.DimGray;
            }
            else
            {
                cmdMap.ForeColor = Color.Silver;
            }
        }

        private void WaitKey()
        {
            while (this.IsHandleCreated)
            {

                short res1 = GetAsyncKeyState(VK_SHIFT);
                short res2 = GetAsyncKeyState(VK_Z);
                if (res1 != 0 && res2 != 0)
                    MessageBox.Show("Hello");
            }
        }


        public const int VK_SHIFT = 0x10;
        public const int VK_Z = 0x5A;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetAsyncKeyState(int vkey);

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {

                var txtInClip = Clipboard.GetText();

                var parts = txtInClip.Split('\t');

                if (parts.Length == 6)
                {
                    var signatureCode = parts[0];
                    var signatureType = parts[2];
                    var signatureName = parts[3];

                    var label = "";

                    label = "[" + signatureCode + "]";

                    if (signatureType.ToUpper().IndexOf("ЧЕРВОТОЧИНА") > -1 || signatureType.ToUpper().IndexOf("WORMHOLE") > -1)
                    {
                        label = "WH " + label + "";
                    }

                    if (signatureType.ToUpper().IndexOf("ГАЗ") > -1 || signatureType.ToUpper().IndexOf("GAS SITE") > -1)
                    {
                        label = "Gas " + label + " " + signatureName;
                    }

                    if (signatureType.ToUpper().IndexOf("ДАННЫЕ") > -1 || signatureType.ToUpper().IndexOf("DATA SITE") > -1)
                    {
                        label = "Data " + label + " " + signatureName;
                    }

                    if (signatureType.ToUpper().IndexOf("АРТЕФАКТЫ") > -1 || signatureType.ToUpper().IndexOf("RELIC SITE") > -1)
                    {
                        label = "Relic " + label + " " + signatureName;
                    }
                    try
                    {
                        Clipboard.SetText(label);
                    }
                    catch(Exception)
                    {
                        
                        //throw;
                    }
                    
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void WndProc(ref Message m)
        {
            if (ContainerTabs == null || ContainerTabs.Active() == null) return;

            if (ContainerTabs.Active().Name != "WebBrowser" && ContainerTabs.Active().Name != "Map")
            {
                base.WndProc(ref m);
                return;
            }

            // Resize form 

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
            _containerSolarSystem = new whlSolarSystem();
            #region Events
            //_containerSolarSystem.OnChangeSolarSystemInfo += ContainerEvent_ChangeSolarSystemInfo;
            _containerSolarSystem.OnShowTravelHistory += ContainerEvent_ShowTravelHistory;
            _containerSolarSystem.OnShowLostAndFoundOffice += ContainerEvent_ShowLostAndFoundOffice;
            _containerSolarSystem.OnBrowserNavigate += Event_BrowserNavigate;
            _containerSolarSystem.OnContainerActivate += ContainerEvent_Activate;
            #endregion

            _containerTravelHistory = new whlTravelHistory();
            #region Events
            _containerTravelHistory.OnShowLocation += ContainerEvent_ShowLocation;
            #endregion

            _containerBrowser = new ucRichBrowser();
            #region Events
            _containerSolarSystemOffline = new whlSolarSystemOffline();
            
            _containerSolarSystemOffline.OnBrowserNavigate += Event_BrowserNavigate;
            #endregion

            _containerMap = new MapControl();
            //OnChangeSolarSystem += _containerMap.ChangeCurrentLocation;

            _containerVersion = new whlVersion();

            _containerBookmarks = new whlBookmarks();

            _containerAuthorization = new whlAuthorization();
            #region Events
            _containerAuthorization.OnChangeSelectedPilot += ContainerEvent_ChangeSelectedPilot;
            #endregion

            _containerLostAndFoundOffice = new whlLostAndFoundOffice();
            #region Events
            _containerLostAndFoundOffice.OnShowSolarSystem += ContainerEvent_ShowSolarSystem;
            #endregion

            _containerRouter = new whlRouter();
            #region Events
            _containerRouter.OnContainerActivate += ContainerEvent_Activate;
            #endregion

            pnlContainer.Controls.Add(_containerPilotInfo);
            pnlContainer.Controls.Add(_containerBookmarks);
            pnlContainer.Controls.Add(_containerSolarSystem);
            pnlContainer.Controls.Add(_containerTravelHistory);
            pnlContainer.Controls.Add(_containerSolarSystemOffline);
            pnlContainer.Controls.Add(_containerVersion);
            pnlContainer.Controls.Add(_containerAuthorization);
            pnlContainer.Controls.Add(_containerLostAndFoundOffice);
            pnlContainer.Controls.Add(_containerRouter);
            pnlContainer.Controls.Add(_containerMap);

            _containerBrowser.ChangeViewMode += ChangeViewMode;

            pnlContainer.Controls.Add(_containerBrowser);

            _containerPilotInfo.OnBrowserNavigate += Event_BrowserNavigate;

            _containerBrowser.ParentWindow = this;
        }

        private void ContainerEvent_Activate(string name)
        {
            ContainerTabs.Activate(name);
        }

        private void ContainerEvent_ShowLostAndFoundOffice()
        {
            _containerLostAndFoundOffice.Refresh(Global.Pilots.Selected);
            ContainerTabs.Activate("LostAndFoundOffice");
        }

        private void ContainerEvent_ShowSolarSystem()
        {
            ContainerTabs.Activate("Location");
        }

        private void WindowMonitoring_Load(object sender, EventArgs e)
        {
            lblVersionID.Text = Global.ApplicationSettings.CurrentVersion;

            Log.DebugFormat("[WindowMonitoring] Version: {0}", lblVersionID.Text);
            
            CreateTooltipsForStatics();

            

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

            Global.Pilots.OnAddPilot += GlobalEvent_AddNewPilot;

            //TODO: Recomment before create version!!!
            Global.Metrics.PublishOnApplicationStart(Global.Settings.CurrentVersion);
        }

        private void GlobalEvent_AddNewPilot(PilotEntity pilot)
        {
            pilot.OnChangeSolarSystem += GlobalEvent_PilotChangeLocation;
        }

        private void GlobalEvent_PilotChangeLocation(PilotEntity pilot, string systemfrom, string systemto)
        {
            if (Global.Pilots.Selected.Id != pilot.Id) return;

            ContainerEvent_ChangeSolarSystemInfo(Global.Space.GetTitle(pilot.Location));

            //_containerMap.Relocation(pilot, systemfrom, systemto, true);

            //_containerMap.Refresh();

            

            //RefreshSolarSystemInformation(pilot.Location);
        }

        private void Event_BrowserNavigate(string address)
        {
            _containerBrowser.BrowserUrlExecute(address);
            ContainerTabs.Activate("WebBrowser");
        }

        private void ContainerEvent_ChangeSelectedPilot()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ContainerEvent_ChangeSelectedPilot()));
            }
            try
            {
                Log.DebugFormat("[WindowMonitoring.Event_ChangeSelectedPilot] Global.Pilots.Selected.Location.Id {0}", Global.Pilots.Selected.Location.Id);
                if (Global.Pilots.Selected.Location.Id != null)
                {
                    RefreshSolarSystemInformation(Global.Pilots.Selected.Location);
                    if(Global.Pilots.Selected.Key == "")
                    {
                        Global.Pilots.Selected.Key = Global.Pilots.Selected.Name;
                        //Global.Pilots.Selected.SpaceMap = Global.Pilots.Selected.Name;
                    }
                    _containerMap = new MapControl();
                    _containerMap.ActivateContainer();
                    //ContainerTabs.AddTab("Map", TabSize.Map, cmdMap, _containerMap);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[WindowMonitoring.Event_ChangeSelectedPilot] Critical error. Exception {0}", ex);
            }
            Log.DebugFormat("[WindowMonitoring.Event_ChangeSelectedPilot] end");
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
                pnlContainer.Location = new Point(positionLeft - 0, -57);
                pnlContainer.Width = Width - 10;
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

        private void ContainerEvent_ChangeSolarSystemInfo(string info)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ContainerEvent_ChangeSolarSystemInfo(info)));
            }

            lblSolarSystemName.Text = info;

            if (Visible == false)
            {
                if (Tools.IsWSpaceSystem(Global.Pilots.Selected.Location.Name))
                {
                crlNotificay.BalloonTipTitle = @"EveJima";
                crlNotificay.BalloonTipText = @"Active pilot enter to new location. " + info;

                crlNotificay.Visible = true;
                crlNotificay.ShowBalloonTip(500);
            }
        }
        }


        private void ContainerEvent_ShowTravelHistory()
        {
            if (Global.Pilots.Count() == 0 || Global.Pilots.Selected == null || Global.Pilots.Selected.Location == null || Global.Pilots.Selected.Location.Name == "unknown") return;

            ContainerTabs.Activate("Signatures");
        }


        private void ContainerEvent_ShowLocation()
        {
            if (Global.Pilots.Count() == 0 || Global.Pilots.Selected == null || Global.Pilots.Selected.Location == null || Global.Pilots.Selected.Location.Name == "unknown") return;
            
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


        private void DrawPilotPanel(PilotEntity pilot)
        {
            if (pilot.Location != null && pilot.Location.Name != "unknown")
            {
                //cmdLocation.IsActive = true;
                //cmdLocation.Refresh();
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

            Global.Pilots.Selected.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.GetUpdates();
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
            _windowIsPinned = !_windowIsPinned;
            SetPinned();
        }

        private void SetPinned()
        {
            if (_windowIsPinned)
            {
                cmdPin.Image = Resources.pin;
                TopMost = true;
            }
            else
            {
                cmdPin.Image = Resources.unpin;
                TopMost = false;
            }

            Global.WorkEnvironment.IsPinned = _windowIsPinned;
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

            TitleBar.Width = Width;

        }
        #endregion

        private void Event_WindowDoubleClick(object sender, EventArgs e)
        {
            MinMaxFormResize();
        }

        private void MinMaxFormResize()
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
                Size = new Size(ContainerTabs.Active().CompactSize.Width, ContainerTabs.Active().CompactSize.Height);
            }
        }

        private void Event_TitleBarDoubleClick(object sender, EventArgs e)
        {
            if (_windowIsMinimaze)
            {
                _windowIsMinimaze = false;
                cmdMinimazeRestore.Image = Resources.minimize;
                Size = ContainerTabs.Active().Size;
                TitleBar.Width = Width;
            }
            else
            {
                _windowIsMinimaze = true;
                cmdMinimazeRestore.Image = Resources.restore;
                Size = ContainerTabs.Active().CompactSize;
                TitleBar.Width = Width;
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

        private void RefreshSolarSystemInformation(EveJimaUniverse.System location)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RefreshSolarSystemInformation(location)));
            }

            if (Global.Pilots.Count() > 0)
            {
                _containerSolarSystem.RefreshSolarSystem(location);
                //_containerTravelHistory.RefreshSolarSystem(location);
            }
        }

        private void WindowMonitoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_containerVersion == null) return;

            _containerVersion.DisposeBrowser();
            _containerVersion = null;

            _containerBrowser.DisposeBrowser();
            _containerBrowser = null;

            Global.WorkEnvironment.SaveChanges();
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
            crlNotificay.ShowBalloonTip(200);
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

            if(ContainerTabs.Active().Name == "Map")
            {
                ContainerTabs.Active().Size = new Size(Width, Height);
                ContainerTabs.Resize();
            }
            
        }

        private void Event_RefreshActivePilot(object sender, EventArgs e)
        {
            if (Global.Pilots.Count() > 0)
            {
                try
                {
                    var activeProgramName = Tools.GetActiveWindowTitle();

                    if (activeProgramName == null) return;

                    //Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] Active title {0}", activeProgramName);

                    if (!activeProgramName.StartsWith("EVE - ")) return;

                    var pilotName = activeProgramName.Replace("EVE - ", "") + "";

                    //Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] pilotName {0}", pilotName);
                    //Log.DebugFormat("[WindowMonitoring.Event_RefreshActivePilot] Global.Pilots.Selected.Name {0}", Global.Pilots.Selected.Name);

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


        private void Event_LocationChange(object sender, EventArgs e)
        {
            if (isLoaded == false) return;

            Global.WorkEnvironment.LocationMaximizeX = Location.X;
            Global.WorkEnvironment.LocationMaximizeY = Location.Y;
        }

        private void WindowMonitoring_Activated(object sender, EventArgs e)
        {
            if (isLoaded == false)
            {
                Location = new Point(Global.WorkEnvironment.LocationMaximizeX, Global.WorkEnvironment.LocationMaximizeY);
                isLoaded = true;

                _windowIsPinned = Global.WorkEnvironment.IsPinned;

                SetPinned();


                //Thread.Sleep(3000);
                //var screen = new ScreenUpdateToServer { ActionType = "LoadAllPilotesFromStorage" };
                //screen.AuthorizeAllPilotsInAccount += _containerAuthorization.AuthorizeAllPilotsInAccount;
                //screen.ShowDialog();
                //_containerAuthorization.LoadAllPilotesFromStorage();
                //LoadAllPilotesFromStorage();
                //MessageBox.Show("1");

                

                
            }
        }

        private void Event_WindowEndResize(object sender, EventArgs e)
        {
            if(ContainerTabs.Active().Name == "Map")
            {
                _containerMap.Event_Map_OnResize();
            }
        }

        private void WindowMonitoring_Shown(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            //var screen = new ScreenUpdateToServer { ActionType = "LoadAllPilotesFromStorage" };
            //screen.AuthorizeAllPilotsInAccount += _containerAuthorization.AuthorizeAllPilotsInAccount;
            //screen.ShowDialog();
            //_containerAuthorization.LoadAllPilotesFromStorage();
            //LoadAllPilotesFromStorage();





        }


    }
}
