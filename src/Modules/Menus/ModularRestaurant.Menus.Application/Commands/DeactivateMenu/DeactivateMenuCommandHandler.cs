using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.DeactivateMenu
{
    public class DeactivateMenuCommandHandler : ICommandHandler<DeactivateMenuCommand, Unit>
    {
        private readonly IMenuActivityService _menuActivityService;

        public DeactivateMenuCommandHandler(IMenuActivityService menuActivityService)
        {
            _menuActivityService = menuActivityService;
        }
        
        public async Task<Unit> Handle(DeactivateMenuCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);

            await _menuActivityService.Deactivate(menuId);

            return Unit.Value;
        }
    }
}