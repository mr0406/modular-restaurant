using System;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Groups;
using ModularRestaurant.Menus.Domain.Rules.Menus;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class AddGroupTests
    {
        [Test]
        public void AddGroup_WhenDataIsCorrect_IsSuccessful()
        {
            var menu = Provider.GetEmptyMenu();
            menu.AddGroup("1111");
            menu.AddGroup("2222");
            var groupName = "groupName";
            
            menu.AddGroup(groupName);

            menu.Groups.Should().Contain(x => x.Name == groupName);
        }

        [Test]
        public void AddGroup_WhenMenuIsActive_IsNotPossible()
        {
            var menu = Provider.GetActiveMenu();
            var groupName = Provider.GetGroupName();

            Action action = () => menu.AddGroup(groupName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is CannotChangeActiveMenuRule);
        }

        [Test]
        public void AddGroup_WhenGroupNameIsNotUnique_IsNotPossible()
        {
            var menu = Provider.GetEmptyMenu();
            var groupName = "groupName";
            menu.AddGroup(groupName);

            Action action = () => menu.AddGroup(groupName);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is GroupNameMustBeUniqueRule);
        }
    }
}