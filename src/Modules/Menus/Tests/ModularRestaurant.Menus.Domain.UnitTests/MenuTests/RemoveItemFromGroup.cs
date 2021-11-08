using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class RemoveItemFromGroup
    {
        [Test]
        public void RemoveItemFromGroup_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemsCountBeforeDeletion = menu.Groups[0].Items.Count;
            var itemId = menu.Groups[0].Items[0].Id;
            
            menu.RemoveItemFromGroup(groupId, itemId);
            
            var itemsCountAfterDeletion = menu.Groups[0].Items.Count;
            itemsCountAfterDeletion.Should().Be(itemsCountBeforeDeletion - 1);
        }

        [Test]
        public void RemoveItemFromGroup_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemId = menu.Groups[0].Items[0].Id;

            Action action = () => menu.RemoveItemFromGroup(groupId, itemId);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void RemoveItemFromGroup_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();

            Action action = () => menu.RemoveItemFromGroup(groupId, itemId);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
        
        [Test]
        public void RemoveItemFromGroup_WhenItemNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupName = Provider.GetGroupName();
            menu.AddGroup(groupName);
            var groupId = menu.Groups[0].Id;
            var itemId = Provider.GetItemId();
            
            Action action = () => menu.RemoveItemFromGroup(groupId, itemId);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Item));
        }
    }
}