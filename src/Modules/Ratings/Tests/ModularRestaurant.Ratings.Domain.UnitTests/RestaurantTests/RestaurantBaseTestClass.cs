using System;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public abstract class RestaurantBaseTestClass
    {
        protected readonly int _ratingValue = 5;
        protected readonly string _comment = "comment";
        protected readonly Guid _guid = new("5AC1504E-AC20-4018-BE76-243481E63AD8");
        protected UserId _userId;
        protected UserRating _userRating;
        protected readonly string _restaurantReply = "reply";
        protected RestaurantId _restaurantId;
        protected Restaurant _restaurant;

        [SetUp]
        public void Setup()
        {
            _userId = new UserId(_guid);
            _userRating = UserRating.Create(_userId, _ratingValue, _comment);
            _restaurant = new Restaurant(_restaurantId);
        }
    }
}