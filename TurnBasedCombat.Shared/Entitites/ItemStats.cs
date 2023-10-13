namespace TurnBasedCombat.Shared.Entitites;

public class ItemStats
{
    public Dictionary<string, Item> Stats = new()
    {
        {"Kleinschwert",        new Item{Cost = 10, Damage = 5, Armor = 0, Slot = Slot.OneHand } },
        {"Zweihand Schwert",    new Item{Cost = 40, Damage = 25, Armor = 0, Slot = Slot.TwoHand } },

        {"Einhand Schild",      new Item{Cost = 10, Damage = 2, Armor = 10, Slot = Slot.OffHand } },

        {"Leichter Helm",       new Item{Cost = 10, Damage = 0, Armor = 5, Slot = Slot.HeadArmor } },

        {"Leichte Rüstung",     new Item{Cost = 10, Damage = 0, Armor = 10, Slot = Slot.BodyArmor } },
        {"Mittelere Rüstung",   new Item{Cost = 20, Damage = 0, Armor = 20, Slot = Slot.BodyArmor } },
        {"Schwere Rüstung",     new Item{Cost = 40, Damage = 0, Armor = 40, Slot = Slot.BodyArmor } }
    };
}
