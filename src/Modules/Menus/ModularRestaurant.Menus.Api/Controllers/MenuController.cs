using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<MenuDTO>> GetMenu([FromQuery] Guid id)
            => Ok(await Executor.ExecuteQuery(new GetMenuQuery(id)));

        [HttpPost("create")]
        [ProducesResponseType(typeof(MenuDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> CreateMenu([FromBody] CreateMenuCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("create/group")]
        public async Task<ActionResult<Unit>> CreateGroupCommand([FromBody] CreateGroupCommand command)
            => Ok(await Executor.ExecuteCommand(command));
    }
}
