using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class Extensions
    {
        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }

        public static List<List<string>> ToGroups(this List<string> values)
        {
            var groups = new List<List<string>>();
            var group = new List<string>();

            foreach (var value in values)
            {
                if (value == string.Empty)
                {
                    groups.Add(group);
                    group = new List<string>();
                    continue;
                }

                group.Add(value);
            }

            groups.Add(group);

            return groups;
        }
    }
}
