using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    internal class Human
    {
        public int Hp { get; set; } = 100;
        public int Armor { get; set; } = 0;
        public int Gold { get; set; } = 100;
        public bool HeadSlot { get; set; } = false;
        public bool ArmorSlot { get; set; } = false;
        public bool Hand1Slot { get; set; } = false;
        public bool Hand2Slot { get; set; } = false;
        public List<string> Inv { get; set; } = new List<string>(); //Doppelinitialisierung?
        public List<string> Equipt { get; set; } = new List<string>();

    }
}
