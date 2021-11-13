using System;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Types;
using ModularRestaurant.Shared.Domain.ValueObjects;
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

        internal static string GetItemDescription() => "itemDescription";

        internal static Money GetItemPrice() => Money.Create(123, "XXX");

        internal static Guid GetItemGuid() => new("1263C7A0-BA1C-4EB2-89D0-661622BC1731");

        internal static ItemId GetItemId() => new(GetItemGuid());

        internal static IMenuInternalNameUniquenessChecker GetUniquenessCheckerWhichPass()
        {
            var mock = new Mock<IMenuInternalNameUniquenessChecker>();
            mock.Setup(x => x.CheckIsUnique(It.IsAny<RestaurantId>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            return mock.Object;
        }

        internal static IMenuInternalNameUniquenessChecker GetUniquenessCheckerWhichFails()
        {
            var mock = new Mock<IMenuInternalNameUniquenessChecker>();
            mock.Setup(x => x.CheckIsUnique(It.IsAny<RestaurantId>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            return mock.Object;
        }
        
        internal static Menu GetReadyToActivateMenu()
        {
            var menu = GetEmptyMenu();
            menu.AddGroup(GetGroupName());
            menu.AddItemToGroup(menu.Groups[0].Id, GetItemName(), GetItemDescription(), GetItemPrice());

            return menu;
        }

        internal static Menu GetInactiveMenu() => GetReadyToActivateMenu();

        internal static Menu GetActiveMenu()
        {
            var menu = GetReadyToActivateMenu();
            var menuRepository = GetMenuRepository(menu);

            var service = new MenuActivityService(menuRepository);
            service.ChangeActive(It.IsAny<RestaurantId>(), It.IsAny<MenuId>());
            
            return menu;
        }

        internal static IMenuRepository GetMenuRepository(Menu getAsyncMenu, Menu getActiveMenu = null)
        {
            var repository = new Mock<IMenuRepository>();
            
            repository.Setup(x => x.GetAsync(It.IsAny<MenuId>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(getAsyncMenu));
            
            repository.Setup(x => x.GetActiveMenuInRestaurant(It.IsAny<RestaurantId>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(getActiveMenu));

            return repository.Object;
        }
        
        internal static Menu GetEmptyMenu() => Menu.Create(GetRestaurantId(), GetMenuInternalName(), 
            GetUniquenessCheckerWhichPass());
        
        
        internal static Group GetEmptyGroup() => Group.Create(GetGroupName());

        internal static Item GetItem() => Item.Create(GetItemName(), GetItemDescription(), GetItemPrice());
    }
}