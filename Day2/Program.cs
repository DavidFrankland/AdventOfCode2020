using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Utilities;

namespace Day2
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToList();

            var regex = new Regex("(.+)-(.+) (.+): (.+)");

            Part1(inputValues, regex);
            Part2(inputValues, regex);
        }

        private static void Part1(IEnumerable<string> inputValues, Regex regex)
        {
            int validPasswords = 0;

            foreach (var inputValue in inputValues)
            {
                var match = regex.Match(inputValue);
                var min = match.Groups[1].Value.ToInt();
                var max = match.Groups[2].Value.ToInt();
                var letter = match.Groups[3].Value[0];
                var password = match.Groups[4].Value;

                var occurrences = password.Count(x => x == letter);

                if (min <= occurrences && occurrences <= max) validPasswords++;
            }

            Console.WriteLine(validPasswords);
        }

        private static void Part2(IEnumerable<string> inputValues, Regex regex)
        {
            int validPasswords = 0;

            foreach (var inputValue in inputValues)
            {
                var match = regex.Match(inputValue);
                var first = match.Groups[1].Value.ToInt() - 1;
                var second = match.Groups[2].Value.ToInt() - 1;
                var letter = match.Groups[3].Value[0];
                var password = match.Groups[4].Value;

                if (password[first] == letter ^ password[second] == letter) validPasswords++;
            }

            Console.WriteLine(validPasswords);
        }
    }
}
