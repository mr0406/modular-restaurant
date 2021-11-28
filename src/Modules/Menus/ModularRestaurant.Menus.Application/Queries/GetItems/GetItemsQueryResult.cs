using System;
using System.Collections.Generic;
using ModularRestaurant.Shared.Domain.ValueObjects;

namespace ModularRestaurant.Menus.Application.Queries.GetItems
{
    public record GetItemsQueryResult
    {
        public IEnumerable<Item> Items { get; init; }

        public record Item(Guid Id, string Name, string Description, decimal PriceValue, string PriceCurrency);
    }
}