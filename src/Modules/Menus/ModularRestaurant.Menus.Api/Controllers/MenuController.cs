using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Menus.Api.Mappings;
using ModularRestaurant.Menus.Api.Requests;
using ModularRestaurant.Menus.Application.Commands;
using ModularRestaurant.Menus.Application.Commands.CreateGroup;
using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Application.Queries;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Infrastructure.EF.Mappings;
using ModularRestaurant.Shared.Api;
using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ModularRestaurant.Menus.Api.Controllers
{
    public class MenuController : MenusControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MenuDTO>> GetMenu(Guid id)
            => throw new EntityNotFoundException(nameof(Menu), id);//OkOrNotFound(await Mediator.Send(new GetMenuQuery(id)));

        [HttpPost]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateMenu(CreateMenuRequest request)
            => Ok(await Mediator.Send(request.ToCommand()));
        public async Task<ActionResult<Guid>> CommandTest(CreateMenuRequest request)
            => OkOrNotFound(await Mediator.Send(request.ToCommand()));

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateGroupCommand(CreateGroupRequest request)
            => OkOrNotFound(await Mediator.Send(
                new CreateGroupCommand(
                    request.MenuId,
                    request.GroupName)));
    }
}
