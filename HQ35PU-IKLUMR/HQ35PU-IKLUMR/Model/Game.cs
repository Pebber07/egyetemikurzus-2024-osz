using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ35PUIKLUMR.Model
{
    public class Game
    {
        public string White_name { get; }
        public string Black_name { get;}
        public int White_elo { get; }
        public int Black_elo { get; }
        public string Result { get; }
        public string Opening { get; }
        public string Tournament { get; }
        public DateTime Date { get; }
        public string Moves { get; }
        public int Moves_number { get;}

        public Game(string white_name, string black_name, int white_elo, int black_elo, string result, string opening, string tournament, DateTime date, string moves, int moves_number)
        {
            White_name = white_name;
            Black_name = black_name;
            White_elo = white_elo;
            Black_elo = black_elo;
            Result = result;
            Opening = ECOCodeService.GetOpeningName(opening);
            Tournament = tournament;
            Date = date;
            Moves = moves;
            Moves_number = moves_number;
        }
    }

    
}
