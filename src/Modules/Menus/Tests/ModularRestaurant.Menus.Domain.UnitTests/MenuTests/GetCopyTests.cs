using System;
using System.Linq;
using FluentAssertions;
using ModularRestaurant.Menus.Domain.Rules.Restaurants;
using ModularRestaurant.Shared.Domain.Exceptions;
using NUnit.Framework;

namespace ModularRestaurant.Menus.Domain.UnitTests.MenuTests
{
    [TestFixture]
    public class GetCopyTests
    {
        [Test]
        public void GetCopy_WithCorrectNewInternalName_IsSuccessful()
        {
            var menuRepository = Provider.GetMenuRepository();
            var newInternalName = "newInternalName";
            var menu = Provider.GetActiveMenu();
            
            var menuCopy = menu.GetCopy(newInternalName, menuRepository);

            menuCopy.Should().NotBeNull();
            menuCopy.InternalName.Should().Be(newInternalName);
            menuCopy.IsActive.Should().BeFalse();
            menuCopy.Should().BeEquivalentTo(menu, x => x.Excluding(x => x.Id)
                                                         .Excluding(x => x.Groups)
                                                         .Excluding(x => x.InternalName)
                                                         .Excluding(x => x.IsActive));
            menuCopy.Groups.Select(x => x.Name).Should().Equal(menu.Groups.Select(x => x.Name));
            menuCopy.Groups.SelectMany(x => x.Items).Select(x => x.Name).Should()
                .Equal(menu.Groups.SelectMany(x => x.Items).Select(x => x.Name));
            
            menuCopy.Groups.Should().BeEquivalentTo(menu.Groups, x => x.Excluding(x => x.Id)
                                                                       .Excluding(x => x.Items));
            
            menuCopy.Groups.SelectMany(x => x.Items).Should()
                .BeEquivalentTo(menu.Groups.SelectMany(x => x.Items), x => x.Excluding(x => x.Id));
        }

        [Test]
        public void GetCopy_NameIsNotUnique_IsNotPossible()
        {
            var menuRepository = Provider.GetMenuRepositoryWithNameConflict();
            var newInternalName = "newInternalName";
            var menu = Provider.GetActiveMenu();
            
            
            Action action = () => menu.GetCopy(newInternalName, menuRepository);

            action.Should().Throw<BusinessRuleException>()
                .Where(x => x.BrokenRule is InternalNameMustBeUniqueInRestaurantMenusRule);
        }
    }
}