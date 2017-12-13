using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts.Matchers
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}