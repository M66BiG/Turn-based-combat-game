namespace TurnBasedCombat.Shared.Entitites;

public class Human : Character
{
    private Item _headSlot = Item.None;
    public Item HeadSlot 
    {
        get => _headSlot;
        set
        {
            if (value is not null && value.Slot is Slot.HeadArmor)
            {
                _headSlot = value;
            }
        }
    }

    private Item _hand1Slot = Item.None;
    public Item Hand1Slot
    {
        get => _hand1Slot;
        set
        {
            if(value is not null && (value.Slot == Slot.OneHand || value.Slot == Slot.TwoHand))
            {
                _hand1Slot = value;
                // #TODO: Make _hand2Slot unusable if a TwoHand item is equipped
            }
        }
    }

    // #TODO:
    //public Item ArmorSlot { get; private set; } = Item.None;
    //public Item Hand2Slot { get; private set; } = Item.None;

    public int Gold { get; set; } = 100;

    public List<Item> Inv { get; set; } = new List<Item>();

    //TODO:
    public override int Armor { get => HeadSlot.Armor /* + ArmorSlot.Armor ....*/ ; }


    public int CalculateDamage()
        => _hand1Slot.Damage; //+ Hand2Slot.Damage;
}
