using System.Linq;
using Domain.RealEstater.Contracts;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class OnlyTheBestRealEstatePropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return StringEquals(agencyProperty.Name, databaseProperty.Name) &&
                   StringEquals(agencyProperty.Address, databaseProperty.Address);
        }

        private static bool StringEquals(string str1, string str2)
        {
            return FilterString(str1) == FilterString(str2);
        }

        private static string FilterString(string str)
        {
            var chars = str.Replace('-', ' ').Where(ch => !char.IsPunctuation(ch));

            return string.Concat(chars).ToLower();
        }
    }
}