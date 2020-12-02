using System;

namespace Utilities
{
    public static class Extensions
    {
        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
