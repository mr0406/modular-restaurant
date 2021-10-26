using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.DTOs
{
    public class MenuDTO
    {
        public IEnumerable<GroupDTO> Groups { get; set; }
    }
}