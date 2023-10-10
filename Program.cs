using System.Diagnostics.Metrics;
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
        Console.WriteLine("1: zum Hotel");
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
    // Home Home Home Home Home Home Home Home Home Home Home Home Home 
    //-------------------------------------------------------------------

    public static void ShowHome(Human Spieler)
    {
        Console.WriteLine("Du bist jetzt in einem Hotel. Möchtest du ein Zimmer buchen? Kostet 10 Gold die Nacht.");
        Console.WriteLine("Y/N");

        string answer = Console.ReadLine();
        if (answer.ToUpper() == "Y")
        {
            Spieler.Gold -= 10;
            Console.WriteLine($"Du hast nurnoch {Spieler.Gold}");
            if (Spieler.Hp <= 80 && Spieler.Hp != 0)
            {
                Spieler.Hp += 20;
                Console.WriteLine("Du hast dich um 20 HP geheilt.");
                Console.WriteLine($"Du hast jetzt {Spieler.Hp} HP");
            }
            else
            {
                Console.WriteLine($"Du hast dich um {100 - Spieler.Hp} HP geheilt.");
                Spieler.Hp = Spieler.Hp + (100 - Spieler.Hp);
                Console.WriteLine($"Du hast jetzt {Spieler.Hp} HP");
            }



        }
        else if (answer.ToUpper() != "N")
        {
            Console.WriteLine("Unbekannte Eingabe.");
        }
        Console.WriteLine("Kehre zum Hauptmenü.");
        ShowNavigation(Spieler);
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


        // Hierdrunter wird gecheckt ob genug Gold vorhanden ist.


        int input = ShopAction(Convert.ToInt32(Console.ReadLine()), counter, Spieler);

        if (input != 0)
        {   // itemStats(Klasse) .Stats (Dictionary) [temp (Dictionary mit string speicher) [input]] (Nummer (key)) .Cost (Kosten des Items)
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
        Console.WriteLine("Du schaust in dein Inventar.");


        if (Spieler.Inv.Count != 0)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            int counter = 1;
            foreach (string item in Spieler.Inv)
            {
                Console.WriteLine($"{counter}: {item}");
                temp.Add(counter++, item);
            }
            Console.WriteLine("Möchtest du etwas anziehen?");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine("Welches Item?");
                int input = Convert.ToInt32(Console.ReadLine());
                Spieler.Equipt.Add(temp[input]);
                Spieler.Inv.Remove(temp[input]);

                Console.WriteLine($"Du hast {temp[input]} angezogen.");
            }
            else if (answer.ToUpper() == "N")
            {

            }
            else
            {

            }
        }
        else
        {
            Console.WriteLine("Du hast keine Items.");
            Console.WriteLine("Kehre zurück zum Hauptmenü.");


        }
        ShowNavigation(Spieler);
    }

    //-------------------------------------------------------------------
    // Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight 
    //-------------------------------------------------------------------

    public static void ShowFight(Human Spieler)
    {

    }

}