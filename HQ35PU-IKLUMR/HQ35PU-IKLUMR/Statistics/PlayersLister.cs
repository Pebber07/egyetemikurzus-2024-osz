using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    internal class PlayersLister
    {
        public static void ListPlayers(List<Game> games)
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
    }
}
