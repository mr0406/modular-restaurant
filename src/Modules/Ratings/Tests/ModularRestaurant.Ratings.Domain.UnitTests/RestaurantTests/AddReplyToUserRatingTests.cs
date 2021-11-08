using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public class AddReplyToUserRatingTests : RestaurantBaseTestClass
    {
        private readonly int _replyCharacterLimit = 500;
        private readonly string _restaurantReply = "reply";

        [Test]
        public void AddReplyToUserRating_WhenDataIsCorrect_IsSuccessful()
        {
            var userId = Provider.GetUserId();
            var ratingValue = Provider.GetRatingValue();
            var comment = Provider.GetUserComment();
            _restaurant.AddUserRating(userId, ratingValue, comment);
            
            _restaurant.AddReplyToUserRating(userId, _restaurantReply);

            _restaurant.UserRatings[0].RestaurantReply.Should().NotBeNull();
            _restaurant.UserRatings[0].RestaurantReply.Should().Be(_restaurantReply);
        }

        [Test]
        public void AddReplyToUserRating_WhenUserRatingNotExists_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            
            Action action = () => _restaurant.AddReplyToUserRating(userId, _restaurantReply);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CanAddReplyOnlyToExistingUserRatingRule);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddReplyToUserRating_WhenReplyIsEmpty_IsNotPossible(string reply)
        {
            var userId = Provider.GetUserId();
            var ratingValue = Provider.GetRatingValue();
            var comment = Provider.GetUserComment();
            _restaurant.AddUserRating(userId, ratingValue, comment);
            
            Action action = () => _restaurant.AddReplyToUserRating(userId, reply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotBeEmptyRule);
        }

        [Test]
        public void AddReplyToUserRating_WhenReplyIsTooLong_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            var ratingValue = Provider.GetRatingValue();
            var comment = Provider.GetUserComment();
            _restaurant.AddUserRating(userId, ratingValue, comment);
            var tooLongReply = new string('a', _replyCharacterLimit + 1);

            Action action = () => _restaurant.AddReplyToUserRating(userId, tooLongReply);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotExceedCharacterLimit);
        }

        [Test]
        public void AddRestaurantReply_WhenReplyAlreadyExists_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            var ratingValue = Provider.GetRatingValue();
            var comment = Provider.GetUserComment();
            _restaurant.AddUserRating(userId, ratingValue, comment);
            _restaurant.AddReplyToUserRating(userId, _restaurantReply);
            
            Action action = () => _restaurant.AddReplyToUserRating(userId, _restaurantReply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CanReplyToUserRatingOnlyOnceRule);
        }
    }
}