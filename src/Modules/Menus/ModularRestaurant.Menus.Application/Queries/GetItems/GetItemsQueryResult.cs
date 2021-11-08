using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.Queries.GetItems
{
    public record GetItemsQueryResult
    {
        public IEnumerable<Item> Items { get; init; }

        public record Item(string Name);
    }
}