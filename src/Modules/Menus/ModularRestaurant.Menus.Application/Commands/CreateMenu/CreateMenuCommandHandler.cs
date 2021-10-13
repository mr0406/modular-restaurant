﻿using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Application;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Commands.CreateMenu
{
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

            await _menuRepository.AddAsync(menu, cancellationToken);

            return menu.Id.Value;
        }
    }
}