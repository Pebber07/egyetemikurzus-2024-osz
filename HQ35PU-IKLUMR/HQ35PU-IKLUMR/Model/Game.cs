using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ35PUIKLUMR.Model
{
    internal class Game
    {
        public string White_name { get; set; }
        public string Black_name { get; set; }
        public int White_elo { get; set; }
        public int Black_elo { get; set; }
        public string Result { get; set; }
        public string Opening { get; set; }
        public string Tournament { get; set; }
        public DateTime Date { get; set; }
        public string Moves { get; set; }
        public int Moves_number { get; set; }

    }
}
