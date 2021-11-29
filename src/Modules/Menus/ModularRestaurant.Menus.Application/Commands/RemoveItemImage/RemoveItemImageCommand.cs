using System;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.RemoveItemImage
{
    public record RemoveItemImageCommand(Guid MenuId, Guid GroupId, Guid ItemId) : ICommand<Unit>;
}