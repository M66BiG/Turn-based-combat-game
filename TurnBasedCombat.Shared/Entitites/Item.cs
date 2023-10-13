namespace TurnBasedCombat.Shared.Entitites;

public class Item
{
    public static Item None => new(); 

    public int Cost { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public Slot Slot { get; set; }
}
