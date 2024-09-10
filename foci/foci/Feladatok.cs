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
            string[] matches = File.ReadAllLines("meccs.txt");

            Console.WriteLine("Enter round number: ");
            int round = int.Parse(Console.ReadLine());
            DisplayMatchesByRound(matches, round);

            DisplayTurnaroundTeams(matches);

            string teamName = GetTeamNameFromUser();

            CountGoalsForTeam(matches, teamName);

            CheckHomeUndefeated(matches, teamName);

            GenerateMatchStatistics(matches);
        }

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

        static string GetTeamNameFromUser()
        {
            Console.WriteLine("Enter a team name: ");
            string teamName = Console.ReadLine();
            return teamName;
        }

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
