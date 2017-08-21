using System;

namespace EveJimaServerMap
{
    public class PilotLocation
    {
        public string Name { get; set; }

        public string System { get; set; }

        public string MapKey { get; set; }

        public DateTime LastUpdate = DateTime.UtcNow;
    }
}
