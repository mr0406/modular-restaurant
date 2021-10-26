using System.Collections.Generic;

namespace ModularRestaurant.Menus.Application.DTOs
{
    public class GroupDTO
    {
        public string Name { get; set; }

        public IEnumerable<ItemDTO> Items { get; set; }
    }
}