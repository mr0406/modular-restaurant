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
    public class ChangeItemDescriptionTests
    {
        private const int ItemDescriptionCharacterLimit = 500;
        
        [Test]
        public void ChangeItemDescription_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            var itemId = menu.Groups[0].Items[0].Id;
            var newItemDescription = "NEW_DESCRIPTION";
            
            menu.ChangeItemDescription(groupId, itemId, newItemDescription);

            menu.Groups[0].Items[0].Description.Should().Be(newItemDescription);
        }
        
        [Test]
        public void ChangeItemDescription_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemDescription = Provider.GetItemDescription();

            Action action = () => menu.ChangeItemDescription(groupId, itemId, newItemDescription);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void ChangeItemDescription_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var itemId = Provider.GetItemId();
            var newItemDescription = Provider.GetItemDescription();

            Action action = () => menu.ChangeItemDescription(groupId, itemId, newItemDescription);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
        
        [Test]
        public void ChangeItemDescription_WhenItemNotExists_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var newItemDescription = "test_description";

            Action action = () => menu.ChangeItemDescription(groupId, itemId, newItemDescription);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Item));
        }
        
        [Test]
        public void ChangeItemDescription_WhenItemDescriptionExceedsCharacterLimit_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = menu.Groups[0].Id;
            Guid itemGuid = new("D0D5B76D-1061-4C4C-81F2-13F8F2589FB0");
            var itemId = new ItemId(itemGuid);
            var tooLongDescription = new string('a', ItemDescriptionCharacterLimit + 1);

            Action action = () => menu.ChangeItemDescription(groupId, itemId, tooLongDescription);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is ItemDescriptionCannotExceedCharacterLimitRule);
        }
    }
}