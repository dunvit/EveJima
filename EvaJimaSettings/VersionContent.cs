using System.Collections.Generic;

namespace EveJimaSettings
{
    public class VersionContent
    {
        public List<VersionFile> Files { get; set; }

        public VersionContent()
        {
            Files = new List<VersionFile>();
        }
    }
}
