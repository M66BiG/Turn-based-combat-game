using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_combat_game
{
    public class ItemStats
    {
        public Dictionary<string, IItem> Stats = new Dictionary<string, IItem>()
        {
            {"Kleinschwert",        new IItem{Cost = 10, Damage = 5, Armor = 0, Slot = "One Arm"} },
            {"Zweihand Schwert",    new IItem{Cost = 40, Damage = 25, Armor = 0, Slot = "Two Arm"} },

            {"Einhand Schild",      new IItem{Cost = 10, Damage = 2, Armor = 10, Slot = "Secondary Arm"} },
       

        
            {"Leichter Helm",       new IItem{Cost = 10, Damage = 0, Armor = 5, Slot = "Head"} },
            {"Leichte Rüstung",     new IItem{Cost = 10, Damage = 0, Armor = 10, Slot = "Armor"} },
            {"Mittelere Rüstung",   new IItem{Cost = 20, Damage = 0, Armor = 20, Slot = "Armor"} },
            {"Schwere Rüstung",     new IItem{Cost = 40, Damage = 0, Armor = 40, Slot = "Armor"} }
        };
    }
}