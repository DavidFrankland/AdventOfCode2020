using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Utilities;

namespace Day4
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToList();

            Part1(inputValues, false);
            Part1(inputValues, true);
        }

        private static void Part1(List<string> inputValues, bool checkValues)
        {
            int validPassports = 0;
            var attributes = new List<string>();

            foreach (var inputValue in inputValues)
            {
                if (inputValue == string.Empty)
                {
                    if (IsValidPassport(attributes, checkValues)) validPassports++;
                    attributes.Clear();
                    continue;
                }

                attributes.AddRange(inputValue.Split(' '));
            }

            if (IsValidPassport(attributes, checkValues)) validPassports++;

            Console.WriteLine(validPassports);
        }

        private static bool IsValidPassport(List<string> attributes, bool checkValues)
        {
            var attributePairs = attributes
                .Select(attribute => attribute.Split(':'))
                .ToDictionary(s => s[0], s => s[1]);

            /*
            byr (Birth Year)
            iyr (Issue Year)
            eyr (Expiration Year)
            hgt (Height)
            hcl (Hair Color)
            ecl (Eye Color)
            pid (Passport ID)
            cid (Country ID)
            */

            var requiredKeys = new List<string>
            {
                "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid",
            };

            var allKeysPresent = requiredKeys.All(attributePairs.ContainsKey);

            if (!allKeysPresent) return false;

            if (!checkValues) return true;

            //byr (Birth Year) - four digits; at least 1920 and at most 2002.
            var birthYear = attributePairs["byr"].ToInt();
            if (birthYear < 1920 || birthYear > 2002) return false;

            //iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            var issueYear = attributePairs["iyr"].ToInt();
            if (issueYear < 2010 || issueYear > 2020) return false;

            //eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            var expirationYear = attributePairs["eyr"].ToInt();
            if (expirationYear < 2020 || expirationYear > 2030) return false;

            //hgt (Height) - a number followed by either cm or in:
            var height = attributePairs["hgt"];
            var regex = new Regex("^(\\d+)(cm|in)$");
            var match = regex.Match(height);
            if (!match.Success) return false;
            var groups = match.Groups;
            var heightValue = groups[1].Value.ToInt();
            var heightUnit = groups[2].Value;

            switch (heightUnit)
            {
                //If cm, the number must be at least 150 and at most 193.
                case "cm":
                    if (heightValue < 150 || heightValue > 193) return false;
                    break;
                //If in, the number must be at least 59 and at most 76.
                case "in":
                    if (heightValue < 59 || heightValue > 76) return false;
                    break;
                default:
                    return false;
            }

            //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            var hairColour = attributePairs["hcl"];
            if (!Regex.IsMatch(hairColour, "^#[0-9a-f]{6}$")) return false;

            //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            var eyeColour = attributePairs["ecl"];
            if (!Regex.IsMatch(eyeColour, "^amb|blu|brn|gry|grn|hzl|oth$")) return false;

            //pid (Passport ID) - a nine-digit number, including leading zeroes.
            var passportId = attributePairs["pid"];
            if (!Regex.IsMatch(passportId, "^\\d{9}$")) return false;

            return true;
        }
    }
}
