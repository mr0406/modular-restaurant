using FluentAssertions;
using ModularRestaurant.Ratings.Domain.Entities;
using NUnit.Framework;

namespace ModularRestaurant.Ratings.Domain.UnitTests.RestaurantTests
{
    [TestFixture]
    public class CreateTests : RestaurantBaseTestClass
    {
        [Test]
        public void Create_WhenDataIsCorrect_IsSuccessful()
        {
            var restaurantId = Provider.GetRestaurantId();
            
            var restaurant = Restaurant.Create(restaurantId);

            restaurant.Should().NotBeNull();
            restaurant.Id.Should().BeEquivalentTo(restaurantId);
        }
    }
}