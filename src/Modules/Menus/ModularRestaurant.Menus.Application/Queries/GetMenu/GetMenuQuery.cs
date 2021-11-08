using System;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Queries.GetMenu
{
    public record GetMenuQuery(Guid Id) : IQuery<GetMenuQueryResult>;
}