using ModularRestaurant.Menus.Domain.Rules;
using ModularRestaurant.Shared.Domain;
using ModularRestaurant.Shared.Domain.Common;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Menu : AggregateRoot<MenuId>
    {
        public RestaurantId RestaurantId { get; private set; }

        public IReadOnlyList<Group> Groups => _groups;
        private List<Group> _groups = new();

        private Menu(RestaurantId restaurantId)
        {
            Id = new MenuId(Guid.NewGuid());
            RestaurantId = restaurantId;
        }

        public static Menu CreateNew(RestaurantId restaurantId)
        {
            return new Menu(restaurantId);
        }

        public void AddGroup(string groupName)
        {
            CheckRule(new GroupNameMustBeUniqueRule(_groups, groupName));

            _groups.Add(Group.CreateNew(groupName));
        }

        public void EditGroups(List<Group> groups)
        {
            CheckRule(new MenuCannotBeEmptyRule(groups));

            _groups = groups;
        }

        private Menu() { }
    }
}
