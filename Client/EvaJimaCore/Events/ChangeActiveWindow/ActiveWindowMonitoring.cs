using System.Timers;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.Monitoring
{
    public class ActiveWindowMonitoring : Events.AbstractMonitor
    {
        public override void EraseEvent()
        {
            _logger.Debug("[ActiveWindowMonitoring.Event_Refresh] Monitoring.");

            var activeProgramName = Tools.GetActiveWindowTitle();

            _logger.DebugFormat("Active window title is {0}", activeProgramName);

            if(activeProgramName == null) return;

            if (!activeProgramName.StartsWith("EVE - ")) return;

            var pilotName = activeProgramName.Replace("EVE - ", "") + "";

            _logger.DebugFormat("Pilot name is {0}", pilotName);

            if (Global.Pilots == null || Global.Pilots.Selected == null) return;

            _logger.DebugFormat("Selected pilot name is {0}", Global.Pilots.Selected.Name);

            if (pilotName == Global.Pilots.Selected.Name) return;

            Global.Pilots.Activate(pilotName);
        }
    }
}
