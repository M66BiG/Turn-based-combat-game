using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    internal class Human
    {
        public int hp { get; set; } = 100;
        public int armor { get; set; } = 0;
        public bool headSlot { get; set; } = false;
        public bool armorSlot { get; set; } = false;
        public bool hand1Slot { get; set; } = false;
        public bool hand2Slot { get; set; } = false;
    }
}
