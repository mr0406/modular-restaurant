using System;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeMenuInternalName
{
    public record ChangeMenuInternalNameCommand(Guid MenuId, string NewInternalName) : ICommand<Unit>;
}