using System;
using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.Queries.GetMenu
{
    public record GetMenuQueryResult
    {
        public IEnumerable<Group> Groups { get; init; }

        public record Group(Guid Id, string Name, IEnumerable<Item> Items);

        public record Item(Guid Id, string Name, string Description, decimal PriceValue, string PriceCurrecy);
    }
}