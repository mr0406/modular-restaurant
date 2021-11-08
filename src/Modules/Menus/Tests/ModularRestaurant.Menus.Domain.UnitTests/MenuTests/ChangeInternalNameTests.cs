using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Restaurants;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class ChangeInternalNameTests
    {
        [Test]
        public void ChangeInternalName_WhenDataIsCorrect_IsSuccessful()
        {
            var menuRepository = Provider.GetMenuRepository();
            var menu = Provider.GetActiveMenu();
            var newInternalName = "NewInternalName";
            
            menu.ChangeInternalName(newInternalName, menuRepository);

            menu.InternalName.Should().Be(newInternalName);
        }

        [Test]
        public void ChangeInternalName_WhenNewInternalNameIsNotUnique_IsNotPossible()
        {
            var menuRepository = Provider.GetMenuRepositoryWithNameConflict();
            var menu = Provider.GetActiveMenu();
            var newInternalName = "NewInternalName";
            
            Action action = () => menu.ChangeInternalName(newInternalName, menuRepository);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is InternalNameMustBeUniqueInRestaurantMenusRule);
        }
    }
}