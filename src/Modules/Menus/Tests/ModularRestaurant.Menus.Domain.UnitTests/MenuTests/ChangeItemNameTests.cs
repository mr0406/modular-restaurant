using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Items;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class ChangeItemNameTests
    {
        [Test]
        public void ChangeItemName_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemId = menu.Groups[0].Items[0].Id;
            var newItemName = "NEW_NAME";

            menu.ChangeItemName(groupId, itemId, newItemName);

            menu.Groups[0].Items[0].Name.Should().Be(newItemName);
        }

        [Test]
        public void ChangeItemName_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemName = Provider.GetItemName();

            Action action = () => menu.ChangeItemName(groupId, itemId, newItemName);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void ChangeItemName_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemName = Provider.GetItemName();

            Action action = () => menu.ChangeItemName(groupId, itemId, newItemName);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
        
        [Test]
        public void ChangeItemName_WhenItemNotExists_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var newItemName = "test_name";

            Action action = () => menu.ChangeItemName(groupId, itemId, newItemName);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Item));
        }
        
        [Test]
        public void ChangeItemName_WhenItemNameIsNotUnique_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var existingItemName = menu.Groups[0].Items[0].Name;

            Action action = () => menu.ChangeItemName(groupId, itemId, existingItemName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is ItemNameMustBeUniqueRule);
        }
    }
}