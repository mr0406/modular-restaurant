using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using ModularRestaurant.Shared.Domain.ValueObjects;

namespace ModularRestaurant.Menus.Application.Commands.ChangeItems
{
    public class ChangeItemsCommandHandler : ICommandHandler<ChangeItemsCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;

        public ChangeItemsCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(ChangeItemsCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);

            var groupId = new GroupId(request.GroupId);

            if (request.ItemsToRemove?.Ids is not null)
            {
                RemoveItems(request.ItemsToRemove, menu, groupId);
            }

            if (request.ItemsToAdd?.Items is not null)
            {
                AddItems(request.ItemsToAdd, menu, groupId);
            }

            if (request.ItemsToUpdate?.Items is not null)
            {
                UpdateItems(request.ItemsToUpdate, menu, groupId);
            }

            return Unit.Value;
        }

        private static void RemoveItems(ItemsToRemove itemsToRemove, Menu menu, GroupId groupId)
        {
            foreach (var itemIdToRemove in itemsToRemove.Ids)
            {
                var itemId = new ItemId(itemIdToRemove);
                menu.RemoveItemFromGroup(groupId, itemId);
            } 
        }

        private static void AddItems(ItemsToAdd itemsToAdd, Menu menu, GroupId groupId)
        {
            foreach (var itemToAdd in itemsToAdd.Items)
            {
                var itemPrice = Money.Create(itemToAdd.PriceValue, itemToAdd.PriceCurrency);
                menu.AddItemToGroup(groupId, itemToAdd.Name, itemToAdd.Description, itemPrice);
            }
        }

        private static void UpdateItems(ItemsToUpdate itemsToUpdate, Menu menu, GroupId groupId)
        {
            foreach (var itemToUpdate in itemsToUpdate.Items)
            {
                var itemId = new ItemId(itemToUpdate.Id);
                if (itemToUpdate.NewPriceCurrency != null && itemToUpdate.NewPriceValue != null)
                {
                    var itemPrice = Money.Create(itemToUpdate.NewPriceValue.Value, itemToUpdate.NewPriceCurrency);
                    menu.ChangeItemPrice(groupId, itemId, itemPrice);
                }

                if (itemToUpdate.NewName != null)
                {
                    menu.ChangeItemName(groupId, itemId, itemToUpdate.NewName);
                }

                if (itemToUpdate.NewDescription != null)
                {
                    menu.ChangeItemDescription(groupId, itemId, itemToUpdate.NewDescription);
                }
            }
        }
    }
}