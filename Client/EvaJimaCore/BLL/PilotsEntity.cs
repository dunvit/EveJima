using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EvaJimaCore;
using log4net;

namespace EveJimaCore.BLL
{
    public delegate void DelegateActivate(PilotEntity pilot);
    public delegate void DelegateOnAddPilot(PilotEntity pilot);

    public class PilotsEntity : IEnumerable<PilotEntity>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PilotsEntity));
        readonly List<PilotEntity> _pilots = new List<PilotEntity>();

        public DelegateOnAddPilot OnAddPilot;
        public DelegateActivate OnActivatePilot;

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

            OnAddPilot?.Invoke(pilot);

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

                OnActivatePilot(pilot);
            }
        }

        public PilotEntity GetPilotInformation(string pilotName)
        {
            foreach (var pilot in _pilots.Where(pilot => pilot.Name.Trim() == pilotName.Trim()))
            {
                return pilot;
            }

            return null;
        }

        public bool IsExist(long pilotId)
        {
            return _pilots.Any(pilot => pilot.Id == pilotId);
        }

        public void Authorize(string code)
        {
            Log.DebugFormat("[PilotsEntity.Authorize] starting for token = {0}", code);

            try
            {
                var _currentPilot = new PilotEntity(code);

                Global.Metrics.PublishOnPilotInitialization(_currentPilot.Id);

                if (IsExist(_currentPilot.Id) == false)
                {

                    Global.ApplicationSettings.UpdatePilotInStorage(_currentPilot.Name, _currentPilot.Id.ToString(), _currentPilot.EsiData.RefreshToken, _currentPilot.Key);

                    Add(_currentPilot);

                    //cmbPilots.Visible = true;

                    SetSelected(_currentPilot);

                    //AddPilotToPilotsList(_currentPilot);

                    //Pilotes.Add(_currentPilot);
                }
                else
                {
                    // Update token
                    Global.ApplicationSettings.UpdatePilotInStorage(_currentPilot.Name, _currentPilot.Id.ToString(), _currentPilot.EsiData.RefreshToken, _currentPilot.Key);
                }

                //cmbPilots.Visible = true;

                SetSelected(_currentPilot);


            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[PilotsEntity.Authorize] Critical error. Exception {0}", ex);
            }
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
