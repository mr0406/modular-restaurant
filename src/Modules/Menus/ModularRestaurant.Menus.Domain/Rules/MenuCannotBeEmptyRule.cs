using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Menus.Domain.Rules
{
    internal class MenuCannotBeEmptyRule : IBusinessRule
    {
        public string Message => "Menu cannot contain 0 groups";

        private readonly List<Group> _groups;

        internal MenuCannotBeEmptyRule(List<Group> groups)
        {
            _groups = groups;
        }

        public bool IsBroken()
        {
            return _groups is null || !_groups.Any();
        }
    }
}