using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class DeactivateTests
    {
        [Test]
        public void Deactivate_WhenMenuIsActive_IsSuccessful()
        {
            var menu = Provider.GetActiveMenu();
            
            menu.Deactivate();
            
            menu.IsActive.Should().BeFalse();
        }

        [Test]
        public void Deactivate_WhenMenuIsInactive_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();

            Action action = () => menu.Deactivate();

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotDeactivateInactiveMenuRule);
        }
    }
}