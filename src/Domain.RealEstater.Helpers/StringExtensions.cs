using System;
using System.Linq;

namespace Domain.RealEstater.Helpers
{
    public static class StringExtensions
    {
        public static string Backward(this string str)
        {
            var reversed = str.Split(' ').Reverse();

            return string.Join(" ", reversed);
        }

        public static string FilterPunctuation(this string str)
        {
            var chars = str.Replace('-', ' ').Where(ch => !char.IsPunctuation(ch));

            return string.Concat(chars);
        }

        public static bool EqualsWithoutPunctuation(this string str1, string str2)
        {
            var str1Filtered = str1.FilterPunctuation();
            var str2Filtered = str2.FilterPunctuation();

            return string.Equals(str1Filtered, str2Filtered, StringComparison.OrdinalIgnoreCase);
        }
    }
}