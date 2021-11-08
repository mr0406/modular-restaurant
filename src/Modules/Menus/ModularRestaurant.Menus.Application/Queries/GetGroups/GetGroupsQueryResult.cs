using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.Queries.GetGroups
{
    public record GetGroupsQueryResult
    {
        public IEnumerable<Group> Groups { get; init; }

        public record Group(string Name);
    }
}