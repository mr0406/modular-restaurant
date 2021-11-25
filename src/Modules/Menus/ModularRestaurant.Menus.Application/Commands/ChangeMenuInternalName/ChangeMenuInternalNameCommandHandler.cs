using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Services;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeMenuInternalName
{
    public class ChangeMenuInternalNameCommandHandler : ICommandHandler<ChangeMenuInternalNameCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuInternalNameUniquenessChecker _menuInternalNameUniquenessChecker;

        public ChangeMenuInternalNameCommandHandler(IMenuRepository menuRepository, IMenuInternalNameUniquenessChecker menuInternalNameUniquenessChecker)
        {
            _menuRepository = menuRepository;
            _menuInternalNameUniquenessChecker = menuInternalNameUniquenessChecker;
        }
        
        public async Task<Unit> Handle(ChangeMenuInternalNameCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);
            
            menu.ChangeInternalName(request.NewInternalName, _menuInternalNameUniquenessChecker);
            
            Thread.Sleep(1000);
            
            return Unit.Value;
        }
    }
}