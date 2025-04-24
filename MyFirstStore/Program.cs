namespace MyFirstStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true; // Het programma blijft runnen totdat de gebruiker stopt

            

            // Hoofdprogramma-loop
            while (programRunning)
            {
                
                ShowMenu();

                int keuzenMenu = Convert.ToInt32(Console.ReadLine());

                switch (keuzenMenu)
                {
                    case 1:
                        AbenStore.ShowAllItems();
                        Console.Write($"\nKies een item om in details te bekijken: ");
                        int itemBekijken = Convert.ToInt32(Console.ReadLine()) - 1;
                        AbenStore.ShowItem(itemBekijken);
                        break;

                    case 2:
                        AbenStore.ShowAllItems();
                        Console.WriteLine("Welk item wilt u kopen? (1-5)");
                        int itemKopen = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine($"Hoeveel wilt u kopen van {AbenStore.ProductArray[itemKopen]}?");
                        int hoeveelheid = Convert.ToInt32(Console.ReadLine());
                        AbenStore.BuyItem(itemKopen, hoeveelheid);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Voer uw gebruikersnaam in:");
                        string gebruikersnaam = Console.ReadLine();
                        Console.WriteLine("Voer uw wachtwoord in:");
                        string wachtwoord = Console.ReadLine();
                        AbenStore.AdminLogin(gebruikersnaam, wachtwoord);
                        break;

                    case 4:
                        ExitProgram();
                        programRunning = false;
                        break;

                    case 5:
                        Console.Clear();
                        // Admin optie voor bijvullen
                        if (AbenStore.IsAdmin)
                        {
                            AbenStore.ShowAllItems();
                            Console.WriteLine();
                            Console.WriteLine("Welk item wilt u bijvullen? (1-5)");
                            int itemBijvullen = Convert.ToInt32(Console.ReadLine()) - 1;
                            Console.WriteLine($"Hoeveel wilt u toevoegen aan {AbenStore.ProductArray[itemBijvullen]}?");
                            int extraVoorraad = Convert.ToInt32(Console.ReadLine());
                            AbenStore.RestockItem(itemBijvullen, extraVoorraad);
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                        }
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                        break;
                }
            }
        }

        //Methode voor logo

        static void PrintLogo()
        {
            // 2D-array die het logo voorstelt
            string[,] logo = new string[,]
        {
            { " ", " ", "_", "_", "_", " ", " ", " "," ", "-", "-", "-", "\\", " " },
            { " ", "/", " ", " ", " ", "\\", " ", " "," ", "|", " ", " ", "|", " " },
            { "|", " ", " ", " ", " ", " ", "|", " "," ", "|", "_", "_", "|", " " },
            { "|", "_", "_", "_", "_", "_", "|", " "," ", "|", " ", " ", " ", "|" },
            { "|", " ", " ", " ", " ", " ", "|", " "," ", "|", " ", " ", " ", "|" },
            { "|", " ", " ", " ", " ", " ", "|", " "," ", "|", "_", "_", "_", "|" }
        };

            // Geneste for-lus om het logo af te drukken
            for (int i = 0; i < logo.GetLength(0); i++) // Door rijen itereren
            {
                for (int j = 0; j < logo.GetLength(1); j++) // Door kolommen itereren
                {
                    Console.Write(logo[i, j]); // Print elk element
                }
                Console.WriteLine(); // Ga naar de volgende regel
            }
        }



        // Methode om het menu te tonen
        static void ShowMenu()
        {
            Console.Clear();
            //logo print maar 1x
            if (!logoPrinted)
            {
                PrintLogo();
                Console.WriteLine();
                logoPrinted = true;
            }
            
            Console.WriteLine($"Welkom in {AbenStore.Winkelnaam}!");
            Console.WriteLine("\nMaak een keuze:");
            Console.WriteLine("1. Items bekijken");
            Console.WriteLine("2. Items kopen");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Inloggen als admin");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("4. Stoppen");

            if (AbenStore.IsAdmin)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("5. Bijvullen (Admin)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

            ShowReviews();
            Console.WriteLine();
            Console.Write("Keuze: ");
        }

        private static bool logoPrinted = false;

        // Methode om reviews te tonen
        static void ShowReviews()
        {
            Console.WriteLine("Review:");
            AbenStore.ShowRandomReview();
        }

        // Methode voor afsluiten van het programma
        static void ExitProgram()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Bedankt voor uw bezoek aan Zonkya! Yoo!");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
