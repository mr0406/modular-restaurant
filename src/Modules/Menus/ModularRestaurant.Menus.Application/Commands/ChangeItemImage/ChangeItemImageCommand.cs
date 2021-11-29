using System;
using Microsoft.AspNetCore.Http;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.ChangeItemImage
{
    public record ChangeItemImageCommand(Guid MenuId, Guid GroupId, Guid ItemId, 
        IFormFile NewImage) : ICommand<string>;
}