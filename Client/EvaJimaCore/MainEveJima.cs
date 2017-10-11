using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.BLL;
using EveJimaCore.BLL.Map;
using EveJimaCore.Logic.MapInformation;
using EveJimaCore.Logic.ToolBar;
using EveJimaCore.MainScreen;
using EveJimaCore.Properties;
using EveJimaCore.UiTools;
using EveJimaCore.WhlControls;
using log4net;

namespace EveJimaCore
{
    public partial class MainEveJima : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainEveJima));

        public LabelWithOptionalCopyTextOnDoubleClick lblSolarSystemName;

        private WindowParameters Parametrs { get;}

        public string SelectedContainer
        {
            get { return _selectedContainer; }
            set { _selectedContainer = value; }
        }

        #region Containers

        private whlAuthorization _containerAuthorization;

        private ucRichBrowser _containerBrowser;

        private whlBookmarks _containerBookmarks;

        private MapControl _containerMap;

        private EveCrlLocation _containerLocation;

        private whlSolarSystemOffline _containerSolarSystemOffline;

        private EveCrlSettings _containerSettings;

        private EveCrlPathfinder _containerPathfinder;

        private whlVersion _containerVersion;

        #endregion


        public MainEveJima()
        {
            InitializeComponent();

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

            _containerBrowser = new ucRichBrowser
            {
                Visible = false,
                Dock = DockStyle.Fill,
                ParentWindow = this
            };

            _containerBookmarks = new whlBookmarks { Visible = false, Dock = DockStyle.Fill };

            _containerSettings = new EveCrlSettings { Visible = false, Dock = DockStyle.Fill };

            _containerSettings.ActivateContainer();

            _containerPathfinder = new EveCrlPathfinder { Visible = false, Dock = DockStyle.Fill };

            _containerVersion = new whlVersion { Visible = false, Dock = DockStyle.Fill };

            _containerMap = new MapControl { Visible = false , Dock = DockStyle.Fill };

            _containerLocation = new EveCrlLocation { Visible = false, Dock = DockStyle.Fill };

            _containerSolarSystemOffline = new whlSolarSystemOffline { Visible = false, Dock = DockStyle.Fill };

            pnlContainers.Controls.Add(_containerAuthorization);
            pnlContainers.Controls.Add(_containerBrowser);
            pnlContainers.Controls.Add(_containerBookmarks);
            pnlContainers.Controls.Add(_containerMap);
            pnlContainers.Controls.Add(_containerLocation);
            pnlContainers.Controls.Add(_containerSolarSystemOffline);
            pnlContainers.Controls.Add(_containerSettings);
            pnlContainers.Controls.Add(_containerPathfinder);
            pnlContainers.Controls.Add(_containerVersion);

        }

        private string _selectedContainer = "Authorization";

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
            }

            Parametrs.MetaData = metaData;
            Size = new Size(metaData.Size.Width, metaData.Size.Height);
        }

        private void Event_BrowserNavigate(string address)
        {
            if(Global.ApplicationSettings.IsUseBrowser)
            {
                _containerBrowser.BrowserUrlExecute(address);
                crlToolbar.ActivatePanel("Browser");
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

            Global.Pilots.Selected.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.Key = Global.Pilots.Selected.Name;
            Global.Pilots.Selected.SpaceMap.GetUpdates();
        }

        

        private void GlobalEvent_ActivatePilot(PilotEntity pilot)
        {
            Log.DebugFormat("[MainEveJima.GlobalEvent_ActivatePilot] Before ContainerEvent_ChangeSolarSystemInfo : {0}", pilot.Name);
            ContainerEvent_ChangeSolarSystemInfo(Global.Space.GetTitle(pilot.Location));
            Log.DebugFormat("[MainEveJima.GlobalEvent_ActivatePilot] Before ActivateLocationTab : {0}", pilot.Name);

            crlToolbar.EnablePanel("Location");
            crlToolbar.EnablePanel("Pathfinder");
            
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

                var stringSize = e.Graphics.MeasureString(systemLabel, drawFont);

                var drawFormat = new StringFormat();

                e.Graphics.DrawString(systemLabel, drawFont, drawBrushName, 30, 6, drawFormat);

                if(Tools.IsWSpaceSystem(location.Name))
                {
                    var txtSolarSystemStaticFirst = "";

                    if (string.IsNullOrEmpty(location.Static) == false)
                    {
                        var wormholeFirst = Global.Space.WormholeTypes[location.Static.Trim()];

                        txtSolarSystemStaticFirst = wormholeFirst.Name + "[" + wormholeFirst.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem(wormholeFirst.LeadsTo));

                        e.Graphics.DrawString(txtSolarSystemStaticFirst, drawFont, drawBrushName, 30 + stringSize.Width + 1, 6, drawFormat);
                    }

                    var stringSizeStaticI = e.Graphics.MeasureString(txtSolarSystemStaticFirst, drawFont);

                    if (string.IsNullOrEmpty(location.Static2) == false)
                    {
                        var txtSolarSystemSecondStatic = "";
                        var wormholeSecond = Global.Space.WormholeTypes[location.Static2.Trim()];

                        txtSolarSystemSecondStatic = wormholeSecond.Name + "[" + wormholeSecond.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Tools.GetColorBySolarSystem(wormholeSecond.LeadsTo));

                        e.Graphics.DrawString(txtSolarSystemSecondStatic, drawFont, drawBrushName, 30 + stringSize.Width + 1 + stringSizeStaticI.Width + 3, 6, drawFormat);
                    }
                }
            }
        }

        private void timerCheckClipboard_Tick(object sender, EventArgs e)
        {
            if(!Global.ApplicationSettings.IsSignatureRebuildEnabled) return;

            var txtInClip = Clipboard.GetText();

            var parts = txtInClip.Split('\t');

            if (parts.Length == 6)
            {
                #region Solo signature
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
                catch (Exception)
                {

                    //throw;
                }
                #endregion
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
    }
}
