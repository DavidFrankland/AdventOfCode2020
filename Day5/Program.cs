using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    internal class Program
    {
        private static void Main()
        {
            var inputValues = File.ReadLines("input.txt").ToList();

            var ids = new List<int>();

            foreach (var inputValue in inputValues)
            {
                int id = 0;
                var s = inputValue.Reverse().ToArray();
                int bit = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == 'R' || c == 'B')
                    {
                        id += bit;
                    }

                    bit *= 2;
                }

                ids.Add(id);
            }

            Console.WriteLine(ids.Max());

            ids.Sort();
            var q = ids.ToArray();
            for (int i = 0; i < q.Length; i++)
            {
                if (q[i] + 2 == q[i + 1])
                {
                    Console.WriteLine(q[i] + 1);
                    break;
                }
            }
        }
    }
}
