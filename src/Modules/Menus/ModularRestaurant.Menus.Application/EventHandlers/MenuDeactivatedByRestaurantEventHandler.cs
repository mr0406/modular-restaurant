using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Events;
using ModularRestaurant.Menus.Domain.Repositories;

namespace ModularRestaurant.Menus.Application.EventHandlers
{
    public class MenuDeactivatedByRestaurantEventHandler : INotificationHandler<MenuDeactivatedByRestaurantEvent>
    {
        private readonly IMenuRepository _menuRepository;

        public MenuDeactivatedByRestaurantEventHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task Handle(MenuDeactivatedByRestaurantEvent notification, CancellationToken cancellationToken)
        {
            var menuToDeactivate = await _menuRepository.GetActiveMenu(notification.RestaurantId, cancellationToken);

            if (menuToDeactivate is null || menuToDeactivate.Id != notification.DeactivatedMenuId)
            {
                throw new Exception();
            }

            menuToDeactivate.Deactivate();
        }
    }
}