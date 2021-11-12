using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class ActivateTests
    {
        /*[Test]
        public void Activate_WhenDataIsCorrect_IsSuccessful()
        {
            var menuRepository = Provider.GetMenuRepositoryWithoutActiveMenu();
            var menu = Provider.GetReadyToActivateMenu();
            
            menu.Activate(menuRepository);

            menu.IsActive.Should().BeTrue();
        }

        [Test]
        public void Activate_WhenIsAlreadyActive_IsNotPossible()
        {
            var menuRepository = Provider.GetMenuRepository();
            var menu = Provider.GetActiveMenu();

            Action action = () => menu.Activate(menuRepository);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotActivateActiveMenuRule);
        }

        [Test]
        public void Activate_WhenMenuIsEmpty_IsNotPossible()
        {
            var menuRepository = Provider.GetMenuRepositoryWithoutActiveMenu();
            var menu = Provider.GetEmptyMenu();
            
            Action action = () => menu.Activate(menuRepository);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is ActiveMenuMustHaveAtLeastOneGroup);
        }*/
    }
}