using Domain.RealEstater.Matchers;
using Domain.RealEstater.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.RealEstater.Tests
{
    [TestClass]
    public class ContraryRealEstatePropertyMatcherTests
    {
        [TestMethod]
        public void ShouldMatch()
        {
            var propertyMatcher = new ContraryRealEstatePropertyMatcher();

            var agencyProperty = new Property
            {
                AgencyCode = "CRE",
                Name = "Apartments Summit The",
                Address = "31 Hereford Street, Glebe NSW",
                Latitude = -33.8787075m,
                Longitude = 151.1820893m
            };

            var databasePropety = new Property
            {
                AgencyCode = "CRE",
                Name = "The Summit Apartments",
                Address = "31 Hereford Street, Glebe NSW",
                Latitude = -33.8787075m,
                Longitude = 151.1820893m
            };

            var isMatch = propertyMatcher.IsMatch(agencyProperty, databasePropety);

            Assert.IsTrue(isMatch);
        }

        [TestMethod]
        public void ShouldNotMatch()
        {
            var propertyMatcher = new ContraryRealEstatePropertyMatcher();

            var agencyProperty = new Property
            {
                AgencyCode = "CRE",
                Name = "The Summit Apartments",
                Address = "31 Hereford Street, Glebe NSW",
                Latitude = -33.8787075m,
                Longitude = 151.1820893m
            };

            var databasePropety = new Property
            {
                AgencyCode = "CRE",
                Name = "Summit The Apartments",
                Address = "31 Hereford Street, Glebe NSW",
                Latitude = -33.8787075m,
                Longitude = 151.1820893m
            };

            var isMatch = propertyMatcher.IsMatch(agencyProperty, databasePropety);

            Assert.IsFalse(isMatch);
        }
    }
}