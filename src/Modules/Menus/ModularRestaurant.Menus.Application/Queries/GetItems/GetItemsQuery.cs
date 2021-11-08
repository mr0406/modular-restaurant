using System;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Queries.GetItems
{
    public record GetItemsQuery(Guid MenuId, Guid GroupId) : IQuery<GetItemsQueryResult>;
}