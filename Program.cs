using Turn_based_combat_game;

internal class Program
{

    //----------------
    // Main
    //----------------

    private static void Main(string[] args)
    {
        Human Spieler = new Human();
        // Inventory SpielerInventar = new Inventory();
        ShowNavigation(Spieler);

    }

    //----------------
    // Menü Navigation
    //----------------

    public static void ShowNavigation(Human Spieler)
    {
        Console.WriteLine("Du befindest dich im Hauptmenü");
        Console.WriteLine("1: zum Haus");
        Console.WriteLine("2: zum Shop");
        Console.WriteLine("3: zum Inventar");

        Navigation(Convert.ToInt32(Console.ReadLine()),Spieler);
    }

    //--------------------------------
    // Navigations Aktionen
    //--------------------------------

    public static void Navigation (int Navigator, Human Spieler)
    {
        switch (Navigator)
        {
            case 2:
                ShowShopList(Spieler);
                break;



            default:
                ShowNavigation(Spieler);
                break;
        }
    }


    //----------------
    // Shop anzeigen
    //----------------

    public static void ShowShopList(Human Spieler)
    {
        ItemStats itemStats = new ItemStats();
        int counter = 1;
        Console.WriteLine(Spieler.Gold); 
        Dictionary<int, string> temp = new Dictionary<int, string>(); // Um Key zu storen mit der jeweilige zahl angabe um es später dem Inventar hinzuzufügen

        foreach (var item in itemStats.Stats)
        {
            
            Console.WriteLine($"{counter}: {item.Key}: \t Kosten: {item.Value.Cost} \t Schaden: {item.Value.Damage} \t Armor: {item.Value.Armor} \t Slot: {item.Value.Slot}");
            temp.Add(counter++, item.Key);
        }

        
        Console.WriteLine($"{counter}: Verlassen");


        // Hierunter wird gecheckt ob genug Gold vorhanden ist.


        int input = ShopAction(Convert.ToInt32(Console.ReadLine()), counter, Spieler);

        if (input != 0)
        {
            if (Spieler.Gold >= itemStats.Stats[temp[input]].Cost )
            {
                Console.WriteLine("Du hast genug Gold");
                Spieler.Gold -= itemStats.Stats[temp[input]].Cost;
                Console.WriteLine(Spieler.Gold);
                Spieler.Inv.Add(temp[input]);
                ShowNavigation(Spieler);
            }
            else 
            { 
                Console.WriteLine("Du hast nicht genug Gold!");
                ShowShopList(Spieler);
            }
        }
    }

    //----------------
    // Shop Verlassen?
    //----------------

    public static int ShopAction(int input, int counter, Human Spieler)
    {
        if (input == counter)
        {
            ShowNavigation(Spieler);
            return 0;
        }
        else
        {
            return input;
        }

    }


}