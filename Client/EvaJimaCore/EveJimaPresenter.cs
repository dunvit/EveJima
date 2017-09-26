using System;
using EvaJimaCore;
using EveJimaCore.BLL;

namespace EveJimaCore
{
    public class EveJimaPresenter
    {
        public event Action<BLL.Map.Map> OnLocationChange;
        public event Action<string> OnEnterToSolarSystem;
        public event Action<BLL.Map.Map> OnChangeActivePilot;
        public event Action<string> OnActivatePilot;
        public event Action<string> OnChangeScreen;
        public event Action OnCloseApplication;

        public void AddPilotToMonitoringList(PilotEntity pilot)
        {
            pilot.OnEnterToSolarSystem += GlobalEventsEnterToSolarSystem;
        }

        public void GlobalEventsActivatePilot(string pilotName)
        {
            if(pilotName == Global.Pilots.Selected.Name)
            {
                
                OnLocationChange?.Invoke(Global.Pilots.Selected.SpaceMap);
                OnEnterToSolarSystem?.Invoke(Global.Pilots.Selected.SpaceMap.LocationSolarSystemName);
            }

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
            OnChangeActivePilot?.Invoke(Global.Pilots.Selected.SpaceMap);

            OnLocationChange?.Invoke(Global.Pilots.Selected.SpaceMap);
            OnEnterToSolarSystem?.Invoke(Global.Pilots.Selected.SpaceMap.LocationSolarSystemName);
        }

        public void GlobalEventsSelectSolarSystem(string solarSystemName)
        {
            Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName = solarSystemName;
        }

        public void ChangeScreen(string screen)
        {
            OnChangeScreen?.Invoke(screen);
        }

        public void Close()
        {
            OnCloseApplication?.Invoke();
        }
    }
}
