using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class RemoveGroupTests
    {
        [Test]
        public void RemoveGroup_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetEmptyMenu();
            var groupName = Provider.GetGroupName();
            menu.AddGroup(groupName);
            var groupId = menu.Groups[0].Id;
            
            menu.RemoveGroup(groupId);

            menu.Groups.Should().BeEmpty();
        }

        [Test]
        public void RemoveGroup_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupId = Provider.GetGroupId();

            Action action = () => menu.RemoveGroup(groupId);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void RemoveGroup_WhenGroupDoNotExists_IsNotPossible()
        {
            var menu = Provider.GetInactiveMenu();
            var groupId = Provider.GetGroupId();
            
            Action action = () => menu.RemoveGroup(groupId);

            action.Should().Throw<ObjectNotFoundException>()
                .Where(x => x.Type == typeof(Group));
        }
    }
}