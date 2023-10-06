using Turn_based_combat_game;

internal class Program
{

    private static void Main(string[] args)
    {
        
        ShowNavigation();

    }

    public static void ShowNavigation()
    {
        Console.WriteLine("Du befindest dich im Hauptmenü");
        Console.WriteLine("1: zum Haus");
        Console.WriteLine("2: zum Shop");
        Console.WriteLine("3: zum Inventar");

        Navigation(Convert.ToInt32(Console.ReadLine()));
    }
    public static void Navigation (int Navigator)
    {
        ItemStats itemStats = new ItemStats();
        switch (Navigator)
        {
            case 2:
                ShowShopList(itemStats.Stuff);
                break;



            default:
                ShowNavigation();
                break;
        }
    }

    public static void ShowShopList(Dictionary<string, Item> Stuff)
    {
        int counter = 1;

        Dictionary<int, object> temp = new Dictionary<int, object>();

        foreach (var item in Stuff)
        {
            
            Console.WriteLine($"{counter}: {item.Key}: \t Kosten: {item.Value.Cost} \t Schaden: {item.Value.Damage} \t Armor: {item.Value.Armor} \t Slot: {item.Value.Slot}");
            temp.Add(counter++, item);
        }

        
    }
    
}