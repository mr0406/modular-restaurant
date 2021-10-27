using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.UserRatingTests
{
    [TestFixture]
    public class AddRestaurantReplyTests : UserRatingBaseTestClass
    {
        [Test]
        public void AddRestaurantReply_WhenDataIsCorrect_IsSuccessful()
        {
            _userRating.AddRestaurantReply(_restaurantReply);

            _userRating.RestaurantReply.Should().NotBeNull();
            _userRating.RestaurantReply.Should().Be(_restaurantReply);
        }

        [Test]
        public void AddRestaurantReply_WhenReplyIsNull_IsNotPossible()
        {
            Action action = () => _userRating.AddRestaurantReply(null);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotBeEmptyRule);
        }

        [Test]
        public void AddRestaurantReply_WhenReplyIsEmpty_IsNotPossible()
        {
            Action action = () => _userRating.AddRestaurantReply("");

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotBeEmptyRule);
        }
        
        [Test]
        public void AddRestaurantReply_WhenReplyAfterTrimIsEmpty_IsNotPossible()
        {
            Action action = () => _userRating.AddRestaurantReply(" ");

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotBeEmptyRule);
        }

        [Test]
        public void AddRestaurantReply_WhenReplyIsTooLong_IsNotPossible()
        {
            Action action = () => _userRating.AddRestaurantReply(_tooLongReply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is RestaurantReplyCannotExceedCharacterLimit);
        }
        
        [Test]
        public void AddRestaurantReply_WhenReplyAlreadyExists_IsNotPossible()
        {
            _userRating.AddRestaurantReply(_restaurantReply);
            
            Action action = () => _userRating.AddRestaurantReply(_restaurantReply);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CanReplyToUserRatingOnceRule);
        }
    }
}