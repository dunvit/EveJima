using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EvaJimaCore;
using EveJimaCore.MainScreen;
using EveJimaCore.Properties;
using EveJimaCore.Tools;
using log4net;

namespace EveJimaCore.Main
{
    public partial class EveJimaTitlebar : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(EveJimaTitlebar));

        private Form Window { get; set; }
        private WindowParameters Parametrs { get; set; }
        public event Action OnCloseApplication;
        public event Action OnHideToTray;

        private string lastUserLocationUpdate = string.Empty;

        public EveJimaTitlebar()
        {
            InitializeComponent();
        }

        public void Initialize(Form window, WindowParameters parametrs)
        {
            Parametrs = parametrs;
            Window = window;
            UpdatePinStatus(!Global.WorkEnvironment.IsPinned);
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Log.Info("Start close application event.");
            OnCloseApplication?.Invoke();
        }

        private void Event_PinUnpinApplication(object sender, EventArgs e)
        {
            UpdatePinStatus(Parametrs.IsPinned);
        }

        private void UpdatePinStatus(bool isPinned)
        {
            Log.Debug("Started pin/unpin event. Parameter isPinned is " + isPinned);

            if (isPinned)
            {
                cmdPin.Image = Resources.unpin;
                Parametrs.IsPinned = false;
            }
            else
            {
                cmdPin.Image = Resources.pin;
                Parametrs.IsPinned = true;
            }

            Window.TopMost = Parametrs.IsPinned;

            Global.WorkEnvironment.IsPinned = Parametrs.IsPinned;
            Global.ApplicationSettings.Save();

            Log.Debug("Successed ended pin/unpin event. Parameter isPinned is " + isPinned);
        }

        private void Event_HideToTray(object sender, EventArgs e)
        {
            Log.Info("Hide application to tray.");
            OnHideToTray?.Invoke();
        }

        private void Event_MinimizeApplication(object sender, EventArgs e)
        {
            ChangeState();
        }

        public void ChangeState()
        {
            try
            {
                if (Parametrs.IsMinimaze)
                {
                    Log.Info("Restore application from minimaze state.");
                    Parametrs.IsMinimaze = false;
                    cmdMinimazeRestore.Image = Resources.minimize;
                    Window.Size = new Size(Parametrs.SizeBeforeMinimizate.Width, Parametrs.SizeBeforeMinimizate.Height);
                }
                else
                {
                    Log.Info("Set application to minimaze state.");
                    Parametrs.IsMinimaze = true;
                    cmdMinimazeRestore.Image = Resources.restore;
                    Parametrs.SizeBeforeMinimizate = new Size(Window.Size.Width, Window.Size.Height);
                    Window.Size = new Size(350, 30);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Critical error on mimimize/restore application. Error message is: {0}", ex);
            }
        }

        private void Event_RedrawCurrentLocationInfo(object sender, PaintEventArgs e)
        {
            if(!Common.IsAppicationModeRuntime()) return;

            Log.Info("[EveJimaTitlebar.Event_RedrawCurrentLocationInfo] Refresh");

            if (Global.Pilots == null) return;


            // From here only Runtime code

            if (Global.Pilots.Selected != null)
            {

                if (lastUserLocationUpdate == Global.Pilots.Selected.Name) return;

                lastUserLocationUpdate = Global.Pilots.Selected.Name;

                var textPositionTop = 8;

                var location = Global.Pilots.Selected.Location;
                var systemLabel = location.Name;

                if (location.Name == "unknown") return;

                if (Common.IsWSpaceSystem(location.Name))
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
                var drawBrushName = new SolidBrush(Common.GetColorBySolarSystem(location.Security.ToString()));

                if (Common.IsWSpaceSystem(location.Name))
                {
                    drawBrushName = new SolidBrush(Common.GetColorBySolarSystem("C" + location.Class));
                }

                if (Global.ApplicationSettings.IsUseWhiteColorForSystems)
                {
                    drawBrushName = new SolidBrush(Color.AliceBlue);
                }

                var stringSize = e.Graphics.MeasureString(systemLabel, drawFont);

                var drawFormat = new StringFormat();

                e.Graphics.DrawString(systemLabel, drawFont, drawBrushName, 30, textPositionTop, drawFormat);

                var allTitleText = systemLabel;

                if (Common.IsWSpaceSystem(location.Name))
                {
                    var txtSolarSystemStaticFirst = "";

                    if (string.IsNullOrEmpty(location.Static) == false)
                    {
                        var wormholeFirst = Global.Space.WormholeTypes[location.Static.Trim()];

                        txtSolarSystemStaticFirst = wormholeFirst.Name + "[" + wormholeFirst.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Common.GetColorBySolarSystem(wormholeFirst.LeadsTo));

                        if (Global.ApplicationSettings.IsUseWhiteColorForSystems)
                        {
                            drawBrushName = new SolidBrush(Color.AliceBlue);
                        }

                        e.Graphics.DrawString(txtSolarSystemStaticFirst, drawFont, drawBrushName, 30 + stringSize.Width + 1, textPositionTop, drawFormat);

                        allTitleText = systemLabel + "  " + txtSolarSystemStaticFirst;
                    }

                    var stringSizeStaticI = e.Graphics.MeasureString(txtSolarSystemStaticFirst, drawFont);

                    if (string.IsNullOrEmpty(location.Static2) == false)
                    {
                        var txtSolarSystemSecondStatic = "";
                        var wormholeSecond = Global.Space.WormholeTypes[location.Static2.Trim()];

                        txtSolarSystemSecondStatic = wormholeSecond.Name + "[" + wormholeSecond.LeadsTo + "]";

                        drawBrushName = new SolidBrush(Common.GetColorBySolarSystem(wormholeSecond.LeadsTo));

                        if (Global.ApplicationSettings.IsUseWhiteColorForSystems)
                        {
                            drawBrushName = new SolidBrush(Color.AliceBlue);
                        }

                        e.Graphics.DrawString(txtSolarSystemSecondStatic, drawFont, drawBrushName,
                            30 + stringSize.Width + 1 + stringSizeStaticI.Width + 3, textPositionTop, drawFormat);

                        allTitleText = systemLabel + "  " + txtSolarSystemSecondStatic;
                    }
                }
            }
        }

        public void RefreshLocationInfo()
        {
            Log.Info("[EveJimaTitlebar.RefreshLocationInfo] Refresh");
            Refresh();
        }
    }
}
