using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.UserRatingTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Create_WhenDataIsCorrectAndCommentIsProvided_IsSuccessful()
        {
            var userId = new UserId(Guid.NewGuid());
            var restaurantId = new RestaurantId(Guid.NewGuid());
            var rating = Rating.FromValue(2);
            var comment = " simple comment ";
            var uniquenessChecker = Provider.GetUniquenessCheckerWhichPass();
            
            var userRating = UserRating.Create(userId, restaurantId, rating, comment, uniquenessChecker);

            userRating.Should().NotBeNull();
            userRating.UserId.Should().BeEquivalentTo(userId);
            userRating.Rating.Should().BeEquivalentTo(rating);
            userRating.Comment.Should().Be(comment.Trim());
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Create_WhenDataIsCorrectAndCommentIsNotProvided_IsSuccessful(string comment)
        {
            var userId = new UserId(Guid.NewGuid());
            var restaurantId = new RestaurantId(Guid.NewGuid());
            var rating = Rating.FromValue(2);
            var uniquenessChecker = Provider.GetUniquenessCheckerWhichPass();
            
            var userRating = UserRating.Create(userId, restaurantId, rating, comment, uniquenessChecker);

            userRating.Should().NotBeNull();
            userRating.Version.Should().Be(0);
            userRating.UserId.Should().BeEquivalentTo(userId);
            userRating.RestaurantId.Should().BeEquivalentTo(restaurantId);
            userRating.Rating.Should().BeEquivalentTo(rating);
            userRating.Comment.Should().BeNull();
        }
        
        [Test]
        public void Create_WhenUserRatingExists_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            var restaurantId = Provider.GetRestaurantId();
            var rating = Provider.GetRating();
            var comment = Provider.GetUserComment();
            var uniquenessChecker = Provider.GetUniquenessCheckerWhichFails();
            
            Action action = () =>  UserRating.Create(userId, restaurantId, rating, comment, uniquenessChecker);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is UserCanOnlyRateRestaurantOnceRule);
        }
        
        [Test]
        public void Create_WhenCommentIsTooLong_IsNotPossible()
        {
            var userId = Provider.GetUserId();
            var restaurantId = Provider.GetRestaurantId();
            var rating = Provider.GetRating();
            var commentCharacterLimit = Provider.GetCommentCharacterLimit();
            var tooLongComment = new string('a', commentCharacterLimit + 1);
            var uniquenessChecker = Provider.GetUniquenessCheckerWhichPass();
            
            Action action = () =>  UserRating.Create(userId, restaurantId, rating, tooLongComment, uniquenessChecker);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CommentCannotExceedCharacterLimit);
        }
    }
}