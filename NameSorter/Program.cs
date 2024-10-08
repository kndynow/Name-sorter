﻿using System.Globalization;

namespace NameSorter;

class Program
{
    /* Analys:
    Först av allt kommer jag strukturera koden genom att skapa separata metoder för de olika delarna av programmet samt att formatera koden lite annorlunda för att göra den mer läsbar.
    Jag kommer skapa separata metoder för att skriva ut namnen som dom är lagrade i listan och skriva ut namnen i bokstavsordning, en metod för att sortera namnen i bokstavsordning och en metod för sökning.
    För att förbättra användargränssnittet kommer jag implimentera en metod för att visa en meny för användaren som med hjälp av en do-while-loop och en switch-sats
    så användaren kan välja vad vad de vill göra samt att den kan välja att söka efter ytterligare ett namn om inte den första sökningen gav resultat.

    När jag kört programmet har jag upptäckt att efter sort så hamnar namnet Örjan inte sist utan det gör Zeke vilket jag tror beror på att Sort() sorterar efter engelska alfabetet.
    Jag märkte också att användaren kan mata in mellanslag eller null vilket kan få programmet att krascha.
    */
    static void Main(string[] args)
    {
        //Lagrar namn i en HashSet som lagrar data på samma vis som Dictionary fast
        //utan att vi behöver använda oss av en nyckel för att komma åt värden.
        HashSet<string> names = new HashSet<string>{
            "Anna", "John", "Alice", "Björn", "Rakel", "Örjan", "Zeke",
            "Ahmed", "Hamse", "Linda", "Fehrvats", "Karin",
        };

        //Main loop
        do
        {
            DisplayMenu(["Visa namn osorterat",
            "Visa namn i bokstavsordning", "Sök", "Avsluta"]);

            int userInput = GetUserInput();

            switch (userInput)
            {
                //Visa namn osorterade
                case 1:
                    Console.Clear();
                    Console.WriteLine("Namn i lista, osorterade.\n");
                    DisplayNames(names);
                    break;
                //Visa namn i bokstavsordning
                case 2:
                    Console.Clear();
                    Console.WriteLine("Namn i bokstavsordning.");
                    DisplayNames(SortNames(names));
                    break;
                //Sök
                case 3:
                    Console.Clear();
                    SearchName(names);
                    break;
                //Avsluta
                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning, försökt igen\nTryck Enter för att fortsätta...");
                    break;
            }

        } while (true);
    }

    //Visar menyval
    public static void DisplayMenu(string[] menuItems)
    {
        Console.Clear();
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{(i) + 1} - {menuItems[i]}");
        }
    }

    //Kontrollerar att användaren matar in ett numreriskt värde
    public static int GetUserInput()
    {
        if (!int.TryParse(Console.ReadLine(), out int input))
        {
            Console.WriteLine("Ogiltig inmatning. Försök igen");
        }
        return input;
    }


    //Presenterar listans innehåll osorterad
    public static void DisplayNames(HashSet<string> list)
    {
        //Kontrollera så att listan inte är tom
        if (list.Count != 0)
        {
            foreach (string name in list)
            {
                Console.WriteLine(name);

            }
            Console.ReadLine();
            Console.WriteLine("Tryck Enter för att fortsätta...");
        }
        Console.WriteLine("Listan verkar vara tom.");
    }

        public static void DisplayNames(List<string> list)
    {
        //Kontrollera så att listan inte är tom
        if (list.Count != 0)
        {
            foreach (string name in list)
            {
                Console.WriteLine(name);

            }
            Console.ReadLine();
            Console.WriteLine("Tryck Enter för att fortsätta...");
        }
        Console.WriteLine("Listan verkar vara tom.");
    }

    /*
    SortNames tar emot ett HashSet, passerar in dess element i en ny instans av List som sen kan sortera
    namn efter bokstavsordning efter det svenska alfabetet genom metoden StringComparer.Create som jämför
    listan efter CultureInfo som anges. Returnerar en sorterad lista*/
    public static List<string> SortNames(HashSet<string> names)
    {
        List<string>nameList = new List<string>(names);
        nameList.Sort(StringComparer.Create(new CultureInfo("sv-SV"), false));
        return nameList;
    }

    //Sök namn 
    public static void SearchName(HashSet<string> nameList)
    {

        Console.WriteLine("\nSkriv in namnet du söker: ");

        string searchName = Console.ReadLine();
        //Kontrollerar att inmating inte är tom eller är mellanslag
        if (string.IsNullOrWhiteSpace(searchName))
        {
            Console.WriteLine("Sökfältet får inte vara tomt eller innehålla mellanslag.");
        }
        else if (nameList.Contains(searchName))
        {
            Console.WriteLine($"{searchName} finns i listan.");
        }
        else
        {
            Console.WriteLine($"{searchName} finns inte i listan.");
        }
        Console.ReadKey();
    }
}
