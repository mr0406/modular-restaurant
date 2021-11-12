using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeActiveMenu
{
    public class ChangeActiveMenuCommandHandler : ICommandHandler<ChangeActiveMenuCommand, Unit>
    {
        private readonly IMenuActivityService _menuActivityService;

        public ChangeActiveMenuCommandHandler(IMenuActivityService menuActivityService)
        {
            _menuActivityService = menuActivityService;
        }

        public async Task<Unit> Handle(ChangeActiveMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);
            var menuId = new MenuId(request.NewActiveMenuId);

            await _menuActivityService.ChangeActive(restaurantId, menuId);
            
            return Unit.Value;
        }
    }
}