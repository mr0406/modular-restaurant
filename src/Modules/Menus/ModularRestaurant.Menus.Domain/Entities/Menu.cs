using ModularRestaurant.Menus.Domain.Rules;
using ModularRestaurant.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Menu : Entity
    {
        public IReadOnlyList<Group> groups => _groups;
        private List<Group> _groups = new List<Group>();

        private Menu(List<Group> groups)
        {
            _groups = groups;
        }

        public static Menu CreateNew(List<Group> groups)
        {
            CheckRule(new MenuCannotBeEmptyRule(groups));

            return new Menu(groups);
        }

        public void EditGroups(List<Group> groups)
        {
            CheckRule(new MenuCannotBeEmptyRule(groups));

            _groups = groups;
        }
    }
}
