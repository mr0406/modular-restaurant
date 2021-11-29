using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    public class ChangeItemImageTests
    {
        [Test]
        public void ChangeItemImage_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetReadyToActivateMenu();
            var newImage = "newImage";
            
            menu.ChangeItemImage(menu.Groups[0].Id, menu.Groups[0].Items[0].Id, newImage);

            menu.Groups[0].Items[0].Image.Should().Be(newImage);
        }
        
        [Test]
        public void ChangeItemImage_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var newImage = "newImage";
            
            Action action = () => menu.ChangeItemImage(menu.Groups[0].Id, menu.Groups[0].Items[0].Id, newImage);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }
    }
}