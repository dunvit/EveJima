using System.Collections.Generic;

namespace EveJimaUniverse
{
    public class LinkedSystem
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public List<string> LinkedSystems = new List<string>();
    }
}
