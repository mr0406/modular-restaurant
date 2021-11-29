using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    public class RemoveItemImageTests
    {
        [Test]
        public void RemoveItemImage_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetReadyToActivateMenu();

            menu.RemoveItemImage(menu.Groups[0].Id, menu.Groups[0].Items[0].Id);

            menu.Groups[0].Items[0].Image.Should().BeNull();
        }
        
        [Test]
        public void RemoveItemImage_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();

            Action action = () => menu.RemoveItemImage(menu.Groups[0].Id, menu.Groups[0].Items[0].Id);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }
    }
}