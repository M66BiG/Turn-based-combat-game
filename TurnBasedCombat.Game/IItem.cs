using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    public class IItem
    {
        public int Cost {  get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public string Slot { get; set; }
    }
}
