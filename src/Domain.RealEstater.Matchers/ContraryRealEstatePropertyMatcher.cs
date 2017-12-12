using Domain.RealEstater.Contracts;
using Domain.RealEstater.Helpers;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class ContraryRealEstatePropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return agencyProperty.Name.Backward() == databaseProperty.Name;
        }
    }
}