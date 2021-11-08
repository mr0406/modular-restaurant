using System;
using System.Collections.Generic;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeItems
{
    public record ChangeItemsCommand(Guid MenuId, Guid GroupId, ItemsToAdd ItemsToAdd = null,
        ItemsToUpdate ItemsToUpdate = null, ItemsToRemove ItemsToRemove = null) : ICommand<Unit>;

    public record ItemsToAdd(List<string> Names);

    public record ItemsToUpdate(List<UpdateItem> Items);

    public record UpdateItem(Guid Id, string NewName);

    public record ItemsToRemove(List<Guid> Ids);
}