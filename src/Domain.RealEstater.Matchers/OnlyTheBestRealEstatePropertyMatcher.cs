using System.Linq;
using Domain.RealEstater.Contracts;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class OnlyTheBestRealEstatePropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var aName = FilterString(agencyProperty.Name);
            var dName = FilterString(databaseProperty.Name);
            var aAddress = FilterString(agencyProperty.Address);
            var dAddress = FilterString(databaseProperty.Address);

            return aName == dName && aAddress == dAddress;
        }

        private static string FilterString(string str)
        {
            var chars = str.Replace('-', ' ').Where(ch => !char.IsPunctuation(ch));

            return string.Concat(chars).ToLower();
        }
    }
}