using Domain.RealEstater.Matchers;
using Domain.RealEstater.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.RealEstater.Tests
{
    [TestClass]
    public class OnlyTheBestRealEstatePropertyMatcherTests
    {
        [TestMethod]
        public void ShouldMatch()
        {
            var propertyMatcher = new OnlyTheBestRealEstatePropertyMatcher();

            var agencyPropery = new Property
            {
                AgencyCode = "OTBRE",
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW.",
                Latitude = -33.8707617m,
                Longitude = 151.2151041m
            };

            var databaseProperty = new Property
            {
                AgencyCode = "OTBRE",
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                Latitude = -33.8707617m,
                Longitude = 151.2151041m
            };

            var isMatch = propertyMatcher.IsMatch(agencyPropery, databaseProperty);

            Assert.IsTrue(isMatch);
        }

        [TestMethod]
        public void ShouldNotMatch()
        {
            var propertyMatcher = new OnlyTheBestRealEstatePropertyMatcher();

            var agencyPropery = new Property
            {
                AgencyCode = "OTBRE",
                Name = "*Super*-High! (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW.",
                Latitude = -33.8707617m,
                Longitude = 151.2151041m
            };

            var databaseProperty = new Property
            {
                AgencyCode = "OTBRE",
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                Latitude = -33.8707617m,
                Longitude = 151.2151041m
            };

            var isMatch = propertyMatcher.IsMatch(agencyPropery, databaseProperty);

            Assert.IsFalse(isMatch);
        }
    }
}