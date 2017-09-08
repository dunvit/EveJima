using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveJimaCore.BLL.Navigator
{
    public class Path
    {
        public string Name { get; set; }

        public int Jumps { get; set; }

        public string Note { get; set; }

        public int Pilotes { get; set; }

        public string SystemName { get; set; }

        public string ShipKills { get; set; }

        public string NpcKills { get; set; }

        public string PodKills { get; set; }

    }
}
