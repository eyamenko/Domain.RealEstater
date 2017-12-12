using Domain.RealEstater.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.RealEstater.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void ShouldBackward()
        {
            var expected = "The Summit Apartments";
            var actual = "Apartments Summit The".Backward();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldFilterPunctuation()
        {
            var expected = "Super High Apartments Sydney";
            var actual = "*Super*-High! Apartments (Sydney)".FilterPunctuation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldCompareWithoutPunctuation()
        {
            var equals = "*Super*-High! APARTMENTS (Sydney)"
                .EqualsWithoutPunctuation("Super High Apartments, Sydney");

            Assert.IsTrue(equals);
        }
    }
}