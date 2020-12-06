using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utilities;

namespace Day6
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToList();

            var groups = inputValues.ToGroups();

            Part1(groups);
            Part2(groups);
        }


        private static void Part1(List<List<string>> groups)
        {
            var total = 0;

            foreach (var groupAnswers in groups)
            {
                string answers = string.Empty;

                foreach (var groupAnswer in groupAnswers)
                {
                    answers += groupAnswer;
                }

                total += answers.Distinct().Count();
            }

            Console.WriteLine(total);
        }

        private static void Part2(List<List<string>> groups)
        {
            int total = 0;

            foreach (var groupAnswers in groups)
            {
                int groupSize = groupAnswers.Count;
                var answersCounts = new Dictionary<char, int>();

                foreach (var groupAnswer in groupAnswers)
                {
                    foreach (var answer in groupAnswer)
                    {
                        if (!answersCounts.ContainsKey(answer)) answersCounts[answer] = 0;
                        answersCounts[answer]++;
                    }
                }

                foreach (var answersCount in answersCounts)
                {
                    if (answersCount.Value == groupSize) total++;
                }
            }

            Console.WriteLine(total);
        }
    }
}
