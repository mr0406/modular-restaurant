using System.Collections.Generic;
using System.Linq;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Menus.Domain.Rules.Menus
{
    public class ActiveMenuMustHaveAtLeastOneGroup : IBusinessRule
    {
        private readonly List<Group> _groups;
        
        public ActiveMenuMustHaveAtLeastOneGroup(List<Group> groups)
        {
            _groups = groups;
        }

        public bool IsBroken() => _groups is null || !_groups.Any();

        public string Message => "Menu must have at least one group.";
    }
}