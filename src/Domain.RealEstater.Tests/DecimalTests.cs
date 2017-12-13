using Domain.RealEstater.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.RealEstater.Tests
{
    [TestClass]
    public class DecimalTests
    {
        [TestMethod]
        public void ShouldBeWithin()
        {
            var isWithin = 2m.IsWithin(-2, 0, 0, 0);

            Assert.IsTrue(isWithin);
        }

        [TestMethod]
        public void ShouldNotBeWithin()
        {
            var isWithin = 2m.IsWithin(-2, 2, 0, 0);

            Assert.IsFalse(isWithin);
        }
    }
}