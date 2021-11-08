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
        private readonly int _commentCharacterLimit = 500;
        private readonly int _ratingValue = 5;
        private readonly string _comment = "comment";
        private readonly Guid _userIdGuid = new("5AC1504E-AC20-4018-BE76-243481E63AD8");
        private UserId _userId;
        private string _tooLongComment;

        [SetUp]
        public void Setup()
        {
            _userId = new UserId(_userIdGuid);
            _tooLongComment = new string('a', _commentCharacterLimit + 1);
        }
        
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