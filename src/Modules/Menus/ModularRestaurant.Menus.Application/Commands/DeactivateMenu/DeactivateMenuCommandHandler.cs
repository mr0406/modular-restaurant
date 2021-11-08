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
        private readonly IMenuRepository _menuRepository;

        public DeactivateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(DeactivateMenuCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);

            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);
            
            menu.Deactivate();
            
            return Unit.Value;
        }
    }
}