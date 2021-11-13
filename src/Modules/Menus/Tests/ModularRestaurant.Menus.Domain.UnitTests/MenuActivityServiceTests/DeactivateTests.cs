using System;
using System.Threading.Tasks;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;
using Moq;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuActivityServiceTests
{
    [TestFixture]
    public class DeactivateTests
    {
        [Test]
        public async Task Deactivate_WhenMenuIsActive_IsSuccessful()
        {
            var activeMenu = Provider.GetActiveMenu();
            var menuRepository = Provider.GetMenuRepository(activeMenu);
            var service = new MenuActivityService(menuRepository);

            await service.Deactivate(It.IsAny<MenuId>());

            activeMenu.IsActive.Should().BeFalse();
        }
        
        [Test]
        public async Task Deactivate_WhenMenuIsInactive_IsNotPossible()
        {
            var activeMenu = Provider.GetInactiveMenu();
            var menuRepository = Provider.GetMenuRepository(activeMenu);
            var service = new MenuActivityService(menuRepository);

            Func<Task> func = () => service.Deactivate(It.IsAny<MenuId>());

            await func.Should().ThrowAsync<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotDeactivateInactiveMenuRule);
        }
    }
}