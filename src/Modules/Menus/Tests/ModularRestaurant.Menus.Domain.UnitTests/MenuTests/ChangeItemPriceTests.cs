using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Items;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.ValueObjects;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class ChangeItemPriceTests
    {
        public void ChangeItemPrice_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemId = menu.Groups[0].Items[0].Id;
            var newItemPrice = Money.Create(1, "XYZ");

            menu.ChangeItemPrice(groupId, itemId, newItemPrice);

            menu.Groups[0].Items[0].Price.Should().Be(newItemPrice);
        }

        [Test]
        public void ChangeItemPrice_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemPrice = Provider.GetItemPrice();

            Action action = () => menu.ChangeItemPrice(groupId, itemId, newItemPrice);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void ChangeItemPrice_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemPrice = Provider.GetItemPrice();

            Action action = () => menu.ChangeItemPrice(groupId, itemId, newItemPrice);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
        
        [Test]
        public void ChangeItemPrice_WhenItemNotExists_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var newItemPrice = Money.Create(1, "ABC");

            Action action = () => menu.ChangeItemPrice(groupId, itemId, newItemPrice);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Item));
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-666.66)]
        public void ChangeItemPrice_WhenItemPriceIsLessThanOrEqualToZero_IsNotPossible(decimal itemPriceValue)
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var wrongItemPrice = Money.Create(itemPriceValue, "AAA");

            Action action = () => menu.ChangeItemPrice(groupId, itemId, wrongItemPrice);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is ItemPriceMustBeGreaterThanZeroRule);
        }
    }
}