using Domain.RealEstater.Models;

namespace Domain.RealEstater.Contracts.Matchers
{
    public interface IPropertyMatcher
    {
        string AgencyCode { get; }
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}