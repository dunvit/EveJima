using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EveJimaCore.BLL;
using EveJimaCore.Main;
using EveJimaCore.Monitoring;
using EveJimaCore.Window;
using log4net;
using Global = EvaJimaCore.Global;

namespace EveJimaCore
{
    public sealed partial class EveJimaWindow : EveJimaBaseWindow
    {
        private static readonly ILog Log = LogManager.GetLogger(string.Empty);

        private readonly EveJimaTabsMetaData _controlsCollection = new EveJimaTabsMetaData();

        private readonly EventsMonitoring _eventsMonitoring = new EventsMonitoring();


        public EveJimaWindow()
        {
            InitializeComponent();

            if(!Tools.IsAppicationModeRuntime()) return;

            // From here only run time commands ----------------------------------------------------

            Text = @"EveJima " + Global.ApplicationSettings.CurrentVersion;

            crlTitlebar.OnCloseApplication += Event_CloseApplication;
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
            Global.Dispose();
            Close();
        }


        private void GlobalEvent_ActivatePilot(PilotEntity pilot)
        {
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

        private void Event_CloseApplication()
        {
            Application.Exit();
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

    }
}
