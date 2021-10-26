using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Menus.Application.Queries
{
    public record GetMenuQuery(Guid Id) : IQuery<MenuDTO>;
}