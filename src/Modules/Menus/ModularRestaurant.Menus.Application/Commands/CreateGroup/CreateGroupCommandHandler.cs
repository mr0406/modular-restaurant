using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;
        public CreateGroupCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);

            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);

            menu.AddGroup(request.GroupName);

            return Unit.Value;
        }
    }
}
