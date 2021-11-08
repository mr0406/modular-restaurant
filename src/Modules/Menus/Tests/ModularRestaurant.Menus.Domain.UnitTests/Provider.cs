using System;
using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Types;
using Moq;

namespace ModularRestaurant.Menus.Domain.UnitTests
{
    internal static class Provider
    {
        internal static Guid GetRestaurantGuid() => new("ae08f16c-0283-4adb-9f23-311d88622603");
        
        internal static RestaurantId GetRestaurantId() => new(GetRestaurantGuid());
        
        internal static  string GetMenuInternalName() => "menuInternalName";
        
        internal static string GetGroupName() => "groupName";

        internal static Guid GetGroupGuid() => new("FE4E3A09-924D-47BD-B66B-0022425FB74B");

        internal static GroupId GetGroupId() => new(GetGroupGuid());
        
        internal static string GetItemName() => "itemName";

        internal static Guid GetItemGuid() => new("1263C7A0-BA1C-4EB2-89D0-661622BC1731");

        internal static ItemId GetItemId() => new(GetItemGuid());
        
        internal static IMenuRepository GetMenuRepository()
        {
            var menuRepositoryMock = new Mock<IMenuRepository>();
            menuRepositoryMock.Setup(x => x.DoesRestaurantHaveMenuWithThisInternalNameAsync(
                It.IsAny<RestaurantId>(), It.IsAny<string>())).Returns(Task.FromResult(false));

            return menuRepositoryMock.Object;
        }
        
        internal static IMenuRepository GetMenuRepositoryWithNameConflict()
        {
            var menuRepositoryMock = new Mock<IMenuRepository>();
            menuRepositoryMock.Setup(x => x.DoesRestaurantHaveMenuWithThisInternalNameAsync(
                It.IsAny<RestaurantId>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            return menuRepositoryMock.Object;
        }

        internal static IMenuRepository GetMenuRepositoryWithActiveMenu()
        {
            var menuRepositoryMock = new Mock<IMenuRepository>();
            menuRepositoryMock.Setup(x => x.DoesRestaurantHaveActiveMenuAsync(
                It.IsAny<RestaurantId>())).Returns(Task.FromResult(true));

            return menuRepositoryMock.Object;
        }
        
        internal static IMenuRepository GetMenuRepositoryWithoutActiveMenu()
        {
            var menuRepositoryMock = new Mock<IMenuRepository>();
            menuRepositoryMock.Setup(x => x.DoesRestaurantHaveActiveMenuAsync(
                It.IsAny<RestaurantId>())).Returns(Task.FromResult(false));

            return menuRepositoryMock.Object;
        }
        
        internal static Menu GetReadyToActivateMenu()
        {
            var menu = GetEmptyMenu();
            menu.AddGroup(GetGroupName());
            menu.AddItemToGroup(menu.Groups[0].Id, GetItemName());

            return menu;
        }

        internal static Menu GetInactiveMenu() => GetReadyToActivateMenu();

        internal static Menu GetActiveMenu()
        {
            var menu = GetReadyToActivateMenu();
            menu.Activate(GetMenuRepository());

            return menu;
        }
        
        internal static Menu GetEmptyMenu() => Menu.Create(GetRestaurantId(), GetMenuInternalName(), GetMenuRepository());

        internal static Group GetEmptyGroup() => Group.Create(GetGroupName());

        internal static Item GetItem() => Item.Create(GetItemName());
    }
}