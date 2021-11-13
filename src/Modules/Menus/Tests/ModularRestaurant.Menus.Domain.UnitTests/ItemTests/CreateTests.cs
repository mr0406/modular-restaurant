using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.ValueObjects;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.ItemTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Create_WithCorrectData_IsSuccessful()
        {
            var name = "ITEM_NAME";
            var description = "ITEM_DESCRIPTION";
            var price = Money.Create(123, "XXX");

            var item = Item.Create(name, description, price);

            item.Should().NotBeNull();
            item.Name.Should().Be(name);
            item.Description.Should().Be(description);
            item.Price.Should().Be(price);
        }
    }
}