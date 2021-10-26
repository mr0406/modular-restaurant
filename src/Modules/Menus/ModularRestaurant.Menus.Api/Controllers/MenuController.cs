using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Menus.Application.Commands.CreateGroup;
using ModularRestaurant.Menus.Application.DTOs;
using ModularRestaurant.Menus.Application.Queries;
using ModularRestaurant.Shared.Api;
using System;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Application.Commands.CreateMenu;

namespace ModularRestaurant.Menus.Api.Controllers
{
    public class MenuController : MenusControllerBase
    {
        public MenuController(IMenusExecutor executor) : base(executor)
        {
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MenuDTO>> GetMenu([FromRoute] Guid id)
        {
            return Ok(await Executor.ExecuteQuery(new GetMenuQuery(id)));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> CreateMenu([FromBody] CreateMenuCommand command)
        {
            return Ok(await Executor.ExecuteCommand(command));
        }

        [HttpPost("create/group")]
        public async Task<ActionResult<Unit>> CreateGroupCommand([FromBody] CreateGroupCommand command)
        {
            return Ok(await Executor.ExecuteCommand(command));
        }
    }
}