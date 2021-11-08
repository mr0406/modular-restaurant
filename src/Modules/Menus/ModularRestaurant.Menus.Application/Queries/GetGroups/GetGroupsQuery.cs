using System;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Queries.GetGroups
{
    public record GetGroupsQuery(Guid MenuId) : IQuery<GetGroupsQueryResult>;
}