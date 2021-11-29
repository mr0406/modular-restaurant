using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.RemoveItemImage
{
    public class RemoveItemImageCommandHandler : ICommandHandler<RemoveItemImageCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;
        
        public RemoveItemImageCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(RemoveItemImageCommand command, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(command.MenuId);
            var groupId = new GroupId(command.GroupId);
            var itemId = new ItemId(command.ItemId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);

            menu.RemoveItemImage(groupId, itemId);
            
            return Unit.Value;
        }
    }
}