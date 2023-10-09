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
        Console.WriteLine("4: zum Kampf");

        Navigation(Convert.ToInt32(Console.ReadLine()),Spieler);
    }

    //--------------------------------
    // Navigations Aktionen
    //--------------------------------

    public static void Navigation (int Navigator, Human Spieler)
    {
        switch (Navigator)
        {
            case 1:
                ShowHome(Spieler);
                break;
            case 2:
                ShowShopList(Spieler);
                break;
            case 3:
                ShowInventoryList(Spieler);
                break;
            case 4:
                ShowFight(Spieler);
                break;



            default:
                ShowNavigation(Spieler);
                break;
        }
    }


    //-------------------------------------------------------------------
    // Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop 
    //-------------------------------------------------------------------

    public static void ShowShopList(Human Spieler)
    {
        ItemStats itemStats = new ItemStats();
        int counter = 1;
        Console.WriteLine($"Du hast: {Spieler.Gold} Gold"); 
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
        {   // itemStats(Klasse) .Stats (Dictionary) [temp (Dictionary mit string speicher) [input]] (Nummer) .Cost (Kosten des Items)
            if (Spieler.Gold >= itemStats.Stats[temp[input]].Cost ) 
            {
                Console.WriteLine($"Du hast {Spieler.Gold} Gold.");
                Console.WriteLine("Möchtest du das Item Kaufen?");
                Console.WriteLine($"Es kostet {itemStats.Stats[temp[input]].Cost} Gold.");
                Console.WriteLine("Y/N");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "Y")
                {
                    Spieler.Gold -= itemStats.Stats[temp[input]].Cost;
                    Spieler.Inv.Add(temp[input]);
                    Console.WriteLine("Du hast das Item erfolgreich gekauft.");
                    ShowNavigation(Spieler);
                }
                else if (answer.ToUpper() == "N")
                {
                    Console.WriteLine("Kehre zurück zum Shop.");
                    ShowShopList(Spieler);
                }
                else
                {
                    Console.WriteLine("Unbekannte Eingabe.");
                    Console.WriteLine("Kehre zurück zum Shop.");
                    ShowShopList(Spieler);
                }

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

    //-------------------------------------------------------------------
    // Inventar Inventar Inventar Inventar Inventar Inventar Inventar Inv
    //-------------------------------------------------------------------
    public static void ShowInventoryList(Human Spieler)
    {

    }


    //-------------------------------------------------------------------
    // Home Home Home Home Home Home Home Home Home Home Home Home Home 
    //-------------------------------------------------------------------
    public static void ShowHome(Human Spieler)
    {

    }


    //-------------------------------------------------------------------
    // Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight 
    //-------------------------------------------------------------------

    public static void ShowFight(Human Spieler)
    {

    }

}