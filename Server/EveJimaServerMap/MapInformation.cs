using System.Collections.Generic;

namespace EveJimaServerMap
{
    public class MapInformation
    {
        public string Key { get; set; }

        public string Owner { get; set; }

        public List<EveJimaUniverse.System> SystemsForSave { get; set; }
    }
}
