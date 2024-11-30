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
                                                        "\n-stop (kilépés a programból)");

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Equals("-stop"))
                    {
                        break;
                    }


                    if (input.ToLower().Equals("-players"))
                    {
                        ListPlayers();
                    }

                    if (input.ToLower().StartsWith("-elo"))
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
                            ListElo(topCount);
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen paraméter. Használat: elo <szám>");
                        }
                    }
                }
            }
        }   
    }

    public static void ListPlayers()
    {
        List<string> players = new List<string>();

        for (int i = 0; i < games.Count; i++) 
        {
            if (!players.Contains(games[i].White_name))
            {
                players.Add(games[i].White_name);
            }
            if (!players.Contains(games[i].Black_name))
            {
                players.Add(games[i].Black_name);
            }
        }

        players.Sort();

        for (int i = 0; i < players.Count; i++) 
        { 
            Console.WriteLine(players[i]);
        }
    }

    public static void ListElo(int topCount)
    {
        var playersWithElo = games.SelectMany(game => new[]
        {
        new { Player = game.White_name, Elo = game.White_elo },
        new { Player = game.Black_name, Elo = game.Black_elo }
    })
        .GroupBy(player => player.Player)
        .Select(group => new
        {
            Player = group.Key,
            MaxElo = group.Max(player => player.Elo)  
        })
    .OrderByDescending(player => player.MaxElo)
        .ToList();

        var averageElo = playersWithElo.Average(player => player.MaxElo);
        Console.WriteLine($"Az összes játékos átlagos ELO pontja: {averageElo:F2}");

        Console.WriteLine($"\nTop {topCount} legmagasabb ELO-val rendelkező játékos:");
        foreach (var player in playersWithElo.Take(topCount))
        {
            Console.WriteLine($"{player.Player}: {player.MaxElo:F0}");
        }

        var topAvgElo = playersWithElo.Take(topCount).Average(player => player.MaxElo);
        Console.WriteLine($"\nA top {topCount} legmagasabb ELO-vel rendelkező játékos átlagos ELO pontszáma: {topAvgElo:F2}");
    }

}