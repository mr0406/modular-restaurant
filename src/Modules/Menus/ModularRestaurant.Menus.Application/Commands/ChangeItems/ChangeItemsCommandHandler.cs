using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
                foreach (var itemIdToRemove in request.ItemsToRemove.Ids)
                {
                    var itemId = new ItemId(itemIdToRemove);
                    menu.RemoveItemFromGroup(groupId, itemId);
                } 
            }

            if (request.ItemsToAdd?.Items is not null)
            {
                foreach (var itemToAdd in request.ItemsToAdd.Items)
                {
                    var itemPrice = Money.Create(itemToAdd.PriceValue, itemToAdd.PriceCurrency);
                    menu.AddItemToGroup(groupId, itemToAdd.Name, itemToAdd.Description, itemPrice);
                }   
            }

            if (request.ItemsToUpdate?.Items is not null)
            {
                foreach (var itemToUpdate in request.ItemsToUpdate.Items)
                {
                    var itemId = new ItemId(itemToUpdate.Id);
                    var itemPrice = Money.Create(itemToUpdate.NewPriceValue, itemToUpdate.NewPriceCurrency);
                    menu.ChangeItemName(groupId, itemId, itemToUpdate.NewName);
                    menu.ChangeItemDescription(groupId, itemId, itemToUpdate.NewDescription);
                    menu.ChangeItemPrice(groupId, itemId, itemPrice);
                }   
            }

            return Unit.Value;
        }
    }
}