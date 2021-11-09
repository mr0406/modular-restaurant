using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
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

            var item = Item.Create(name, description);

            item.Should().NotBeNull();
            item.Name.Should().Be(name);
            item.Description.Should().Be(description);
        }
    }
}