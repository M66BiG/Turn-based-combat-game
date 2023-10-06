using Turn_based_combat_game;

internal class Program
{

    //----------------
    // Main
    //----------------

    private static void Main(string[] args)
    {
        Human Spieler = new Human();
        Inventory SpielerInventar = new Inventory();

        ShowNavigation();

    }

    //----------------
    // Menü Navigation
    //----------------

    public static void ShowNavigation()
    {
        Console.WriteLine("Du befindest dich im Hauptmenü");
        Console.WriteLine("1: zum Haus");
        Console.WriteLine("2: zum Shop");
        Console.WriteLine("3: zum Inventar");

        Navigation(Convert.ToInt32(Console.ReadLine()));
    }

    //--------------------------------
    // Navigations Aktionen
    //--------------------------------

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


    //----------------
    // Shop anzeigen
    //----------------

    public static void ShowShopList(Dictionary<string, IItem> Stuff)
    {
        
        int counter = 1;
        Human Spieler = new Human();
        Console.WriteLine(Spieler.Gold); //Überprüfen weshalb Gold neu geschrieben wird.
        Dictionary<int, string> temp = new Dictionary<int, string>(); // Um Key zu storen mit der jeweilige zahl angabe um es später dem Inventar hinzuzufügen

        foreach (var item in Stuff)
        {
            
            Console.WriteLine($"{counter}: {item.Key}: \t Kosten: {item.Value.Cost} \t Schaden: {item.Value.Damage} \t Armor: {item.Value.Armor} \t Slot: {item.Value.Slot}");
            temp.Add(counter++, item.Key);
        }

        
        Console.WriteLine($"{counter}: Verlassen");


        // Hierunter wird gecheckt ob genug Gold vorhanden ist.


        int input = ShopAction(Convert.ToInt32(Console.ReadLine()), counter);

        if (input != 0)
        {
            if (Spieler.Gold >= Stuff[temp[input]].Cost )
            {
                Console.WriteLine("Du hast genug Gold");
                Spieler.Gold -= Stuff[temp[input]].Cost;
                Console.WriteLine(Spieler.Gold);
                ShowNavigation();
            }
        }

    }

    //----------------
    // Shop Verlassen?
    //----------------

    public static int ShopAction(int input, int counter)
    {
        if (input == counter)
        {
            ShowNavigation();
            return 0;
        }
        else
        {
            return input;
        }

    }


}