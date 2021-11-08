using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeGroups
{
    public class ChangeGroupsCommandHandler : ICommandHandler<ChangeGroupsCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;

        public ChangeGroupsCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public async Task<Unit> Handle(ChangeGroupsCommand request, CancellationToken cancellationToken)
        {
            var menuId = new MenuId(request.MenuId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);

            if (request.GroupsToRemove?.Ids is not null)
            {
                foreach (var groupIdToRemove in request.GroupsToRemove.Ids)
                {
                    var groupId = new GroupId(groupIdToRemove);
                    menu.RemoveGroup(groupId);
                }
            }

            if (request.GroupsToAdd?.Names is not null)
            {
                foreach (var groupName in request.GroupsToAdd.Names)
                {
                    menu.AddGroup(groupName);
                }   
            }

            if (request.GroupsToUpdate?.Groups is not null)
            {
                foreach (var groupToUpdate in request.GroupsToUpdate.Groups)
                {
                    var groupId = new GroupId(groupToUpdate.Id);
                    menu.ChangeGroupName(groupId, groupToUpdate.NewName);
                }   
            }

            return Unit.Value;
        }
    }
}