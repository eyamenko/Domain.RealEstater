using Domain.RealEstater.Contracts;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class OnlyTheBestRealEstatePropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            throw new System.NotImplementedException();
        }
    }
}