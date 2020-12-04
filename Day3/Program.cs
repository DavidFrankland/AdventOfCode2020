using System;
using System.IO;
using System.Linq;

namespace Day3
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToArray();

            Part1(inputValues);
            Part2(inputValues);
        }

        private static void Part1(string[] inputValues)
        {
            Console.WriteLine(CountTrees(inputValues, 3, 1));
        }

        private static void Part2(string[] inputValues)
        {
            long trees = CountTrees(inputValues, 1, 1);
            trees *= CountTrees(inputValues, 3, 1);
            trees *= CountTrees(inputValues, 5, 1);
            trees *= CountTrees(inputValues, 7, 1);
            trees *= CountTrees(inputValues, 1, 2);
            Console.WriteLine(trees);
        }
        
        private static int CountTrees(string[] inputValues, int right, int down)
        {
            int x = 0;
            int y = 0;
            int trees = 0;
            int width = inputValues[0].Length;

            do
            {
                if (inputValues[y][x] == '#') trees++;
                x = (x + right) % width;
                y += down;
            } while (y < inputValues.Length);

            return trees;
        }
    }
}
