using Domain.RealEstater.Matchers;
using Domain.RealEstater.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.RealEstater.Tests
{
    [TestClass]
    public class LocationRealEstatePropertyMatcherTests
    {
        [TestMethod]
        public void ShouldMatch()
        {
            var propertyMatcher = new LocationRealEstatePropertyMatcher();

            var agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Name = "Luxurious Apartments",
                Address = "4 McDonald Street, Potts Point NSW",
                Latitude = -33.8694754m,
                Longitude = 151.2229558m
            };

            var databasePropety = new Property
            {
                AgencyCode = "LRE",
                Name = "Luxurious Apartments",
                Address = "4 McDonald Street, Potts Point NSW",
                Latitude = -33.8677394m,
                Longitude = 151.2229558m
            };

            var isMatch = propertyMatcher.IsMatch(agencyProperty, databasePropety);

            Assert.IsTrue(isMatch);
        }

        [TestMethod]
        public void ShouldNotMatch()
        {
            var propertyMatcher = new LocationRealEstatePropertyMatcher();

            var agencyProperty = new Property
            {
                AgencyCode = "LRE",
                Name = "Luxurious Apartments",
                Address = "4 McDonald Street, Potts Point NSW",
                Latitude = -33.8696754m,
                Longitude = 151.2229558m
            };

            var databasePropety = new Property
            {
                AgencyCode = "LRE",
                Name = "Luxurious Apartments",
                Address = "4 McDonald Street, Potts Point NSW",
                Latitude = -33.8677394m,
                Longitude = 151.2229558m
            };

            var isMatch = propertyMatcher.IsMatch(agencyProperty, databasePropety);

            Assert.IsFalse(isMatch);
        }
    }
}