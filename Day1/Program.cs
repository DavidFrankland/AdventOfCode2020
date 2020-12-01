using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").Select(x => Convert.ToInt32(x)).ToList();

            Console.WriteLine(Part1(inputValues));
            Console.WriteLine(Part2(inputValues));
        }

        private static int Part1(List<int> inputValues)
        {
            foreach (var inputValue1 in inputValues)
            {
                foreach (var inputValue2 in inputValues)
                {
                    if (inputValue1 + inputValue2 == 2020)
                    {
                        return inputValue1 * inputValue2;
                    }
                }
            }

            return 0;
        }

        private static int Part2(List<int> inputValues)
        {
            foreach (var inputValue1 in inputValues)
            {
                foreach (var inputValue2 in inputValues)
                {
                    foreach (var inputValue3 in inputValues)
                    {
                        if (inputValue1 + inputValue2 + inputValue3 == 2020)
                        {
                            return inputValue1 * inputValue2 * inputValue3;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
