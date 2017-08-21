using System;

namespace EveJimaUniverse
{
    public class CosmicSignature
    {
        public SignatureType Type { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string SolarSystemName { get; set; }

        public DateTime LastUpdate = DateTime.UtcNow;
    }
}
