using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EveJimaCore.BLL
{
    public class PilotsEntity : IEnumerable<PilotEntity>
    {
        private Object _lock = new Object();

        readonly List<PilotEntity> _pilots = new List<PilotEntity>();

        public string[] GetPilotsStorageContent()
        {
            lock (_lock)
            {
                if (File.Exists(@"Data/Pilots.csv") == false)
                {
                    File.Create(@"Data/Pilots.csv").Close(); ;
                }

                var allLines = File.ReadAllLines(@"Data/Pilots.csv");

                return allLines;
            }
        }

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
