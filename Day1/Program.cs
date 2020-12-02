using System;
using System.IO;
using System.Linq;
using Utilities;

namespace Day1
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").Select(x => x.ToInt()).ToArray();

            Part1(inputValues);
            Part2(inputValues);
        }

        private static void Part1(int[] inputValues)
        {
            for (int i = 0; i < inputValues.Length; i++)
            {
                for (int j = i; j < inputValues.Length; j++)
                {
                    if (inputValues[i] + inputValues[j] == 2020)
                    {
                        Console.WriteLine(inputValues[i] * inputValues[j]);
                        return;
                    }
                }
            }
        }

        private static void Part2(int[] inputValues)
        {
            for (int i = 0; i < inputValues.Length; i++)
            {
                for (int j = i; j < inputValues.Length; j++)
                {
                    for (int k = j; k < inputValues.Length; k++)
                    {
                        if (inputValues[i] + inputValues[j] + inputValues[k] == 2020)
                        {
                            Console.WriteLine(inputValues[i] * inputValues[j] * inputValues[k]);
                            return;
                        }
                    }
                }
            }
        }
    }
}
