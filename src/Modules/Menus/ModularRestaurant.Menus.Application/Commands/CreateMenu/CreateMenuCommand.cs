using ModularRestaurant.Shared.Application.CQRS;
using System;

namespace ModularRestaurant.Menus.Application.Commands.CreateMenu
{
    public record CreateMenuCommand(Guid RestaurantId, string InternalName) : ICommand<Guid>;
}