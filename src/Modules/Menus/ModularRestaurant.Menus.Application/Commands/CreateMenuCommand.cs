using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Commands
{
    public record CreateMenuCommand : ICommand<Guid>
    {
        public Guid RestaurantId { get; init; }
        public IEnumerable<Group> Groups { get; init; }

        public CreateMenuCommand(Guid restaurantId, IEnumerable<Group> groups)
        {
            RestaurantId = restaurantId;
            Groups = groups;
        }

        public record Group(string Name, IEnumerable<Item> Items);

        public record Item(string Name);
    }

    public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Guid>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new RestaurantId(request.RestaurantId);

            var groups = request.Groups.Select(x => Group.CreateNew(x.Name, x.Items.Select(i => Item.CreateNew(i.Name)).ToList())).ToList();

            var menu = Menu.CreateNew(restaurantId, groups);

            await _menuRepository.AddAsync(menu);

            return menu.Id.Value;
        }
    }
}
