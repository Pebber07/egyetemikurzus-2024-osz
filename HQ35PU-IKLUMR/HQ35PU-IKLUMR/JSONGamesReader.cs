using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PUIKLUMR
{
    internal class JSONGamesReader : IJSONGamesReader
    {
        

        public List<Game> Read(string jsonPath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonPath);

                var games = JsonSerializer.Deserialize<List<Game>>(jsonContent);

                if (games == null)
                    throw new InvalidOperationException("JSON feldolgozása sikertelen!");

                foreach (var game in games)
                {
                    game.Opening = ECOCodeService.GetOpeningName(game.Opening);
                }

                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
                return new List<Game>();
            }
        }
    }
    
}
