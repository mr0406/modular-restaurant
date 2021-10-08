using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Entities
{
    public class Menu
    {
        public IReadOnlyList<Group> groups => _groups;
        private List<Group> _groups = new List<Group>();

        private Menu()
        {

        }

        public static Menu CreateNew()
        {
            return new Menu();
        }

        public void AddGroup(string groupName)
        {
            var group = Group.CreateNew(groupName);
            _groups.Add(group);
        }

        public void AddItemToGroup(string groupName, string itemName)
        {
            var group = _groups.SingleOrDefault(x => x.Name == groupName);

            if(group is null)
            {
                throw new Exception();
            }

            group.AddItem(itemName);
        }
    }
}
