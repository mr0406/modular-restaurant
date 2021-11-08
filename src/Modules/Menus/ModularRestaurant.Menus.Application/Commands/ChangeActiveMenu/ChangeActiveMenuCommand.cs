using System;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeActiveMenu
{
    public record ChangeActiveMenuCommand(Guid RestaurantId, Guid NewActiveMenuId) : ICommand<Unit>;
}