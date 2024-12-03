using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    public class AverageEloLister
    {
        public static void ListElo(List<Game> games, int topCount)
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
}
