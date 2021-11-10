using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeActiveMenu
{
    public class ChangeActiveMenuCommandHandler : ICommandHandler<ChangeActiveMenuCommand, Unit>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public ChangeActiveMenuCommandHandler(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Unit> Handle(ChangeActiveMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menuId = new MenuId(request.NewActiveMenuId);
            
            var restaurant = await _restaurantRepository.GetAsync(restaurantId, cancellationToken);
            
            restaurant.ChangeActiveMenu(menuId);

            return Unit.Value;
        }
    }
}