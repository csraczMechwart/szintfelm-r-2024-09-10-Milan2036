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
        //3
        static void DisplayTurnaroundTeams(string[] matches)
        {
            Console.WriteLine("Teams that turned the game around:");
            foreach (var match in matches)
            {
                string[] parts = match.Split(' ');
                string[] score = parts[1].Split('-');
                string[] halftimeScore = parts[2].Trim('(', ')').Split('-');

                if (int.Parse(halftimeScore[0]) < int.Parse(halftimeScore[1]) &&
                    int.Parse(score[0]) > int.Parse(score[1]))
                {
                    Console.WriteLine(parts[0]);
                }
            }
        }
    }
}