using System;

namespace EveJimaCore.BLL
{
    public class StarSystemEntity : ICloneable
    {
        public string Id { get; set; }
        public string System { get; set; }
        public string Class { get; set; }
        public string Static { get; set; }
        public string Static2 { get; set; }
        public string Sun { get; set; }
        public string Planets { get; set; }
        public string Moons { get; set; }
        public string Effect { get; set; }
        public string Region { get; set; }
        public string Constelation { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class WormholeEntity
    {
        public string Name { get; set; }
        public string LeadsTo { get; set; }
        public string TotalMass { get; set; }
        public string SingleMass { get; set; }
        public string Regen { get; set; }
        public string Classification { get; set; }
        public string Lifetime { get; set; }

    }

    public class BasicSolarSystem
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class BasicCosmicSignature
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
