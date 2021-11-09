using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.DeactivateMenu
{
    public class DeactivateMenuCommandHandler : ICommandHandler<DeactivateMenuCommand, Unit>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuRepository _menuRepository;

        public DeactivateMenuCommandHandler(IRestaurantRepository restaurantRepository, IMenuRepository menuRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(DeactivateMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menuId = new MenuId(request.MenuId);

            var restaurant = await _restaurantRepository.GetAsync(restaurantId, cancellationToken);
            
            restaurant.DeactivateMenu(menuId, _menuRepository);

            return Unit.Value;
        }
    }
}