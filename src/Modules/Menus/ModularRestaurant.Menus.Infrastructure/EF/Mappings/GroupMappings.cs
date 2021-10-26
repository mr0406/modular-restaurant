using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ModularRestaurant.Menus.Infrastructure.EF.Mappings
{
    public static class GroupMappings
    {
        public static GroupDTO ToDTO(this Group group)
        {
            return new GroupDTO()
            {
                Name = group.Name,
                Items = group.Items?.ToDTOs()
            };
        }

        public static IEnumerable<GroupDTO> ToDTOs(this IEnumerable<Group> groups)
        {
            return groups.Select(ToDTO);
        }
    }
}