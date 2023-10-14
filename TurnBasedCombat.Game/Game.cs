namespace TurnBasedCombat.Game;

public class Game
{
    public void Start()
    {
        var spieler = new Human()
        {
            Name = "Spieler"
        };

        ShowNavigation(spieler);
    }

    public void ShowNavigation(Human spieler)
    {
        Console.WriteLine();
        Console.WriteLine("Du befindest dich im Hauptmenü");
        Console.WriteLine("1: zum Hotel");
        Console.WriteLine("2: zum Shop");
        Console.WriteLine("3: zum Inventar");
        Console.WriteLine("4: zu deinen Ausgerüsteten Gegenständen");
        Console.WriteLine("5: zum Kampf");

        string input = Console.ReadLine();
        Console.WriteLine();

        if(int.TryParse(input, out int result))
        {

        }
        else
        {
            Console.WriteLine("Unbekanntes Zeichen. Versuche es nocheinmal");
            Start();
        }

        Navigation(result, spieler);
    }

    //--------------------------------
    // Navigations Aktionen
    //--------------------------------

    public void Navigation(int Navigator, Human Spieler)
    {
        switch(Navigator)
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
            //case 4:
            //    ShowEquiptList(Spieler);
            //    break;
            case 5:
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

    public void ShowHome(Human Spieler)
    {
        Console.WriteLine("Du bist jetzt in einem Hotel. Möchtest du ein Zimmer buchen? Kostet 10 Gold die Nacht.");
        Console.WriteLine("Y/N");
        string answer = Console.ReadLine();

        if(answer.ToUpper() == "Y")
        {
            Spieler.Gold -= 10;
            Console.WriteLine($"Du hast nurnoch {Spieler.Gold}");
            if(Spieler.Hp <= 80 && Spieler.Hp != 0)
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
        else if(answer.ToUpper() != "N")
        {
            Console.WriteLine("Unbekannte Eingabe.");
        }
        Console.WriteLine("Kehre zum Hauptmenü.");
        ShowNavigation(Spieler);
    }
    //-------------------------------------------------------------------
    // Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop Shop 
    //-------------------------------------------------------------------

    public void ShowShopList(Human Spieler)
    {
        ItemStats itemStats = new ItemStats();
        int counter = 1;
        Console.WriteLine($"Du hast: {Spieler.Gold} Gold");
        Dictionary<int, string> temp = new Dictionary<int, string>(); // Um Key zu storen mit der jeweilige zahl angabe um es später dem Inventar hinzuzufügen

        foreach(var item in itemStats.Stats)
        {

            Console.WriteLine($"{counter}: {item.Key}: \t Kosten: {item.Value.Cost} \t Schaden: {item.Value.Damage} \t Armor: {item.Value.Armor} \t Slot: {item.Value.Slot}");
            temp.Add(counter++, item.Key);
        }
        Console.WriteLine($"{counter}: Verlassen");

        // Hierdrunter wird gecheckt ob genug Gold vorhanden ist.
        int input = ShopAction(Convert.ToInt32(Console.ReadLine()), counter, Spieler);

        if(input != 0)
        {   // itemStats(Klasse) .Stats (Dictionary) [temp (Dictionary mit string speicher) [input]] (Nummer (key)) .Cost (Kosten des Items)
            if(Spieler.Gold >= itemStats.Stats[temp[input]].Cost)
            {
                Console.WriteLine($"Du hast {Spieler.Gold} Gold.");
                Console.WriteLine("Möchtest du das Item Kaufen?");
                Console.WriteLine($"Es kostet {itemStats.Stats[temp[input]].Cost} Gold.");
                Console.WriteLine("Y/N");
                string answer = Console.ReadLine();
                if(answer.ToUpper() == "Y")
                {
                    Spieler.Gold -= itemStats.Stats[temp[input]].Cost;
                    //Spieler.Inv.Add(temp[input]);
                    Console.WriteLine("Du hast das Item erfolgreich gekauft.");
                    ShowNavigation(Spieler);
                }
                else if(answer.ToUpper() == "N")
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

    public int ShopAction(int input, int counter, Human Spieler)
    {
        if(input == counter)
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

    // #TODO: Introduce Inventory class and add it to player class

    public void ShowInventoryList(Human Spieler)
    {
        Console.WriteLine("Du schaust in dein Inventar.");
        bool equip = true; //Zum weitergeben für die Logik ob an oder ausgezogen wird

        if(Spieler.Inv.Count != 0)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            int counter = 1;

            foreach(var item in Spieler.Inv)
            {
                Console.WriteLine($"{counter}: {item}");
                //temp.Add(counter++, item);
            }

            Console.WriteLine("Möchtest du etwas anziehen?");
            Console.WriteLine("Y/N");
            string answer = Console.ReadLine();

            if(answer.ToUpper() == "Y")
            {
                Console.WriteLine("Welches Item?");
                int input = Convert.ToInt32(Console.ReadLine());
                //CheckSlotEquip(temp, input, equip, Spieler);
            }
            else if(answer.ToUpper() != "N")
            {
                Console.WriteLine("Unbekannte Eingabe.");
            }
        }
        else
        {
            Console.WriteLine("Du hast keine Items.");
        }
        Console.WriteLine("Kehre zurück zum Hauptmenü.");
        ShowNavigation(Spieler);
    }

    //-------------------------------------------------------------------
    // Ausrüstung Ausrüstung Ausrüstung Ausrüstung Ausrüstung Ausrüstung 
    //-------------------------------------------------------------------

    //public void ShowEquiptList(Human Spieler)
    //{
    //    bool equip = false; //Zum weitergeben für die Logik ob an oder ausgezogen wird
    //    if(Spieler.Equipt.Count != 0)
    //    {
    //        Dictionary<int, string> temp = new Dictionary<int, string>();
    //        int counter = 1;


    //        // zwischenspeicher um die Keys zu prüfen
    //        foreach(string item in Spieler.Equipt)
    //        {
    //            Console.WriteLine($"{counter}: {item}");
    //            temp.Add(counter++, item);
    //        }

    //        Console.WriteLine("Möchtest du etwas ausziehen?");
    //        Console.WriteLine("Y/N");
    //        string answer = Console.ReadLine();

    //        if(answer.ToUpper() == "Y")
    //        {
    //            Console.WriteLine("Welches Item?");
    //            int input = Convert.ToInt32(Console.ReadLine());
    //            //CheckSlotEquip(temp, input, equip, Spieler); // Um logic anzufragen
    //        }
    //        else if(answer.ToUpper() != "N")
    //        {
    //            Console.WriteLine("Unbekannte Eingabe.");
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Du hast keine Items ausgerüstet.");
    //    }
    //    Console.WriteLine("Kehre zurück zum Hauptmenü.");
    //    ShowNavigation(Spieler);
    //}

    //-------------------------------------------------------------------
    // Ausrüstung Logic Ausrüstung Logic Ausrüstung Logic Ausrüstung Logi
    //-------------------------------------------------------------------

    //#TODO:
    //public void CheckSlotEquip(Dictionary<int, string> temp, int input, bool equip, Human Spieler)
    //{
    //    ItemStats itemStats = new ItemStats(); // Laden der Itemstats
    //    if(equip)
    //    {
    //        if(itemStats.Stats[temp[input]].Slot == "One Arm" && Spieler.Hand1Slot == false)
    //        {
    //            Spieler.Hand1Slot = true;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Two Arm" && Spieler.Hand1Slot == false && Spieler.Hand2Slot == false)
    //        {
    //            Spieler.Hand1Slot = true;
    //            Spieler.Hand2Slot = true;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Secondary Arm" && Spieler.Hand2Slot == false)
    //        {
    //            Spieler.Hand2Slot = true;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Head" && Spieler.HeadSlot == false)
    //        {
    //            Spieler.HeadSlot = true;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Armor" && Spieler.ArmorSlot == false)
    //        {
    //            Spieler.ArmorSlot = true;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Deine Ausrüstungsslots sind Voll.");
    //            Console.WriteLine("Kehre zurück zum Hauptmenü.");
    //            ShowNavigation(Spieler);
    //        }
    //        Spieler.Equipt.Add(temp[input]);
    //        Spieler.Inv.Remove(temp[input]);
    //        Console.WriteLine($"Du hast das Item: {temp[input]} erfolgreich angezogen.");
    //        Console.WriteLine("Kehre zurück zum Hauptmenü.");
    //        ShowNavigation(Spieler);
    //    }
    //    else
    //    {
    //        if(itemStats.Stats[temp[input]].Slot == "One Arm" && Spieler.Hand1Slot == true)
    //        {
    //            Spieler.Hand1Slot = false;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Two Arm" && Spieler.Hand1Slot == true && Spieler.Hand2Slot == true)
    //        {
    //            Spieler.Hand1Slot = false;
    //            Spieler.Hand2Slot = false;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Secondary Arm" && Spieler.Hand2Slot == true)
    //        {
    //            Spieler.Hand2Slot = false;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Head" && Spieler.HeadSlot == true)
    //        {
    //            Spieler.HeadSlot = false;
    //        }
    //        else if(itemStats.Stats[temp[input]].Slot == "Armor" && Spieler.ArmorSlot == true)
    //        {
    //            Spieler.ArmorSlot = false;
    //        }
    //        else
    //        {
    //            Console.WriteLine("?!??!?!?!??!?!??");
    //            Console.WriteLine("Kehre zurück zum Hauptmenü.");
    //            ShowNavigation(Spieler);
    //        }
    //        Spieler.Equipt.Remove(temp[input]);
    //        Spieler.Inv.Add(temp[input]);
    //        Console.WriteLine($"Du hast das Item: {temp[input]} erfolgreich ausgezogen.");
    //        Console.WriteLine("Kehre zurück zum Hauptmenü.");
    //        ShowNavigation(Spieler);
    //    }
    //}


    //-------------------------------------------------------------------
    // Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight Fight 
    //-------------------------------------------------------------------

    public void ShowFight(Human Spieler)
    {
        Random random = new Random();
        Character NPC = new Character()
        { Name = "NPC" };

        string[] names = { "Beeck", "Meiderich", "Hamborn", "Marxloh", "Baerl" };

        NPC.Hp = random.Next(100, 121);
        NPC.Damage = random.Next(40, 56);
        NPC.Armor = random.Next(15, 26);
        NPC.Name = names[random.Next(names.Length)];


        Console.WriteLine($"Du kämpfst gegen ein starken Typen der sich {NPC.Name} nennt");

        Console.WriteLine("Ihr würfelt die Reihenfolge.");

        while(NPC.Hp >= 0 && Spieler.Hp >= 0)
        {
            Spieler.Dice = random.Next(2, 13);
            NPC.Dice = random.Next(2, 13);
            Console.WriteLine($"Du hast {Spieler.Hp} HP                     Dein Gegner hat {NPC.Hp} HP");

            Console.WriteLine();


            Console.WriteLine($"Du hast {Spieler.Dice} gewürfelt.           Dein Gegner hat {NPC.Dice} gewürfelt");

            Console.WriteLine();
            if(Spieler.Dice > NPC.Dice)
            {
                Console.WriteLine("Somit fängst du an.");
                Console.WriteLine();

                if(NPC.Armor >= Spieler.CalculateDamage())
                {
                    Console.WriteLine("Du konntest dem Gegner keinen Schaden hinzufügen. Er hat zu viel Rüstung");
                    Console.WriteLine();
                }
                else
                {
                    NPC.Hp -= Spieler.CalculateDamage() - NPC.Armor;
                    Console.WriteLine($"Du hast {Spieler.CalculateDamage()} HP Schaden hinzugefügt.");
                    Console.WriteLine($"Somit hat er nur noch {NPC.Hp} HP");
                }

                if(NPC.Hp <= 0)
                {
                    Console.WriteLine("Dein Gegner ist verstorben...");
                    break;
                }

                if(Spieler.Armor >= NPC.Damage)
                {
                    Console.WriteLine("Der Gegner konnte dir keinen Schaden hinzufügen. Du hast zu viel Rüstung");
                    Console.WriteLine();
                }
                else
                {
                    Spieler.Hp -= NPC.Damage - Spieler.Armor;
                    Console.WriteLine($"Der Gegner hat dir {NPC.Damage} HP Schaden hinzugefügt.");
                    Console.WriteLine($"Somit hast du nur noch {Spieler.Hp} HP");
                    Console.WriteLine();
                }

            }
            //------------------------------------------------------------------------------------
            else
            {
                Console.WriteLine("Somit fäng dein Gegner an.");
                if(Spieler.Armor >= NPC.Damage)
                {
                    Console.WriteLine("Der Gegner konnte dir keinen Schaden hinzufügen. Du hast zu viel Rüstung");
                    Console.WriteLine();
                }
                else
                {
                    Spieler.Hp -= NPC.Damage - Spieler.Armor;
                    Console.WriteLine($"Der Gegner hat dir {NPC.Damage} HP Schaden hinzugefügt.");
                    Console.WriteLine($"Somit hast du nur noch {Spieler.Hp} HP");
                    Console.WriteLine();
                }

                if(Spieler.Hp <= 0)
                {
                    Console.WriteLine("Du bist verstorben...");
                    break;
                }

                if(NPC.Armor >= Spieler.CalculateDamage())
                {
                    Console.WriteLine("Du konntest dem Gegner keinen Schaden hinzufügen. Er hat zu viel Rüstung");
                    Console.WriteLine();
                }
                else
                {
                    NPC.Hp -= Spieler.CalculateDamage() - NPC.Armor;
                    Console.WriteLine($"Du hast {Spieler.CalculateDamage()} HP Schaden hinzugefügt.");
                    Console.WriteLine($"Somit hat er nur noch {NPC.Hp} HP");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        if(Spieler.Hp <= 0)
        {
            Console.WriteLine("Du hast Verloren... Das Spiel ist hiermit zuende...");
            Console.WriteLine();
            Console.WriteLine($"Dein Gegner hatte nurnoch {NPC.Hp} HP");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Du hast GEWONNEN!!! Geh zurück zum Hauptmenü.");
            ShowNavigation(Spieler);
        }
    }
}
