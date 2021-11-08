using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.GroupTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Create_WithCorrectData_IsSuccessful()
        {
            var name = "GROUP_NAME";

            var group = Group.Create(name);

            group.Should().NotBeNull();
            group.Name.Should().Be(name);
        }
    }
}