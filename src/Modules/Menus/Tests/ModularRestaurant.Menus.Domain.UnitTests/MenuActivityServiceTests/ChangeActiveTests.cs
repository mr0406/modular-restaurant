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
    public class ChangeActiveTests
    {
        [Test]
        public async Task ChangeActive_WhenCanActivateAndRestaurantDoNotHaveActiveMenu_IsSuccessful()
        {
            var menuToActivate = Provider.GetReadyToActivateMenu();
            var menuRepository = Provider.GetMenuRepository(menuToActivate);
            var restaurantId = Provider.GetRestaurantId();
            var service = new MenuActivityService(menuRepository);
            
            await service.ChangeActive(restaurantId, menuToActivate.Id);
            
            menuToActivate.IsActive.Should().BeTrue();
        }

        [Test]
        public async Task ChangeActive_WhenCanActivateAndRestaurantHasAlreadyHaveActiveMenu_IsSuccessful()
        {
            var menuToActivate = Provider.GetReadyToActivateMenu();
            var currentActiveMenu = Provider.GetActiveMenu();
            var menuRepository = Provider.GetMenuRepository(menuToActivate, currentActiveMenu);
            var restaurantId = Provider.GetRestaurantId();
            var service = new MenuActivityService(menuRepository);
            
            await service.ChangeActive(restaurantId, menuToActivate.Id);
            
            menuToActivate.IsActive.Should().BeTrue();
            currentActiveMenu.IsActive.Should().BeFalse();
        }

        [Test]
        public async Task ChangeActive_WhenMenuIsAlreadyActive_IsNotPossible()
        {
            var menuToActivate = Provider.GetActiveMenu();
            var currentActiveMenu = menuToActivate;
            var menuRepository = Provider.GetMenuRepository(menuToActivate, currentActiveMenu);
            var service = new MenuActivityService(menuRepository);
            
            Func<Task> func = () => service.ChangeActive(It.IsAny<RestaurantId>(), It.IsAny<MenuId>());

            await func.Should().ThrowAsync<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotActivateActiveMenuRule);
        }
        
        [Test]
        public async Task ChangeActive_WhenMenuIsEmpty_IsNotPossible()
        {
            var menuToActivate = Provider.GetEmptyMenu();
            var menuRepository = Provider.GetMenuRepository(menuToActivate);
            var service = new MenuActivityService(menuRepository);

            Func<Task> func = () => service.ChangeActive(It.IsAny<RestaurantId>(), It.IsAny<MenuId>());

            await func.Should().ThrowAsync<BusinessRuleException>()
                .Where(x => x.BrokenRule is ActiveMenuMustHaveAtLeastOneGroup);
        }
    }
}