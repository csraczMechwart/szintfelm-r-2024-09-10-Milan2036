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


        //4
        static string GetTeamNameFromUser()
        {
            Console.WriteLine("Enter a team name: ");
            string teamName = Console.ReadLine();
            return teamName;
        }


        //5
        static void CountGoalsForTeam(string[] matches, string teamName)
        {
            int goalsScored = 0;
            int goalsConceded = 0;

            foreach (var match in matches)
            {
                string[] parts = match.Split(' ');
                string[] score = parts[1].Split('-');
                if (parts[0].Contains(teamName))
                {
                    if (parts[0].Split('-')[0] == teamName)
                    {
                        goalsScored += int.Parse(score[0]);
                        goalsConceded += int.Parse(score[1]);
                    }
                    else
                    {
                        goalsScored += int.Parse(score[1]);
                        goalsConceded += int.Parse(score[0]);
                    }
                }
            }

            Console.WriteLine($"{teamName} scored: {goalsScored}, conceded: {goalsConceded}");
        }


        //6
        static void CheckHomeUndefeated(string[] matches, string teamName)
        {
            bool undefeated = true;

            foreach (var match in matches)
            {
                string[] parts = match.Split(' ');
                string[] score = parts[1].Split('-');
                if (parts[0].Contains(teamName) && parts[0].Split('-')[0] == teamName)
                {
                    if (int.Parse(score[0]) < int.Parse(score[1]))
                    {
                        undefeated = false;
                        Console.WriteLine($"{teamName} lost at home in this match: {match}");
                        break;
                    }
                }
            }

            if (undefeated)
            {
                Console.WriteLine($"{teamName} remained undefeated at home.");
            }
        }


        //7
        static void GenerateMatchStatistics(string[] matches)
        {
            Dictionary<string, int> scoreStatistics = new Dictionary<string, int>();

            foreach (var match in matches)
            {
                string[] score = match.Split(' ')[1].Split('-');
                string finalScore = $"{score[0]}-{score[1]}";

                if (scoreStatistics.ContainsKey(finalScore))
                {
                    scoreStatistics[finalScore]++;
                }
                else
                {
                    scoreStatistics[finalScore] = 1;
                }
            }

            Console.WriteLine("Final score statistics:");
            foreach (var entry in scoreStatistics)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} times");
            }

            using (StreamWriter writer = new StreamWriter("stat.txt"))
            {
                foreach (var entry in scoreStatistics)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value} times");
                }
            }
        }
    }
}