namespace MyFirstStore
{
    internal class AbenStore
    {
        // Static fields
        public static string Winkelnaam = "Zonkya";

        // Arrays van alle producten en behorende info
        public static string[] ProductArray =
            {
            "Nike Air Force",
            "Nike Lunar Gato",
            "Nike Shirt",
            "Nike Trui",
            "Nike Jas"
            };
        public static int[] QuantityItems = { 20, 10, 8, 20, 15 };
        public static double[] PriceItems = { 199.99, 89.99, 28.99, 54.99, 149.99 };
        public static string[] DescriptionItems =
            {
            "Witte lage sneakers",
            "De Populairste zaalvoetbal schoenen op de markt",
            "Een simpele witte t-shirt met een nike logo",
            "Een zwarte hoodie met een nike logo",
            "Een zwarte winter jas met het nike logo op de rug"
            };
        public static string[] ExtraInfoItems =
            {
            "Fabriekant Nike",
            "Fabriekant Nike",
            "Fabriekant Nike",
            "Fabriekant Nike",
            "Fabriekant Nike"
            };

        public static bool IsAdmin = false; // Als je als admin inlogt wordt dit true

        // Array met reviews
        public static string[] Reviews =
            {
            "Beste site winkel ooit! – Sucre Olay",
            "Geweldige service en producten! – Jane Smith",
            "Ik ben zeer tevreden met mijn aankoop. – Bob Johnson",
            "Snelle levering en goede kwaliteit. – Maddie Digger",
            "Uitstekende klantenservice! – Worl Klarson",
            "Zeer gebruiksvriendelijke website. – Bacha Karchaoui",
            "Ik kom hier zeker terug! – Frank Milner",
            "De prijzen zijn zeer redelijk. – Uveve Uvavokasim",
            "Een geweldige winkelervaring. – Henry Bark",
            "Ik raad deze winkel aan iedereen aan. – Rico Lewis"
            };

        // Methode om een random review te tonen
        public static void ShowRandomReview()
        {
            Random random = new Random();
            int reviewIndex = random.Next(Reviews.Length);
            Console.WriteLine($"{Reviews[reviewIndex]}");
        }

        // Methode om alle beschikbare items te tonen
        public static void ShowAllItems()
        {
            Console.Clear();
            Console.WriteLine("Beschikbare items:");
            for (int i = 0; i < ProductArray.Length; i++)
            {
                if (QuantityItems[i] > 0)
                {
                    Console.WriteLine($"{i + 1}. {ProductArray[i]} - Voorraad: {QuantityItems[i]} - Prijs: {PriceItems[i]:F2} EUR");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {ProductArray[i]} - Voorraad: Uitverkocht - Prijs: {PriceItems[i]:F2} EUR");
                }
                Thread.Sleep(200);
            }
        }

        // Methode om een specifiek item te tonen
        public static void ShowItem(int itemIndex)
        {
            Console.Clear();
            if (itemIndex >= 0 && itemIndex < ProductArray.Length)
            {
                Console.WriteLine($"{ProductArray[itemIndex]}");
                Console.Write($"   Voorraad: ");
                if (QuantityItems[itemIndex] > 0)
                {
                    Console.WriteLine($"{QuantityItems[itemIndex]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uitverkocht");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"   Prijs: {PriceItems[itemIndex]:F2} EUR");
                Console.WriteLine($"   Beschrijving: {DescriptionItems[itemIndex]}");
                Console.WriteLine($"   Extra Info: {ExtraInfoItems[itemIndex]}");
            }
            else
            {
                Console.WriteLine("Ongeldig item geselecteerd.");
            }

            Console.WriteLine("\nDruk op Enter om terug te keren.");
            Console.ReadLine();
        }

        // Methode om een item te kopen
        public static void BuyItem(int itemIndex, int hoeveelheid)
        {
            Console.Clear();

            if (itemIndex >= 0 && itemIndex < ProductArray.Length)
            {
                if (QuantityItems[itemIndex] > 0)
                {
                    if (hoeveelheid <= QuantityItems[itemIndex])
                    {
                        // Berekening van totale prijs
                        QuantityItems[itemIndex] -= hoeveelheid;
                        double totaalPrijs = hoeveelheid * PriceItems[itemIndex];
                        double totaalPrijsMetBtw = totaalPrijs * 1.21;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Je hebt {hoeveelheid}x {ProductArray[itemIndex]} succesvol gekocht.");
                        Console.WriteLine($"Totaalprijs zonder BTW: {totaalPrijs:F2} EUR");
                        Console.WriteLine($"Totaalprijs met 21% BTW: {totaalPrijsMetBtw:F2} EUR");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        // Als er meer dan de voorraad wordt aangekocht, foutmelding
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fout: Je hebt meer items ingevoerd dan er op voorraad zijn.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    // Als er geen voorraad meer is, melding "uitverkocht"
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Uitverkocht!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
            }

            Console.WriteLine("\nDruk op Enter om terug te keren.");
            Console.ReadLine();
        }

        // Admin login
        public static void AdminLogin(string gebruikersnaam, string wachtwoord)
        {
            Console.Clear();
            string adminGebruikersnaam = "admin"; // Gebruikersnaam check
            string adminWachtwoord = "abc123"; // Hardcoded wachtwoord

            if (gebruikersnaam == adminGebruikersnaam && wachtwoord == adminWachtwoord)
            {
                IsAdmin = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("U bent succesvol ingelogd als admin!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Onjuiste gebruikersnaam of wachtwoord!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nDruk op Enter om terug te keren.");
            Console.ReadLine();
        }

        // Voorraad bijvullen (alleen voor admin)
        public static void RestockItem(int itemIndex, int extraVoorraad)
        {
            if (IsAdmin)
            {
                if (itemIndex >= 0 && itemIndex < ProductArray.Length)
                {
                    QuantityItems[itemIndex] += extraVoorraad;

                    // Bevestiging van nieuwe voorraad
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"De voorraad van {ProductArray[itemIndex]} is nu {QuantityItems[itemIndex]}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je hebt geen toegang tot deze functie!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\nDruk op Enter om terug te keren.");
            Console.ReadLine();
        }
    }
}
