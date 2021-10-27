using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RatingsTests
{
    [TestFixture]
    public class FromValueTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void FromValue_WhenValueIsCorrect_IsSuccessful(int value)
        {
            var rating = Rating.FromValue(value);

            rating.Should().NotBeNull();
            rating.Value.Should().Be(value);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(6)]
        public void FromValue_WhenRatingIsNotInRange_IsNotPossible(int value)
        {
            Action action = () => Rating.FromValue(value);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RatingIsInRangeRule);
        }
    }
}