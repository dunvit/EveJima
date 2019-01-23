using System.Timers;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.Monitoring
{
    public class ActiveWindowMonitoring : Events.AbstractMonitor
    {
        public override void EraseEvent()
        {
            Logger.Debug("[ActiveWindowMonitoring.Event_Refresh] Monitoring.");

            var activeProgramName = Tools.GetActiveWindowTitle();

            Logger.DebugFormat("Active window title is {0}", activeProgramName);

            if(activeProgramName == null) return;

            if (!activeProgramName.StartsWith("EVE - ")) return;

            var pilotName = activeProgramName.Replace("EVE - ", "") + "";

            Logger.DebugFormat("Pilot name is {0}", pilotName);

            if (Global.Pilots == null || Global.Pilots.Selected == null) return;

            Logger.DebugFormat("Selected pilot name is {0}", Global.Pilots.Selected.Name);

            if (pilotName == Global.Pilots.Selected.Name) return;

            Global.Pilots.Activate(pilotName);
        }

        public ActiveWindowMonitoring(ApplicationSettings settings) : base(settings)
        {

        }
    }
}
