using System;
using System.IO;
using System.Linq;

namespace Skeleton
{
    internal class Program
    {
        private static void Main()
        {
            // integers
            //var inputValues = File.ReadLines("input.txt").Select(x => Convert.ToInt32(x)).ToList();

            // strings
            var inputValues = File.ReadLines("input.txt").ToList();

            Console.WriteLine($"There are {inputValues.Count} values");
        }
    }
}
