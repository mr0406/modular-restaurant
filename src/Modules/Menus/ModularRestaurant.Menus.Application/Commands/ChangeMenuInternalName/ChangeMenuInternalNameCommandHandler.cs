using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeMenuInternalName
{
    public class ChangeMenuInternalNameCommandHandler : ICommandHandler<ChangeMenuInternalNameCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;
        
        public ChangeMenuInternalNameCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(ChangeMenuInternalNameCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);
            
            menu.ChangeInternalName(request.NewInternalName, _menuRepository);
            
            return Unit.Value;
        }
    }
}