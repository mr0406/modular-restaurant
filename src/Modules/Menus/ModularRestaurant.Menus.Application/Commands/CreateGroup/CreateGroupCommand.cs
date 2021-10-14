using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ModularRestaurant.Menus.Application.Commands.CreateGroup
{
    public record CreateGroupCommand : ICommand<Unit>
    {
        public Guid MenuId { get; init; }
        public string GroupName { get; init; }

        public CreateGroupCommand(Guid menuId, string groupName)
        {
            MenuId = menuId;
            GroupName = groupName;
        }
    }
}
