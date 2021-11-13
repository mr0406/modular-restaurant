using System.Threading.Tasks;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Domain.Types;
using Moq;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuInternalNameUniquenessCheckerTests
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public async Task CheckIsUnique_NotExists_ReturnsTrue()
        {
            var menuRepository = new Mock<IMenuRepository>();
            menuRepository.Setup(x => x.CheckExists(It.IsAny<RestaurantId>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            var service = new MenuInternalNameUniquenessChecker(menuRepository.Object);

            var isUnique = await service.CheckIsUnique(It.IsAny<RestaurantId>(), It.IsAny<string>());

            isUnique.Should().BeTrue();
        }

        [Test]
        public async Task CheckIsUnique_Exists_ReturnsFalse()
        {
            var menuRepository = new Mock<IMenuRepository>();
            menuRepository.Setup(x => x.CheckExists(It.IsAny<RestaurantId>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));
            var service = new MenuInternalNameUniquenessChecker(menuRepository.Object);
            
            var isUnique = await service.CheckIsUnique(It.IsAny<RestaurantId>(), It.IsAny<string>());

            isUnique.Should().BeFalse();
        }
    }
}