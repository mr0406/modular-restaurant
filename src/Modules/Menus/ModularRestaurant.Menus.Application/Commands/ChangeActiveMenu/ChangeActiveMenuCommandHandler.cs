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
        private readonly IMenuRepository _menuRepository;

        public ChangeActiveMenuCommandHandler(IRestaurantRepository restaurantRepository, IMenuRepository menuRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuRepository = menuRepository;
        }

        public async Task<Unit> Handle(ChangeActiveMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menuId = new MenuId(request.NewActiveMenuId);
            
            var restaurant = await _restaurantRepository.GetAsync(restaurantId, cancellationToken);
            
            restaurant.ChangeActiveMenu(menuId, _menuRepository);

            return Unit.Value;
        }
    }
}