using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    public static class QuickestWonGamesFinder
    {
        public static void FindQuickestWonGames(List<Game> games, int number = 1)
        {
            var wonGames = games
           .Where(game => (game.Result == "1-0" || game.Result == "0-1") && game.Moves_number > 1)
           .OrderBy(game => game.Moves_number)
           .Take(number) 
           .ToList();
            Console.WriteLine(wonGames.Count);


            int counter = 1;
            Console.WriteLine($"\nTop {number} legrövidebb győzelemmel végződött játszma:");
            foreach (var game in wonGames)
            {
                Console.WriteLine($"{counter}.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Világos: {game.White_name} (ELO: {game.White_elo})");
                Console.WriteLine($"Sötét: {game.Black_name} (ELO: {game.Black_elo})");
                Console.WriteLine($"Eredmény: {game.Result}");
                Console.WriteLine($"Megnyitás: {game.Opening}");
                Console.WriteLine($"Bajnokság: {game.Tournament}");
                Console.WriteLine($"Dátum: {game.Date:yyyy.MM.dd.}");
                Console.WriteLine($"Lépésszám: {game.Moves_number}");
                Console.WriteLine($"Lépések: {game.Moves}");
                Console.WriteLine("---------------------------------");
                counter++;
            }


        }


    }
}
