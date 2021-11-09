using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace ModularRestaurant.Menus.Application.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Guid>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IRestaurantRepository restaurantRepository)
        {
            _menuRepository = menuRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);

            var menu = Menu.Create(restaurantId, request.InternalName, _restaurantRepository);

            await _menuRepository.AddAsync(menu, cancellationToken);

            return menu.Id.Value;
        }
    }
}