using HQ35PU_IKLUMR.Statistics;

using HQ35PUIKLUMR;
using HQ35PUIKLUMR.Model;

internal class Program
{
    public static List<Game> games = new List<Game>();
    private static JSONGamesReader reader = new JSONGamesReader();
    private static void Main(string[] args)
    {

        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string fullPath = Path.Combine(projectRoot, "Data", "games.json");
        games = reader.Read(fullPath);

        Console.WriteLine("Üdvözöllek a sakk statisztikai programunkban!");
        Console.WriteLine("Kérlek nyomj Enter billentyűt a folytatáshoz.");

        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            Console.WriteLine("A programban a '-kulcsszó' kapcsoló segítségével tudod majd koordinálni magad.");
            Console.WriteLine("A lehetséges parancsok: \n-players (játékosok kilistázása)" +
                                                       "\n-elo <szám> (átlag elő és top <szám> játékos elője és átlagok)" +
                                                        "\n-exit (kilépés a programból)" +
                                                        "\n-quickestwongames <szám> (Kiírja a <szám> darab legrövidebb eldőlt játszmát)");

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Equals("-exit"))
                    {
                        break;
                    }


                    else if (input.ToLower().Equals("-players"))
                    {
                        PlayersLister.ListPlayers(games);
                    }

                    else if (input.ToLower().StartsWith("-elo"))
                    {
                        var parts = input.Split(' ');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int topCount))
                        {
                            if (topCount <= 0)
                            {
                                Console.WriteLine("Érvénytelen paraméter. A szám nagyobb, mint 0.");
                            }
                            if (topCount > 100)
                            {
                                Console.WriteLine("Érvénytelen paraméter. A szám legfeljebb 100 lehet");
                            }
                            AverageEloLister.ListElo(games, topCount);
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen paraméter. Használat: elo <szám>");
                        }
                    }

                    else if (input.ToLower().StartsWith("-quickestwongames"))
                    {
                        var parts = input.Split(' ');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int number))
                        {
                            if (number <= 0)
                            {
                                Console.WriteLine("Érvénytelen paraméter. A szám nagyobb, mint 0.");
                            }
                            if (number > 100)
                            {
                                Console.WriteLine("Érvénytelen paraméter. A szám legfeljebb 100 lehet");
                            }
                            QuickestWonGamesFinder.FindQuickestWonGames(games, number);
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen paraméter. Használat: -quickestwongames <szám>");
                        }

                    }
                    else if (!input.StartsWith('-'))
                    {
                        Console.WriteLine($"Próbáld meg \"-{input}\" alakban");
                    }
                    else { 
                        Console.WriteLine($"Az \"{input}\" nem felismerhető parancs.");
                    }
                }
            }
        }
    }

}