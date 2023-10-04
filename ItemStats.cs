using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    internal class ItemStats
    {
        public Dictionary<string, Item> weapon = new Dictionary<string, Item>()
        {
            {"Kleinschwert",        new Item{Cost = 10, Damage = 5, Armor = 0, Slot = "One Arm"} },
            {"Zweihand Schwert",    new Item{Cost = 40, Damage = 20, Armor = 0, Slot = "Two Arm"} },

            {"Schild",              new Item{Cost = 10, Damage = 0, Armor = 10, Slot = "Secondary Arm"} }
        };

        public Dictionary<string, Item> armor = new Dictionary<string, Item>()
        {
            {"Helm",                new Item{Cost = 10, Damage = 0, Armor = 5, Slot = "Head"} },
            {"Leichte Rüstung",     new Item{Cost = 10, Damage = 0, Armor = 10, Slot = "Armor"} },
            {"Mittelere Rüstung",   new Item{Cost = 20, Damage = 0, Armor = 20, Slot = "Armor"} },
            {"Schwere Rüstung",     new Item{Cost = 40, Damage = 0, Armor = 40, Slot = "Armor"} }
        };
    }
}