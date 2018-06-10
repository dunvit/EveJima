using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation;
using EveJimaCore.Logic.ToolBar;
using EveJimaCore.MainScreen;
using EveJimaCore.Properties;
using EveJimaCore.ScheduledTasks;
using EveJimaCore.UiTools;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore
{
    public partial class MainEveJima : Form
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_NO_APP_ASSOCIATED = 1155;

        private static readonly ILog Log = LogManager.GetLogger(typeof(MainEveJima));

        #region Timers

        private System.Windows.Forms.Timer _updateRegistryTimer;

        private System.Windows.Forms.Timer _htmlRunnerTimer;

        #endregion

        public LabelWithOptionalCopyTextOnDoubleClick lblSolarSystemName;

        private WindowParameters Parametrs { get;}

        #region Containers

        private whlAuthorization _containerAuthorization;

        private ucRichBrowser _containerBrowser;

        private whlBookmarks _containerBookmarks;

        private whlNeedLoadPilot _containerNeedLoadPilot;

        private whlRouter _containerRouter;

        private eveCrlTravelHistory _containerTravelHistory;

        private MapControl _containerMap;

        private EveCrlLocation _containerLocation;

        private whlSolarSystemOffline _containerSolarSystemOffline;

        private EveCrlSettings _containerSettings;

        private EveCrlPathfinder _containerPathfinder;

        private whlVersion _containerVersion;

        private UserCounter _taskUserCounter;

        private WebBrowser browserUserCounter = new WebBrowser();

        private WebBrowser browserMetrics = new WebBrowser();

        #endregion

        public MainEveJima()
        {
            InitializeComponent();

            InitializaTimers();

            Parametrs = new WindowParameters();

            Global.Pilots.OnActivatePilot += GlobalEvent_ActivatePilot;
            Global.InternalBrowser.OnBrowserNavigate += Event_BrowserNavigate;
            Global.Presenter.OnCloseApplication += Event_Close;
            Global.Presenter.OnLocationChange += Event_LocationChange;
            Global.Presenter.OnEnterToSolarSystem += EventOnEnterToSolarSystem;

            DelegateStartProcess startProcessFunction = StartPilotAuthorizeFlow;
            new Thread(() => new CrestApiListener().ListenLocalhost(startProcessFunction)) { IsBackground = true }.Start();

            ContainersInitialization();

            crlToolbar.OnSelectTab += Event_Toolbar_SelectTab;

            crlToolbar.ActivatePanel("Authorization");

            RegistrHotKeys();

            _taskUserCounter = new UserCounter();

            _taskUserCounter.OnNavigate += EventNavigateInternalBrowser;

            browserUserCounter.ScriptErrorsSuppressed = true;

            browserUserCounter.Navigate(_taskUserCounter.CounterAddress);

            browserMetrics.ScriptErrorsSuppressed = true;
        }

        private void EventNavigateInternalBrowser(string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(EventNavigateInternalBrowser), address);
                return;
            }

            try
            {
                if(browserUserCounter.IsBusy) return;

                browserUserCounter.Refresh();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND || e.NativeErrorCode == ERROR_ACCESS_DENIED || e.NativeErrorCode == ERROR_NO_APP_ASSOCIATED)
                {
                    Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical error on updated user counter in address " + address + " Exception is " + e.Message);
                }
            }
            catch (Exception exception)
            {
                Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical error on updated user counter in address " + address + " Exception is " + exception.Message);
            }
            catch
            {
                Log.Error("[MainEveJima.EventNavigateInternalBrowser] Critical unexcepted error on updated user counter in address " + address + " ");
            }

        }

        private void EventbAddMetric(string address)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(EventbAddMetric), address);
                return;
            }

            try
            {
                if (browserMetrics.IsBusy) return;

                browserMetrics.Navigate(address);
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND || e.NativeErrorCode == ERROR_ACCESS_DENIED || e.NativeErrorCode == ERROR_NO_APP_ASSOCIATED)
                {
                    Log.Error("[MainEveJima.EventbAddMetric] Critical error on add metric in address " + address + " Exception is " + e.Message);
                }
            }
            catch (Exception exception)
            {
                Log.Error("[MainEveJima.EventbAddMetric] Critical error on add metric in address " + address + " Exception is " + exception.Message);
            }
            catch
            {
                Log.Error("[MainEveJima.EventbAddMetric] Critical unexcepted error on add metric in address " + address + " ");
            }

        }

        private void InitializaTimers()
        {
            _updateRegistryTimer = new System.Windows.Forms.Timer { Interval = 100, Enabled = Global.ApplicationSettings.IsInterceptLinksFromEVE };
            _updateRegistryTimer.Tick += timerUpdateRegistry_Tick;

            isNeedCheckActiveWindow = true;

            _htmlRunnerTimer = new System.Windows.Forms.Timer { Interval = 100, Enabled = true };
            _htmlRunnerTimer.Tick += timerUpdateHtmlRunner_Tick;

            isNeedCheckRunHtml = true;
        }

        private bool isNeedCheckRunHtml;

        private void timerUpdateHtmlRunner_Tick(object sender, EventArgs e)
        {
            if (isNeedCheckRunHtml == false) return;

            isNeedCheckRunHtml = false;

            var path = AppDomain.CurrentDomain.BaseDirectory + @"Browser\History\";

            var directory = new DirectoryInfo(path);

            if(directory.Exists == false)
            {
                Directory.CreateDirectory(path);
                directory = new DirectoryInfo(path);
            }

            var links = new List<string>();

            foreach (var file in directory.GetFiles())
            {
                var text = File.ReadAllText(file.FullName).Replace(@"\r", "").Replace(@"\n", "").Trim();

                Log.Error("[Interceptor.CheckIsNeedRunHtml] Found link '" + text + "'");

                links.Add(text);

                file.Delete();
            }

            foreach (var link in links)
            {
                Log.Error("[Interceptor.CheckIsNeedRunHtml] Execute link '" + link + "'");
                Global.InternalBrowser.OnBrowserNavigate(link);
                Thread.Sleep(100);
            }

            isNeedCheckRunHtml = true;
        }

        private bool isNeedCheckActiveWindow;

        private void timerUpdateRegistry_Tick(object sender, EventArgs e)
        {
            //Log.Error("[MainEveJima.timerUpdateRegistry_Tick] Start checking");

            try
            {
                if(isNeedCheckActiveWindow == false)
                {
                    //Log.Error("[MainEveJima.timerUpdateRegistry_Tick] isNeedCheckActiveWindow false");
                    return;
                }

                if(Global.LinkInterceptor == null)
                {
                    //Log.Error("[MainEveJima.timerUpdateRegistry_Tick] webBrowserInterceptor null");
                    return;
                }

                if(Log == null)
                {
                    //Log.Error("[MainEveJima.timerUpdateRegistry_Tick] Log null");
                    return;
                }

                //Log.Error("[MainEveJima.timerUpdateRegistry_Tick] Start checking");

                isNeedCheckActiveWindow = false;

                var activeProgramName = Tools.GetActiveWindowTitle();

                Log.Debug("[MainEveJima.timerUpdateRegistry_Tick] activeProgramName is '" + activeProgramName + "'");

                if (activeProgramName == null && Global.LinkInterceptor.IsStarted)
                {
                    Log.Info("[MainEveJima.timerUpdateRegistry_Tick] StopIntercepting for activeProgramName is '" + activeProgramName + "'");
                    Global.LinkInterceptor.StopIntercepting();
                    isNeedCheckActiveWindow = true;
                    return;
                }

                //Log.DebugFormat("[MainEveJima.Event_RefreshActivePilot] Active title {0}", activeProgramName);

                if (activeProgramName.StartsWith("EVE - "))
                {
                    if (Global.LinkInterceptor.IsStarted == false)
                    {
                        Log.Info("[MainEveJima.timerUpdateRegistry_Tick] StartIntercepting for activeProgramName is '" + activeProgramName + "'");
                        Global.LinkInterceptor.StartIntercepting();
                    }
                    else
                    {
                        Log.Info("[MainEveJima.timerUpdateRegistry_Tick] No need start intercepting for activeProgramName is '" + activeProgramName + "'");
                    }

                    isNeedCheckActiveWindow = true;
                }
                else
                {
                    if (Global.LinkInterceptor.IsStarted)
                    {
                        Log.Error("[MainEveJima.timerUpdateRegistry_Tick] StopIntercepting for activeProgramName is '" + activeProgramName + "'");
                        Global.LinkInterceptor.StopIntercepting();
                    }

                    isNeedCheckActiveWindow = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("[MainEveJima.timerUpdateRegistry_Tick] Critical error " + ex + "");
                isNeedCheckActiveWindow = true;
            }

            
        }

        private void EventOnEnterToSolarSystem(string obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(EventOnEnterToSolarSystem), obj);
                return;
            }
            TitleBar.Refresh();
        }


        private void Event_Close()
        {
            try
            {
                _containerVersion.DisposeBrowser();
                _containerBrowser.DisposeBrowser();

                if (crlNotificay != null)
                {
                    crlNotificay.Visible = false;
                    crlNotificay.Icon = null;
                    crlNotificay.Dispose();
                    crlNotificay = null;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[MainEveJima.Event_CloseApplication] Critical error {0}", ex);
            }
            Global.Dispose();
            Close();
        }

        private void ContainersInitialization()
        {
            _containerAuthorization = new whlAuthorization { Visible = false, Dock = DockStyle.Fill };
            _containerAuthorization.RefreshAuthorizationStatus();
            _containerAuthorization.OnSelectUser += Event_ChangeActivePilot;

            _containerBrowser = new ucRichBrowser
            {
                Visible = false,
                Dock = DockStyle.Fill,
                ParentWindow = this
            };

            _containerBrowser.OnForceResize += Event_ForceResize;

            _containerBookmarks = new whlBookmarks { Visible = false, Dock = DockStyle.Fill };

            _containerNeedLoadPilot = new whlNeedLoadPilot { Visible = false, Dock = DockStyle.Fill };

            _containerSettings = new EveCrlSettings { Visible = false, Dock = DockStyle.Fill };

            _containerSettings.ActivateContainer();

            _containerPathfinder = new EveCrlPathfinder { Visible = false, Dock = DockStyle.Fill };

            _containerVersion = new whlVersion { Visible = false, Dock = DockStyle.Fill };

            _containerMap = new MapControl { Visible = false , Dock = DockStyle.Fill };

            _containerLocation = new EveCrlLocation { Visible = false, Dock = DockStyle.Fill };

            _containerRouter = new whlRouter { Visible = false, Dock = DockStyle.Fill };

            _containerTravelHistory = new eveCrlTravelHistory { Visible = false, Dock = DockStyle.Fill };
            _containerTravelHistory.OnUseModule += EventbAddMetric;

            _containerSolarSystemOffline = new whlSolarSystemOffline { Visible = false, Dock = DockStyle.Fill };

            pnlContainers.Controls.Add(_containerAuthorization);
            pnlContainers.Controls.Add(_containerBrowser);
            pnlContainers.Controls.Add(_containerBookmarks);
            pnlContainers.Controls.Add(_containerNeedLoadPilot);
            
            pnlContainers.Controls.Add(_containerMap);
            pnlContainers.Controls.Add(_containerLocation);
            pnlContainers.Controls.Add(_containerRouter);
            pnlContainers.Controls.Add(_containerTravelHistory);
            pnlContainers.Controls.Add(_containerSolarSystemOffline);
            pnlContainers.Controls.Add(_containerSettings);
            pnlContainers.Controls.Add(_containerPathfinder);
            pnlContainers.Controls.Add(_containerVersion);

            
        }

        private void Event_ChangeActivePilot(string activePilotName)
        {
            crlToolbar.ActivatePanel("Location");
        }

        private void Event_ForceResize()
        {
            crlToolbar.ActivatePanel("Browser");
            // Открыть окно в полный размер браузера


            if (Parametrs.IsMinimaze)
            {
                Parametrs.IsMinimaze = false;
                cmdMinimazeRestore.Image = Resources.minimize;
                Size = new Size(Parametrs.SizeBeforeMinimizate.Width, Parametrs.SizeBeforeMinimizate.Height);
            }

            if (TopMost == false)
            {
                TopMost = true;
                TopMost = false;
            }
        }

        private void Event_Toolbar_SelectTab(string module, PanelMetaData metaData)
        {
            foreach(Control control in pnlContainers.Controls)
            {
                if(control.Visible) control.Visible = false;
            }

            switch(module)
            {
                case "Authorization":
                    _containerAuthorization.Visible = true;
                    break;
                case "Browser":
                    _containerBrowser.Visible = true;
                    break;

                case "Bookmarks":
                    _containerBookmarks.Visible = true;
                    break;

                case "Settings":
                    _containerSettings.Visible = true;
                    break;

                case "Pathfinder":
                    _containerPathfinder.Visible = true;
                    break;

                case "Version":
                    _containerVersion.Visible = true;
                    break;

                case "Location":

                    if(Global.ApplicationSettings.IsUseMap)
                    {
                        _containerMap.Visible = true;
                    }
                    else
                    {
                        _containerLocation.Visible = true;
                    }
                    break;

                case "SolarSystem":
                    _containerSolarSystemOffline.Visible = true;
                    break;

                case "Router":
                    _containerRouter.ActivateContainer();
                    _containerRouter.Visible = true;
                    break;

                case "TravelHistory":
                    _containerTravelHistory.ActivateContainer();
                    _containerTravelHistory.Visible = true;
                    break;

                case "NeedLoadPilot":
                    _containerNeedLoadPilot.Visible = true;
                    break;
            }

            Parametrs.MetaData = metaData;
            Size = new Size(metaData.Size.Width, metaData.Size.Height);
        }

        private void Event_BrowserNavigate(string address)
        {
            if(Global.ApplicationSettings.IsUseBrowser)
            {
                if (Parametrs.IsMinimaze)
                {
                    Parametrs.IsMinimaze = false;
                    cmdMinimazeRestore.Image = Resources.minimize;
                    Size = new Size(Parametrs.SizeBeforeMinimizate.Width, Parametrs.SizeBeforeMinimizate.Height);
                }

                _containerBrowser.BrowserUrlExecute(address);
                crlToolbar.ActivatePanel("Browser");

                Focus();
            }
            
        }

        public void StartPilotAuthorizeFlow(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(StartPilotAuthorizeFlow), value);
                return;
            }

            Log.DebugFormat("[MainEveJima.StartPilotAuthorizeFlow] get value: {0}", value);

            _containerAuthorization.PilotAuthorizeFlow(value);

            BringApplicationToFront();

            if (Global.ApplicationSettings.IsUseMap == false) return;

            Global.Pilots.Selected.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.GetUpdates();
        }

        

        private void GlobalEvent_ActivatePilot(PilotEntity pilot)
        {
            Log.DebugFormat("[MainEveJima.GlobalEvent_ActivatePilot] Before ContainerEvent_ChangeSolarSystemInfo : {0}", pilot.Name);
            ContainerEvent_ChangeSolarSystemInfo(Global.Space.GetTitle(pilot.Location));
            Log.DebugFormat("[MainEveJima.GlobalEvent_ActivatePilot] Before ActivateLocationTab : {0}", pilot.Name);

            _containerRouter.ActivateContainer();

            crlToolbar.EnablePanel("Location");
            crlToolbar.EnablePanel("Pathfinder");
            crlToolbar.EnablePanel("Router");
            crlToolbar.EnablePanel("TravelHistory");

            Log.DebugFormat("[MainEveJima.GlobalEvent_ActivatePilot] End : {0}", pilot.Name);
        }

        private void ContainerEvent_ChangeSolarSystemInfo(string info)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ContainerEvent_ChangeSolarSystemInfo(info)));
            }

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

        private void SetPinned()
        {
            if (Parametrs.IsPinned)
            {
                cmdPin.Image = Resources.pin;
                TopMost = true;
            }
            else
            {
                cmdPin.Image = Resources.unpin;
                TopMost = false;
            }

            Global.WorkEnvironment.IsPinned = Parametrs.IsPinned;
            Global.ApplicationSettings.Save();
        }



        private void Event_ResizeWindow(object sender, EventArgs e)
        {
            crlToolbar.ResetOwnerSize(Width, Height);
            Refresh();
        }

        private void Event_Toolbar_Paint(object sender, PaintEventArgs e)
        {
            if(Global.Pilots.Selected != null)
            {
                
                var location = Global.Pilots.Selected.Location;
                var systemLabel = location.Name;

                if(location.Name == "unknown") return;

                if (Tools.IsWSpaceSystem(location.Name))
                {
                    if (location.Class != null)
                    {
                        systemLabel = systemLabel + "[C" + location.Class + "]";
                    }
                    else
                    {
                        systemLabel = systemLabel + "[Shattered]";
                    }
                }

                var drawFont = new Font("Verdana", 7, FontStyle.Bold);
                var drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem(location.Security.ToString()));

                if (Tools.IsWSpaceSystem(location.Name))
                {
                    drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem("C" + location.Class));
                }

                if(Global.ApplicationSettings.IsUseWhiteColorForSystems)
                {
                    drawBrushName = new SolidBrush(Color.AliceBlue);
                }

                var stringSize = e.Graphics.MeasureString(systemLabel, drawFont);

                var drawFormat = new StringFormat();

                e.Graphics.DrawString(systemLabel, drawFont, drawBrushName, 30, 6, drawFormat);

                var allTitleText = systemLabel;

                if (Tools.IsWSpaceSystem(location.Name))
                {
                    var txtSolarSystemStaticFirst = "";

                    if (string.IsNullOrEmpty(location.Static) == false)
                    {
                        var wormholeFirst = Global.Space.WormholeTypes[location.Static.Trim()];

                        txtSolarSystemStaticFirst = wormholeFirst.Name + "[" + wormholeFirst.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem(wormholeFirst.LeadsTo));

                        if (Global.ApplicationSettings.IsUseWhiteColorForSystems)
                        {
                            drawBrushName = new SolidBrush(Color.AliceBlue);
                        }

                        e.Graphics.DrawString(txtSolarSystemStaticFirst, drawFont, drawBrushName, 30 + stringSize.Width + 1, 6, drawFormat);

                        allTitleText = systemLabel + "  " + txtSolarSystemStaticFirst;
                    }

                    var stringSizeStaticI = e.Graphics.MeasureString(txtSolarSystemStaticFirst, drawFont);

                    if (string.IsNullOrEmpty(location.Static2) == false)
                    {
                        var txtSolarSystemSecondStatic = "";
                        var wormholeSecond = Global.Space.WormholeTypes[location.Static2.Trim()];

                        txtSolarSystemSecondStatic = wormholeSecond.Name + "[" + wormholeSecond.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem(wormholeSecond.LeadsTo));

                        if (Global.ApplicationSettings.IsUseWhiteColorForSystems)
                        {
                            drawBrushName = new SolidBrush(Color.AliceBlue);
                        }

                        e.Graphics.DrawString(txtSolarSystemSecondStatic, drawFont, drawBrushName, 30 + stringSize.Width + 1 + stringSizeStaticI.Width + 3, 6, drawFormat);

                        allTitleText = systemLabel + "  " + txtSolarSystemSecondStatic;
                    }
                }

               // var sizeTitle = e.Graphics.MeasureString(allTitleText, drawFont);
               // drawBrushName = new SolidBrush(Color.DarkOrange);
               // e.Graphics.DrawString(Global.Pilots.Selected.Name, drawFont, drawBrushName, 30 + sizeTitle.Width + 3, 6, drawFormat);
            }
        }

        private void timerCheckClipboard_Tick(object sender, EventArgs e)
        {
            if(!Global.ApplicationSettings.IsSignatureRebuildEnabled) return;

            try
            {
                var txtInClip = Clipboard.GetText();

                var parts = txtInClip.Split('\t');

                if (parts.Length == 6)
                {
                    #region Solo signature
                    var signatureCode = parts[0];
                    var signatureType = parts[2];
                    var signatureName = parts[3];

                    var label = "";

                    bool isDetected = false;

                    label = "[" + signatureCode + "]";

                    if (signatureType.ToUpper().IndexOf("ЧЕРВОТОЧИНА") > -1 || signatureType.ToUpper().IndexOf("WORMHOLE") > -1)
                    {
                        label = "WH " + label + "";
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("ГАЗ") > -1 || signatureType.ToUpper().IndexOf("GAS SITE") > -1)
                    {
                        label = "Gas " + label + " " + signatureName;
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("ДАННЫЕ") > -1 || signatureType.ToUpper().IndexOf("DATA SITE") > -1 || signatureType.ToUpper().IndexOf("ИНФОРМАЦИОН") > -1)
                    {
                        label = "Data " + label + " " + signatureName;
                        isDetected = true;
                    }

                    if (signatureType.ToUpper().IndexOf("АРТЕФАКТЫ") > -1 || signatureType.ToUpper().IndexOf("RELIC SITE") > -1 || signatureType.ToUpper().IndexOf("АРХЕОЛОГИЧ") > -1)
                    {
                        label = "Relic " + label + " " + signatureName;
                        isDetected = true;
                    }



                    try
                    {
                        if (isDetected == false)
                        {
                            label = label + " " + signatureName;
                        }

                        Clipboard.SetText(label);
                    }
                    catch (Exception ex)
                    {
                        var a = ex.Message;
                        //throw;
                    }
                    #endregion
                }
            }
            catch(Exception exception)
            {
                Log.ErrorFormat("[MainEveJima.timerCheckClipboard_Tick] Critical error = {0}", exception.Message);


            }

            
        }

        private void RefreshActivePilot_Tick(object sender, EventArgs e)
        {
            if (Global.Pilots.Selected != null)
            {
                try
                {
                    var activeProgramName = Tools.GetActiveWindowTitle();

                    if (activeProgramName == null) return;

                    //Log.DebugFormat("[MainEveJima.Event_RefreshActivePilot] Active title {0}", activeProgramName);

                    if (!activeProgramName.StartsWith("EVE - ")) return;

                    var pilotName = activeProgramName.Replace("EVE - ", "") + "";

                    //Log.DebugFormat("[MainEveJima.Event_RefreshActivePilot] pilotName {0}", pilotName);
                    //Log.DebugFormat("[MainEveJima.Event_RefreshActivePilot] Global.Pilots.Selected.Name {0}", Global.Pilots.Selected.Name);

                    if (pilotName == Global.Pilots.Selected.Name) return;

                    Global.Pilots.Activate(pilotName);

                    _containerAuthorization.SelectPilot(pilotName);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("[MainEveJima.Event_RefreshActivePilot] Critical error. Exception {0}", ex);
                }
            }
        }

        private void MainEveJima_Load(object sender, EventArgs e)
        {
            Global.Pilots.OnAddPilot += GlobalEvent_AddNewPilot;

            Text = @"EveJima v" + Global.ApplicationSettings.CurrentVersion;

            if(Global.ApplicationSettings.IsNeedUpdateVersion)
            {
                crlToolbar.ActivatePanel("Version");
            }
        }

        

        private void GlobalEvent_AddNewPilot(PilotEntity pilot)
        {
            pilot.OnChangeSolarSystem += GlobalEvent_PilotChangeLocation;
        }

        private void GlobalEvent_PilotChangeLocation(PilotEntity pilot, string systemfrom, string systemto)
        {
            if (Global.Pilots.Selected.Id != pilot.Id) return;

            ContainerEvent_ChangeSolarSystemInfo(Global.Space.GetTitle(pilot.Location));

        }

        private void Event_LocationChange(Map obj)
        {
            
        }



        private void timerRefreshTitleBar_Tick(object sender, EventArgs e)
        {
            //crlToolbar.Refresh();
        }

        private void MainEveJima_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, OPENZKILLBOARD_HOTKEY_ID);
        }
    }
}
