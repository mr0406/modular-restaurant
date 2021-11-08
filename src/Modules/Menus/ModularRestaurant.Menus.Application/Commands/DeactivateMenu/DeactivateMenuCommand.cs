using System;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.DeactivateMenu
{
    public record DeactivateMenuCommand(Guid MenuId) : ICommand<Unit>;
}