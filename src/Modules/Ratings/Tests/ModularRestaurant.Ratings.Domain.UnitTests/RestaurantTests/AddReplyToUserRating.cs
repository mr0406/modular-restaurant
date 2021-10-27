using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public class AddReplyToUserRating : RestaurantBaseTestClass
    {
        [Test]
        public void AddReplyToUserRating_WhenDataIsCorrect_IsSuccessful()
        {
            _restaurant.AddUserRating(_userId, _ratingValue, _comment);
            _restaurant.AddReplyToUserRating(_userId, _restaurantReply);

            _restaurant.UserRatings[0].RestaurantReply.Should().NotBeNull();
            _restaurant.UserRatings[0].RestaurantReply.Should().Be(_restaurantReply);
        }

        [Test]
        public void AddReplyToUserRating_WhenUserRatingNotExists_IsNotPossible()
        {
            Action action = () =>_restaurant.AddReplyToUserRating(_userId, _restaurantReply);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CanAddReplyOnlyToExistingUserRatingRule);
        }
    }
}