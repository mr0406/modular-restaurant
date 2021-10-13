using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Requests
{
    public record CreateGroupRequest
    {
        public Guid MenuId { get; init; }
        public string GroupName { get; init; }

        public CreateGroupRequest(Guid menuId, string groupName)
        {
            MenuId = menuId;
            GroupName = groupName;
        }
    }
}
