using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    public class LongestGamesFinder
    {
        public static void FindLongestGames(List<Game> games, int number = 1)
        {
            
            var longestGames = games
                .OrderByDescending(game => game.Moves_number)
                .Take(number)
                .ToList();


            int counter = 1;
            Console.WriteLine($"\nTop {number} leghosszabb játszma:");
            foreach (var game in longestGames)
            {
                Console.WriteLine($"{counter}.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Világos: {game.White_name} (ELO: {game.White_elo})");
                Console.WriteLine($"Sötét: {game.Black_name} (ELO: {game.Black_elo})");
                Console.WriteLine($"Eredmény: {game.Result}");
                Console.WriteLine($"Megnyitás: {game.Opening}");
                Console.WriteLine($"Bajnokság: {game.Tournament}");
                Console.WriteLine($"Dátum: {game.Date:yyyy.MM.dd}");
                Console.WriteLine($"Lépésszám: {game.Moves_number}");
                Console.WriteLine($"Lépések: {game.Moves}");
                Console.WriteLine("---------------------------------");
                counter++;
            }
        }
    }
}
