using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    public class BestWinRateOpenings
    {
        public static void FindBestWinRateOpenings(List<Game> games, string playerColor, int number = 1)
        {
           
            var openings = games
                .GroupBy(game => game.Opening)
                .Select(group => new
                {
                    Opening = group.Key,
                    TotalGames = group.Count(),
                    WhiteWins = group.Count(g => g.Result == "1-0"),
                    Draws = group.Count(g => g.Result == "1/2-1/2"),
                    BlackWins = group.Count(g => g.Result == "0-1"),
                    WinRateForColor = (double)group.Count(g =>
                        (playerColor.ToLower() == "white" && g.Result == "1-0") ||
                        (playerColor.ToLower() == "black" && g.Result == "0-1")) / group.Count() * 100
                })
                .Where(o => o.TotalGames > 0)
                .OrderByDescending(o => o.WinRateForColor)
                .Take(number) 
                .ToList();


            int counter = 1;
            Console.WriteLine($"\nTop {number} megnyitások a legjobb nyerési aránnyal ({playerColor}):");
            foreach (var opening in openings)
            {
                Console.WriteLine($"{counter}.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Megnyitás: {opening.Opening}");
                Console.WriteLine($"Összes játszma: {opening.TotalGames}");
                Console.WriteLine($"Világos győzelem: {opening.WhiteWins} ({(double)opening.WhiteWins / opening.TotalGames * 100:F2}%)");
                Console.WriteLine($"Döntetlen: {opening.Draws} ({(double)opening.Draws / opening.TotalGames * 100:F2}%)");
                Console.WriteLine($"Sötét győzelem: {opening.BlackWins} ({(double)opening.BlackWins / opening.TotalGames * 100:F2}%)");
                counter++;
            }
        }
    }
}
