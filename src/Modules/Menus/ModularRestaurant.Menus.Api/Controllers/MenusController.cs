using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using ModularRestaurant.Menus.Application.Commands.AddImageToItem;
using ModularRestaurant.Menus.Application.Commands.ChangeActiveMenu;
using ModularRestaurant.Menus.Application.Commands.ChangeGroups;
using ModularRestaurant.Menus.Application.Commands.ChangeItems;
using ModularRestaurant.Menus.Application.Commands.ChangeMenuInternalName;
using ModularRestaurant.Menus.Application.Commands.CreateMenu;
using ModularRestaurant.Menus.Application.Commands.DeactivateMenu;
using ModularRestaurant.Menus.Application.Queries.GetGroups;
using ModularRestaurant.Menus.Application.Queries.GetItems;
using ModularRestaurant.Menus.Application.Queries.GetMenu;
using ModularRestaurant.Menus.Application.Queries.GetRestaurantMenus;
using ModularRestaurant.Shared.Domain.Exceptions;

namespace ModularRestaurant.Menus.Api.Controllers
{
    public class MenusController : MenusControllerBase
    {
        public MenusController(IMenusExecutor executor) : base(executor)
        {
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetMenuQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetMenuQueryResult>> GetMenu([FromRoute] Guid id)
            => Ok(await Executor.ExecuteQuery(new GetMenuQuery(id)));
        
        [HttpGet("restaurant/{restaurantId:guid}")]
        [ProducesResponseType(typeof(GetRestaurantMenusQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetRestaurantMenusQueryResult>> GetRestaurantMenus([FromRoute] Guid restaurantId)
            => Ok(await Executor.ExecuteQuery(new GetRestaurantMenusQuery(restaurantId)));
        
        [HttpGet("{menuId:Guid}/groups")]
        [ProducesResponseType(typeof(GetGroupsQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetGroupsQueryResult>> GetGroups([FromRoute] Guid menuId)
            => Ok(await Executor.ExecuteQuery(new GetGroupsQuery(menuId)));
        
        [HttpGet("{menuId:Guid}/groups/{groupId:Guid}/items")]
        [ProducesResponseType(typeof(GetItemsQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetItemsQueryResult>> GetItems([FromRoute] Guid menuId, [FromRoute] Guid groupId)
            => Ok(await Executor.ExecuteQuery(new GetItemsQuery(menuId, groupId)));
        
        [HttpPost("create")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> CreateMenu([FromBody] CreateMenuCommand command)
            => Ok(await Executor.ExecuteCommand(command));
        
        [HttpPost("change-internal-name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> ChangeMenuInternalName([FromBody] ChangeMenuInternalNameCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("change-active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> ChangeActiveMenu([FromBody] ChangeActiveMenuCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> DeactivateMenu([FromBody] DeactivateMenuCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Unit>> ChangeGroups([FromBody] ChangeGroupsCommand command)
            => Ok(await Executor.ExecuteCommand(command));
        
        [HttpPost("items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Unit>> ChangeItems([FromBody] ChangeItemsCommand command)
            => Ok(await Executor.ExecuteCommand(command));

        [HttpPost("{menuId:Guid}/groups/{groupId:Guid}/items/{itemId:Guid}/image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status415UnsupportedMediaType)]
        public async Task<ActionResult<Unit>> AddImageToItem([FromRoute] Guid menuId, [FromRoute] Guid groupId, 
            [FromRoute] Guid itemId, [FromForm] IFormFile image)
            => Ok(await Executor.ExecuteCommand(new AddImageToItemCommand(menuId, groupId, itemId, image)));
    }
}