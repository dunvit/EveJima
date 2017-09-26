using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.BLL
{
    public delegate void DelegateActivate(PilotEntity pilot);
    public delegate void DelegateOnAddPilot(PilotEntity pilot);

    public class PilotsEntity : IEnumerable<PilotEntity>
    {
        private readonly object _lock = new object();
        private static readonly ILog Log = LogManager.GetLogger(typeof(PilotsEntity));
        readonly List<PilotEntity> _pilots = new List<PilotEntity>();

        public DelegateOnAddPilot OnAddPilot;
        public DelegateActivate OnActivatePilot;

        public string[] GetPilotsStorageContent()
        {
            lock (_lock)
            {
                if (File.Exists(@"Data/Pilots.csv") == false)
                {
                    File.Create(@"Data/Pilots.csv").Close(); 
                }

                var allLines = File.ReadAllLines(@"Data/Pilots.csv");

                return allLines;
            }
        }

        public PilotEntity Selected { get; private set; }

        public void SetSelected(PilotEntity pilot)
        {
            Selected = pilot;
            Log.DebugFormat("[PilotsEntity.SetSelected] Before  Global.Presenter.ActivatePilot : {0}", pilot.Name);
            
            Log.InfoFormat("[PilotsEntity.SetSelected] Before  Global.Presenter.ChangeActivePilot : {0}", pilot.Name);
            Global.Presenter.GlobalEventsChangeActivePilot(pilot.Name);
            Log.DebugFormat("[PilotsEntity.SetSelected] End : {0}", pilot.Name);
        }

        public void Add(PilotEntity pilot)
        {
            _pilots.Add(pilot);

            if (OnAddPilot != null)
            {
                OnAddPilot(pilot);
            }

            if(_pilots.Count == 1) SetSelected(pilot);

            Global.Presenter.AddPilotToMonitoringList(pilot);

            Global.Presenter.GlobalEventsActivatePilot(pilot.Name);
        }

        public void Activate(string pilotName)
        {
            foreach (var pilot in _pilots.Where(pilot => pilot.Name.Trim() == pilotName.Trim()))
            {
                Log.DebugFormat("[PilotsEntity.Activate] pilot.Name {0}", pilot.Name);
                Selected = pilot;
                Log.DebugFormat("[PilotsEntity.Activate] Before Global.Presenter.ActivatePilot. pilot.Name {0}", pilot.Name);
                Log.DebugFormat("[PilotsEntity.Activate] Before Global.Presenter.ChangeActivePilot. pilot.Name {0}", pilot.Name);
                Global.Presenter.GlobalEventsChangeActivePilot(pilot.Name);
                if (OnActivatePilot != null) OnActivatePilot(pilot);
            }
        }

        public bool IsExist(long pilotId)
        {
            return _pilots.Any(pilot => pilot.Id == pilotId);
        }

        #region Implementation of IEnumerable
        public IEnumerator<PilotEntity> GetEnumerator()
        {
            return _pilots.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
