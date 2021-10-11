using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Menus.Api.Mappings;
using ModularRestaurant.Menus.Api.Requests;
using ModularRestaurant.Menus.Application.Commands;
using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Application.Queries;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Infrastructure.EF.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Controllers
{
    public class MenuController : MenusControllerBase
    {
        private readonly IMenuRepository _menuRepository;
        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MenuDTO>> QueryTest(Guid id)
            => OkOrNotFound(await Mediator.Send(new GetMenuQuery(id)));

        [HttpPost]
        public async Task<ActionResult<Guid>> CommandTest(CreateMenuRequest request)
            => OkOrNotFound(await Mediator.Send(request.ToCommand()));
    }
}
