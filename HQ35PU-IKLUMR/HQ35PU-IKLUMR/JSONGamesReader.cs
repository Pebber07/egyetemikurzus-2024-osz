using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PUIKLUMR
{
    internal class JSONGamesReader 
    {
        

        public List<Game> Read(string jsonPath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonPath);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
                };

                var games = JsonSerializer.Deserialize<List<Game>>(jsonContent, options);

                if (games == null)
                    throw new InvalidOperationException("JSON feldolgozása sikertelen!");

                

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
