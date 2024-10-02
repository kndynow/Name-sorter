﻿namespace NameSorter;

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
        //TODO:Presentera meny
        do
        {
            DisplayMenu(["Visa namn osorterat",
            "Visa namn i bokstavsordning",
            "Sök",
            "Sortera namn i bokstavsordning",
            "Avsluta"]);

            int userInput = GetUserInput();

            switch (userInput)
            {
                //Visa namn osorterade
                case 1:
                Console.Clear();
                Console.WriteLine("Visa namn");
                Console.ReadLine();
                    break;
                //Visa namn i bokstavsordning
                case 2:
                Console.Clear();
                Console.WriteLine("Visa namn sorterat");
                Console.ReadLine();
                    break;
                //Sök
                case 3:
                Console.Clear();
                Console.WriteLine("Sök");
                Console.ReadLine();
                    break;
                //Sortera
                case 4:
                Console.Clear();
                Console.WriteLine("Sortera");
                Console.ReadLine();
                    break;
                //Avsluta
                case 5:
                Environment.Exit(0);
                    break;

                default:
                Console.Clear();
                    Console.WriteLine("Felaktig inmatning, försökt igen\nTryck Enter för att fortsätta...");
                    break;
            }

        } while (true);
        // //TODO:Formatera kod så den blir mer läsbar:
        // List<string> names = new List<string> { "Anna", "John", "Alice", "Björn", "Rakel", "Örjan", "Zeke", "Ahmed", "Hamse", "Linda", "Fehrvats", "Karin", };
        // //TODO:Implementera metod som presenterar namn osorterade
        // Console.WriteLine("Original list:");
        // foreach (var name in names)
        // {
        //     Console.WriteLine(name);
        // }
        // //TODO:Försök lösa så att Sort() sorterar efter svenska alfabetet.
        // names.Sort();
        // Console.WriteLine("\nSorted list:");
        // foreach (var name in names)
        // {
        //     Console.WriteLine(name);
        // }
        // //TODO:Implementera metod för sökning med felhantering så som felaktig inmatning eller om listan är tom.
        // Console.WriteLine("\nEnter name to search:");
        // //TODO:Här kommer jag implementera felhantering så att användaren inte kan mata in whitespace eller null
        // string searchName = Console.ReadLine();

        // if (names.Contains(searchName))
        // {
        //     Console.WriteLine($"{searchName} is in the list");
        // }
        // else
        // {
        //     Console.WriteLine($"{searchName} is not in the list.");
        // }
        // Console.ReadKey();


    }

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
}
