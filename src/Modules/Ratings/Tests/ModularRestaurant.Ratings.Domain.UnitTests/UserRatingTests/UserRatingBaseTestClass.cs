using System;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.UserRatingTests
{
    [TestFixture]
    public abstract class UserRatingBaseTestClass
    {
        private readonly int _commentCharacterLimit = 500;
        private readonly int _replyCharacterLimit = 500;
        protected readonly int _ratingValue = 5;
        protected readonly string _comment = "comment";
        protected readonly Guid _guid = new("5AC1504E-AC20-4018-BE76-243481E63AD8");
        protected UserId _userId;
        protected UserRating _userRating;
        protected readonly string _restaurantReply = "reply";
        protected string _tooLongComment;
        protected string _tooLongReply;

        [SetUp]
        public void Setup()
        {
            _userId = new UserId(_guid);
            _userRating = UserRating.Create(_userId, _ratingValue, _comment);
            _tooLongComment = new string('a', _commentCharacterLimit + 1);
            _tooLongReply = new string('a', _replyCharacterLimit + 1);
        }
    }
}