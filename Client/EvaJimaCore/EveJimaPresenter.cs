using System;
using EvaJimaCore;
using EveJimaCore.BLL;

namespace EveJimaCore
{
    public class EveJimaPresenter
    {
        public event Action<string> OnEnterToSolarSystem;
        public event Action<string> OnActivatePilot;
        public event Action<string> OnChangeScreen;
        public event Action<string> OnRequestSolarSystemInformation;
        public event Action OnCloseApplication;

        public void AddPilotToMonitoringList(PilotEntity pilot)
        {
            pilot.OnEnterToSolarSystem += GlobalEventsEnterToSolarSystem;
        }

        public void GlobalEventsActivatePilot(string pilotName)
        {
            OnActivatePilot?.Invoke(pilotName);
        }

        private void GlobalEventsEnterToSolarSystem(string pilotname, string systemfrom, string systemto)
        {
            if(pilotname == Global.Pilots.Selected.Name)
            {
                OnEnterToSolarSystem?.Invoke(systemto);
            }
        }

        public void GlobalEventsChangeActivePilot(string pilotName)
        {
            OnEnterToSolarSystem?.Invoke(Global.Pilots.Selected.Location.Name);
        }

        public void ChangeScreen(string screen)
        {
            OnChangeScreen?.Invoke(screen);
        }

        public void RequestSolarSystemInformation(string systemName)
        {
            OnRequestSolarSystemInformation?.Invoke(systemName);
        }

        public void Close()
        {
            OnCloseApplication?.Invoke();
        }
    }
}
