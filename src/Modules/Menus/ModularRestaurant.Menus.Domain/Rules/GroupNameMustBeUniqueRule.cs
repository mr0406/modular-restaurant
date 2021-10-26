using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules
{
    public class GroupNameMustBeUniqueRule : IBusinessRule
    {
        private readonly List<Group> _groups;
        private readonly string _groupName;

        internal GroupNameMustBeUniqueRule(List<Group> groups, string groupName)
        {
            _groups = groups;
            _groupName = groupName;
        }

        public bool IsBroken()
        {
            return _groups.Any(x => x.Name == _groupName);
        }

        public string Message => "Group name must be unique";
    }
}