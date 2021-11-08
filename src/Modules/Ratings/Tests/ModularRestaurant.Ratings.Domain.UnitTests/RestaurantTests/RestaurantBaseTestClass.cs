using ModularRestaurant.Ratings.Domain.Entities;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public abstract class RestaurantBaseTestClass
    {
        protected UserRating _userRating;
        protected Restaurant _restaurant;

        [SetUp]
        public void Setup()
        {
            _userRating = UserRating.Create(Provider.GetUserId(), 
                Provider.GetRatingValue(), Provider.GetUserComment());
            _restaurant = new Restaurant(Provider.GetRestaurantId());
        }
    }
}