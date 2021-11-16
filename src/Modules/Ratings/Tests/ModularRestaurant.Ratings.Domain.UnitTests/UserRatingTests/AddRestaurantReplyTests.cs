using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.UserRatingTests
{
    [TestFixture]
    public class AddRestaurantReplyTests
    {
        [Test]
        public void AddRestaurantReply_WhenDataIsCorrect_IsSuccessful()
        {
            var userRating = Provider.GetUserRatingWithoutReply();
            var reply = " REPLY ";

            userRating.AddRestaurantReply(reply);

            userRating.RestaurantReply.Should().Be(reply.Trim());
        }
        
        [Test]
        public void AddRestaurantReply_WhenReplyAlreadyExists_IsNotPossible()
        {
            var userRating = Provider.GetUserRatingWithReply();
            var reply = Provider.GetRestaurantReply();
            
            Action action = () => userRating.AddRestaurantReply(reply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CanReplyToUserRatingOnlyOnceRule);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddRestaurantReply_WhenReplyIsEmpty_IsNotPossible(string reply)
        {
            var userRating = Provider.GetUserRatingWithoutReply();

            Action action = () => userRating.AddRestaurantReply(reply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotBeEmptyRule);
        }

        [Test]
        public void AddRestaurantReply_WhenReplyIsTooLong_IsNotPossible()
        {
            var userRating = Provider.GetUserRatingWithoutReply();
            var replyCharacterLimit = Provider.GetRestaurantReplyCharacterLimit();
            var tooLongReply = new string('a', replyCharacterLimit + 1);

            Action action = () => userRating.AddRestaurantReply(tooLongReply);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotExceedCharacterLimit);
        }
    }
}