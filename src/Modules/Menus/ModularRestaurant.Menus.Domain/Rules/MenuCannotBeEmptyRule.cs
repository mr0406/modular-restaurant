using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Domain.Rules
{
    public class MenuCannotBeEmptyRule : IBusinessRule
    {
        private readonly List<Group> _groups;

        internal MenuCannotBeEmptyRule(List<Group> groups)
        {
            _groups = groups;
        }

        public bool IsBroken() => _groups is null || !_groups.Any();

        public string Message => "Menu cannot contain 0 groups";
    }
}
