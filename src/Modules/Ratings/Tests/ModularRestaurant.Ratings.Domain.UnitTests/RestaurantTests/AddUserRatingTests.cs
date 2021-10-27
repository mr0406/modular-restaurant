using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public class AddUserRatingTests : RestaurantBaseTestClass
    {
        [Test]
        public void AddUserRating_WhenDataIsCorrect_IsSuccessful()
        {
            _restaurant.AddUserRating(_userId, _ratingValue, _comment);

            _restaurant.UserRatings.Should().HaveCount(1);
            _restaurant.UserRatings[0].UserId.Should().BeEquivalentTo(_userId);
            _restaurant.UserRatings[0].Rating.Should().BeEquivalentTo(Rating.FromValue(_ratingValue));
            _restaurant.UserRatings[0].Comment.Should().Be(_comment);
        }
        
        [Test]
        public void AddUserRating_WhenUserAlreadyRated_IsNotPossible()
        {
            _restaurant.AddUserRating(_userId, _ratingValue, _comment);
            
            Action action = () => _restaurant.AddUserRating(_userId, _ratingValue, _comment);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is UserCanOnlyRateRestaurantOnceRule);
        }
    }
}