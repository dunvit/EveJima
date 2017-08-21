using System;
using EvaJimaCore;

namespace EveJimaCore
{
    public class EveJimaPresenter
    {
        public event Action<BLL.Map.Map> OnLocationChange;
        public event Action<BLL.Map.Map> OnChangeActivePilot;
        public event Action<string> OnActivatePilot;
        public event Action<string> OnChangeScreen;

        public void GlobalEventsActivatePilot(string pilotName)
        {
            if(pilotName == Global.Pilots.Selected.Name)
            {
                OnLocationChange?.Invoke(Global.Pilots.Selected.SpaceMap);
            }

            OnActivatePilot?.Invoke(pilotName);
        }

        public void GlobalEventsChangeActivePilot(string pilotName)
        {
            OnChangeActivePilot?.Invoke(Global.Pilots.Selected.SpaceMap);
        }

        public void GlobalEventsSelectSolarSystem(string solarSystemName)
        {
            Global.Pilots.Selected.SpaceMap.SelectedSolarSystemName = solarSystemName;
        }

        public void ChangeScreen(string screen)
        {
            OnChangeScreen?.Invoke(screen);
        }
    }
}
