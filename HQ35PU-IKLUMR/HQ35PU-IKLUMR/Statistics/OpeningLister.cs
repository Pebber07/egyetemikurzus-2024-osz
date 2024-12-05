using System;
using System.Collections.Generic;
using System.Linq;

using HQ35PUIKLUMR.Model;

namespace HQ35PU_IKLUMR.Statistics
{
    internal class OpeningsLister
    {
        public static void ListOpenings(List<Game> games)
        {
            List<string> openings = new List<string>();

            for (int i = 0; i < games.Count; i++)
            {
                if (!openings.Contains(games[i].Opening))
                {
                    openings.Add(games[i].Opening);
                }
            }

            openings.Sort();

            if (openings.Count > 0)
            {
                Console.WriteLine("Lehets�ges nyit�sok:");
                foreach (var opening in openings)
                {
                    Console.WriteLine(opening);
                }
            }
            else
            {
                Console.WriteLine("Nincsenek el�rhet� nyit�sok.");
            }
        }
    }
}