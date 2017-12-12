using Domain.RealEstater.Contracts;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class LocationRealEstatePropertyMatcher : IPropertyMatcher
    {
        private const decimal Threshold = 1m / 111 / 1000 * 200;

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return agencyProperty.AgencyCode == databaseProperty.AgencyCode &&
                   IsWithinThreshold(agencyProperty, databaseProperty);
        }

        private static bool IsWithinThreshold(Property agencyProperty, Property databaseProperty)
        {
            return (agencyProperty.Latitude - databaseProperty.Latitude) *
                   (agencyProperty.Latitude - databaseProperty.Latitude) +
                   (agencyProperty.Longitude - databaseProperty.Longitude) *
                   (agencyProperty.Longitude - databaseProperty.Longitude) <=
                   Threshold * Threshold;
        }
    }
}