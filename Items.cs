using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    internal class Items
    {
        public Dictionary<string, int> weapons = new Dictionary<string, int>()
        {
            {"Kleinschwert", 10 },
            {"Großschwert", 20 }
        };

        public Dictionary<string, int> armor = new Dictionary<string, int>()
        {
            {"Helm", 10 },
            {"Leichte Rüstung", 10 },
            {"Mittelere Rüstung", 20 },
            {"Schwere Rüstung", 40 }
        };
    }
}
