using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}