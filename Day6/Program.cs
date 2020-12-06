using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToList();

            var groups = GetGroups(inputValues);

            Part1(groups);
            Part2(groups);
        }

        private static List<List<string>> GetGroups(List<string> inputValues)
        {
            var groups = new List<List<string>>();
            var group = new List<string>();

            foreach (var inputValue in inputValues)
            {
                if (inputValue == string.Empty)
                {
                    groups.Add(group);
                    group = new List<string>();
                    continue;
                }

                group.Add(inputValue);
            }

            groups.Add(group);

            return groups;
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
