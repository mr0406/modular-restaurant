using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Restaurants;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class CreateTests
    {
        [Test]
        public void Create_WithCorrectData_IsSuccessful()
        {
            var restaurantGuid = new Guid("FE14A582-57B2-4538-82A0-09284FDD016E");
            var restaurantId = new RestaurantId(restaurantGuid);
            var internalName = "INTERNAL_NAME";
            var checker = Provider.GetUniquenessCheckerWhichPass();

            var menu = Menu.Create(restaurantId, internalName, checker);

            menu.Should().NotBeNull();
            menu.InternalName.Should().Be(internalName);
            menu.RestaurantId.Should().BeEquivalentTo(restaurantId);
            menu.IsActive.Should().BeFalse();
        }

        [Test]
        public void Create_InternalNameIsNotUnique_IsNotPossible()
        {
            var internalName = Provider.GetMenuInternalName();
            var restaurantId = Provider.GetRestaurantId();
            var checker = Provider.GetUniquenessCheckerWhichFails();
            
            Action action = () => Menu.Create(restaurantId, internalName, checker);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is InternalNameMustBeUniqueInRestaurantMenusRule);
        }
    }
}