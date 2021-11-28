using System;
using System.Collections.Generic;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeItems
{
    public record ChangeItemsCommand(Guid MenuId, Guid GroupId, ItemsToAdd ItemsToAdd = null,
        ItemsToUpdate ItemsToUpdate = null, ItemsToRemove ItemsToRemove = null) : ICommand<Unit>;

    public record ItemsToAdd(List<AddItem> Items);

    public record AddItem(string Name, string Description, decimal PriceValue, string PriceCurrency);

    public record ItemsToUpdate(List<UpdateItem> Items);

    public record UpdateItem(Guid Id, string NewName, string NewDescription, decimal? NewPriceValue,
        string NewPriceCurrency);

    public record ItemsToRemove(List<Guid> Ids);
}