using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EveJimaUniverse
{
    public class System
    {
        public string Id { get; set; }

        public string Name { get; set; }
         
        public string Class { get; set; }
         
        public string Static { get; set; }
         
        public string Static2 { get; set; }
         
        public string Sun { get; set; }
         
        public string Planets { get; set; }
         
        public string Moons { get; set; }
         
        public string Effect { get; set; }
         
        public string Region { get; set; }
         
        public string Constelation { get; set; }
         
        public SecurityStatus Security { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public DateTime Created { get; set; }

        public List<string> ConnectedSolarSystems = new List<string>();

        public Point LocationInMap { get; set; }

        public List<CosmicSignature> Signatures = new List<CosmicSignature>();

        public DateTime LastUpdate = DateTime.UtcNow;

        public string Type { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsHidden { get; set; }

        public void AddSignature(CosmicSignature signature)
        {
            var cosmicSignature = GetSignature(signature.Code);

            if (cosmicSignature == null)
            {
                // ---- Create new signature
                Signatures.Add(signature);
                return;
            }

            // ---- Update exist signature
            cosmicSignature.LastUpdate = signature.LastUpdate;
            cosmicSignature.Name = signature.Name;
            cosmicSignature.Type = signature.Type;

        }

        public CosmicSignature GetSignature(string code)
        {
            return Signatures.FirstOrDefault(cosmicSignature => cosmicSignature.Code == code);
        }
    }
}
