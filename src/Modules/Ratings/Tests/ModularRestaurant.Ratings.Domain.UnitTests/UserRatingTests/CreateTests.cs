using System;
using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Ratings.Domain.Rules;
using ModularRestaurant.Shared.Domain.Common;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.UserRatingTests
{
    [TestFixture]
    public class CreateTests : UserRatingBaseTestClass
    {
        [Test]
        public void Create_WhenDataIsCorrect_IsSuccessful()
        {
            var userRating = UserRating.Create(_userId, _ratingValue, _comment);

            userRating.Should().NotBeNull();
            userRating.UserId.Should().BeEquivalentTo(_userId);
            userRating.Rating.Should().BeEquivalentTo(Rating.FromValue(_ratingValue));
            userRating.Comment.Should().Be(_comment);
        }
        
        [Test]
        public void Create_WhenCommentIsTooLong_IsNotPossible()
        {
            Action action = () =>  UserRating.Create(_userId, _ratingValue, _tooLongComment);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CommentCannotExceedCharacterLimit);
        }
    }
}