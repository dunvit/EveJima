using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EveJimaCore.BLL
{
    public class PilotsEntity : IEnumerable<PilotEntity>
    {
        readonly List<PilotEntity> _pilots = new List<PilotEntity>();

        public PilotEntity Selected { get; set; }

        public void Add(PilotEntity newPilot)
        {
            _pilots.Add(newPilot);
        }

        public void Activate(string pilotName)
        {
            foreach (var pilot in _pilots.Where(pilot => pilot.Name.Trim() == pilotName.Trim()))
            {
                Selected = pilot;
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
