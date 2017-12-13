using Domain.RealEstater.Contracts.Matchers;
using Domain.RealEstater.Helpers;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class OnlyTheBestRealEstatePropertyMatcher : IPropertyMatcher
    {
        public string AgencyCode => "OTBRE";

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var nameEquals = agencyProperty.Name.EqualsWithoutPunctuation(databaseProperty.Name);
            var addressEquals = agencyProperty.Address.EqualsWithoutPunctuation(databaseProperty.Address);

            return nameEquals && addressEquals;
        }
    }
}