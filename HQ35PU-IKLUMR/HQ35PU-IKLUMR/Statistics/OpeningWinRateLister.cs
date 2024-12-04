using System;
using System.Collections.Generic;
using System.Linq;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    internal class OpeningWinRateLister
    {
        public static void ShowOpeningWinRates(List<Game> games, string openingName = "Királycsel")
        {
            var totalGames = games.Count(g => g.Opening == openingName);

            var wonGames = games.Count(g =>
                (g.Opening == openingName && g.Result == "1-0")
            );

            var drawGames = games.Count(g =>
                (g.Opening == openingName && g.Result == "1/2-1/2")
            );

            var lostGames = games.Count(g =>
                (g.Opening == openingName && g.Result == "0-1")
            );

            if (totalGames > 0)
            {
                double winRate = (double)wonGames / totalGames * 100;
                double drawRate = (double)drawGames / totalGames * 100;
                double lossRate = (double)lostGames / totalGames * 100;

                Console.WriteLine($"{openingName} nyitás statisztikái:");
                Console.WriteLine($"Nyert partik: {wonGames} ({winRate:F2}%)");
                Console.WriteLine($"Döntetlen partik: {drawGames} ({drawRate:F2}%)");
                Console.WriteLine($"Vereségek: {lostGames} ({lossRate:F2}%)");
            }
            else
            {
                Console.WriteLine($"{openingName} nyitás nem szerepel a megadott játékok között.");
            }
        }
    }
}
