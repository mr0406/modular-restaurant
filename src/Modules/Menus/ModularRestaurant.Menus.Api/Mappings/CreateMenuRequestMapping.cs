using ModularRestaurant.Menus.Api.Requests;
using ModularRestaurant.Menus.Application.Commands;
using ModularRestaurant.Menus.Application.Commands.CreateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Mappings
{
    public static class CreateMenuRequestMapping
    {
        public static CreateMenuCommand ToCommand(this CreateMenuRequest request)
            => new CreateMenuCommand(request.RestaurantId, MapGroups(request.Groups));

        private static IEnumerable<CreateMenuCommand.Group> MapGroups(IEnumerable<CreateMenuRequest.Group> groups)
            => groups.Select(x => new CreateMenuCommand.Group(x.Name, MapItems(x.Items)));

        private static IEnumerable<CreateMenuCommand.Item> MapItems(IEnumerable<CreateMenuRequest.Item> items)
            => items.Select(x => new CreateMenuCommand.Item(x.Name));
    }
}
