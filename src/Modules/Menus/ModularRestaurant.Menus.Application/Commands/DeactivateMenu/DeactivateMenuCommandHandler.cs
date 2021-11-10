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

        public DeactivateMenuCommandHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        
        public async Task<Unit> Handle(DeactivateMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menuId = new MenuId(request.MenuId);

            var restaurant = await _restaurantRepository.GetAsync(restaurantId, cancellationToken);
            
            restaurant.DeactivateMenu(menuId);

            return Unit.Value;
        }
    }
}