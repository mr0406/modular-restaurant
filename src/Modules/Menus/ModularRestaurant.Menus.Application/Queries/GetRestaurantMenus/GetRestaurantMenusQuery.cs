using System;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Queries.GetRestaurantMenus
{
    public record GetRestaurantMenusQuery(Guid RestaurantId) : IQuery<GetRestaurantMenusQueryResult>;
}