using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public class AddUserRatingTests : RestaurantBaseTestClass
    {
        [Test]
        public void AddUserRating_WhenDataIsCorrect_IsSuccessful()
        {
            var userId = Provider.GetUserId();
            var ratingValue = 4;
            var comment = "user_comment";
            
            _restaurant.AddUserRating(userId, ratingValue, comment);

            _restaurant.UserRatings.Should().HaveCount(1);
            _restaurant.UserRatings[0].UserId.Should().BeEquivalentTo(userId);
            _restaurant.UserRatings[0].Rating.Should().BeEquivalentTo(Rating.FromValue(ratingValue));
            _restaurant.UserRatings[0].Comment.Should().Be(comment);
        }
        
        [Test]
        public void AddUserRating_WhenUserAlreadyRated_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            var ratingValue = Provider.GetRatingValue();
            var comment = Provider.GetUserComment();
            _restaurant.AddUserRating(userId, ratingValue, comment);
            
            Action action = () => _restaurant.AddUserRating(userId, ratingValue, comment);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is UserCanOnlyRateRestaurantOnceRule);
        }
    }
}