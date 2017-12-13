using Domain.RealEstater.Contracts;
using Domain.RealEstater.Contracts.Matchers;
using Domain.RealEstater.Helpers;
using Domain.RealEstater.Models;

namespace Domain.RealEstater.Matchers
{
    public class LocationRealEstatePropertyMatcher : IPropertyMatcher
    {
        private const decimal Threshold = 1m / 111 / 1000 * 200;

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var agencyCodeEquals = agencyProperty.AgencyCode == databaseProperty.AgencyCode;
            var isWithinThreshold = Threshold.IsWithin(agencyProperty.Latitude, agencyProperty.Longitude,
                databaseProperty.Latitude, databaseProperty.Longitude);

            return agencyCodeEquals && isWithinThreshold;
        }
    }
}