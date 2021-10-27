using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests
{
    [TestFixture]
    public class RatingTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void FromValue_WhenValueIsCorrect_IsSuccessful(int value)
        {
            var rating = Rating.FromValue(value);
            
            Assert.That(rating.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(6)]
        public void FromValue_WhenRatingIsNotInRange_IsNotPossible(int value)
        {
            var e = Assert.Throws<BusinessRuleException>(() => Rating.FromValue(value));
            Assert.IsInstanceOf<RatingIsInRangeRule>(e!.BrokenRule);
        }
    }
}