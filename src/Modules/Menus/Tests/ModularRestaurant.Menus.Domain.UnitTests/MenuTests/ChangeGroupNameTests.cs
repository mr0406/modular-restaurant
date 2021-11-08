using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Groups;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class ChangeGroupNameTests
    {
        [Test]
        public void ChangeGroupName_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetReadyToActivateMenu();
            var groupId = menu.Groups[0].Id;
            var newGroupName = "New_Group_Name";
            
            menu.ChangeGroupName(groupId, newGroupName);

            menu.Groups[0].Id.Should().Be(groupId);
            menu.Groups[0].Name.Should().Be(newGroupName);
        }

        [Test]
        public void ChangeGroupName_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = menu.Groups[0].Id;
            var newGroupName = "New_Group_Name";
            
            Action action = () => menu.ChangeGroupName(groupId, newGroupName);
            
            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void ChangeGroupName_WhenNewNameIsNotUnique_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var existingGroupName = menu.Groups[0].Name;
            var addingGroupName = "group_tp_add_name";
            menu.AddGroup(addingGroupName);
            var addedGroupId = menu.Groups[1].Id;

            //TODO: Return Id when adding
            Action action = () => menu.ChangeGroupName(addedGroupId, existingGroupName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is GroupNameMustBeUniqueRule);
        }
        
        [Test]
        public void ChangeGroupName_WhenGroupNotExists_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupId = Provider.GetGroupId();
            var newGroupName = "NewName";
            
            Action action = () => menu.ChangeGroupName(groupId, newGroupName);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
    }
}