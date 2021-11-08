using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Items;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class AddItemToGroupTests
    {
        [Test]
        public void AddItemToGroup_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemName = "newItemName";
            var itemsCountBeforeAdd = menu.Groups[0].Items.Count;
            
            menu.AddItemToGroup(groupId, itemName);

            var itemsCountAfterAdd = menu.Groups[0].Items.Count;
            itemsCountBeforeAdd.Should().Be(itemsCountAfterAdd - 1);
        }

        [Test]
        public void AddItemToGroup_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = Provider.GetGroupId();
            var itemName = Provider.GetItemName();

            Action action = () => menu.AddItemToGroup(groupId, itemName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void AddItemToGroup_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var itemName = Provider.GetItemName();

            Action action = () => menu.AddItemToGroup(groupId, itemName);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
        
        [Test]
        public void AddItemToGroup_WhenItemNameIsNotUnique_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var existingItemName = menu.Groups[0].Items[0].Name; 
            
            Action action = () => menu.AddItemToGroup(groupId, existingItemName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is ItemNameMustBeUniqueRule);
        }
    }
}