using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    public class MostCommonOpeningsFinder
    {
        public static void FindMostCommonOpeningsWithResults(List<Game> games, int number = 5)
        {
            
            var openings = games
                .GroupBy(game => game.Opening) 
                .Select(group => new
                {
                    Opening = group.Key,
                    Count = group.Count(),
                    Results = new
                    {
                        WhiteWins = group.Count(g => g.Result == "1-0"),
                        Draws = group.Count(g => g.Result == "1/2-1/2"),
                        BlackWins = group.Count(g => g.Result == "0-1")
                    }
                })
                .OrderByDescending(o => o.Count) 
                .Take(number) 
                .ToList();


            int counter = 1;
            Console.WriteLine($"\nTop {number} leggyakoribb megnyitás:");
            foreach (var opening in openings)
            {
                int totalGames = opening.Count;
                double whiteWinPercentage = (double)opening.Results.WhiteWins / totalGames * 100;
                double drawPercentage = (double)opening.Results.Draws / totalGames * 100;
                double blackWinPercentage = (double)opening.Results.BlackWins / totalGames * 100;
                Console.WriteLine($"{counter}.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Megnyitás: {opening.Opening}");
                Console.WriteLine($"Összes játszma: {totalGames}");
                Console.WriteLine($"Világos győzelem: {whiteWinPercentage:F2}%");
                Console.WriteLine($"Döntetlen: {drawPercentage:F2}%");
                Console.WriteLine($"Sötét győzelem: {blackWinPercentage:F2}%");
                counter++;
            }
        }
    }
}
