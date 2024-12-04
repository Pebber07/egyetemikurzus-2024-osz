using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    internal class PlayerWinRateLister
    {
        public static void showPlayerWinRates(List<Game> games, string playerName = "Tapodi, Norman Lajos")
        {
            var totalGames = games.Count(g => g.White_name == playerName || g.Black_name == playerName);

            var wonGames = games.Count(g =>
                (g.White_name == playerName && g.Result == "1-0") ||
                (g.Black_name == playerName && g.Result == "0-1")
            );

            var drawGames = games.Count(g =>
                (g.White_name == playerName || g.Black_name == playerName) && g.Result == "1/2-1/2"
            );

            var lostGames = games.Count(g =>
                (g.White_name == playerName && g.Result == "0-1") ||
                (g.Black_name == playerName && g.Result == "1-0")
            );

            if (totalGames > 0)
            {
                double winRate = (double)wonGames / totalGames * 100;
                double drawRate = (double)drawGames / totalGames * 100;
                double lossRate = (double)lostGames / totalGames * 100;

                Console.WriteLine($"{playerName} statisztikái:");
                Console.WriteLine($"Nyert partik: {wonGames} ({winRate:F2}%)");
                Console.WriteLine($"Döntetlen partik: {drawGames} ({drawRate:F2}%)");
                Console.WriteLine($"Vereségek: {lostGames} ({lossRate:F2}%)");
            }
            else
            {
                Console.WriteLine($"{playerName} nem szerepelt a megadott játékok között.");
            }
        }
    }
}
