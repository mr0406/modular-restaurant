using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Events;
using ModularRestaurant.Menus.Domain.Repositories;

namespace ModularRestaurant.Menus.Application.EventHandlers
{
    public class ActiveMenuChangedByRestaurantEventHandler : INotificationHandler<ActiveMenuChangedByRestaurantEvent>
    {
        private readonly IMenuRepository _menuRepository;

        public ActiveMenuChangedByRestaurantEventHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task Handle(ActiveMenuChangedByRestaurantEvent notification, CancellationToken cancellationToken)
        {
            var menuToDeactivate = await _menuRepository.GetActiveMenu(notification.RestaurantId, cancellationToken);
            menuToDeactivate?.Deactivate();

            var menuToActivate = await _menuRepository.GetAsync(notification.ActivatedMenuId, cancellationToken);
            menuToActivate.Activate();
        }
    }
}