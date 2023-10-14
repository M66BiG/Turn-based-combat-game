namespace TurnBasedCombat.Shared.Entitites;

public class Character
{
    public int Hp { get; set; } = 100;
    public virtual int Armor { get; set; } = 0;
    public int Damage { get; set; } = 0;
    public required string Name { get; set; }
    public int Dice { get; set; } = 0;
}
