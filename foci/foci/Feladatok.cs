using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foci
{
    internal class Feladatok
    {

        static void Main()
        {
            //1
            string[] matches = File.ReadAllLines("meccs.txt");

        }
            //2
        static void DisplayMatchesByRound(string[] matches, int round)
        {
            Console.WriteLine($"Matches in round {round}:");
            foreach (var match in matches)
            {
                if (match.StartsWith($"{round}."))
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}