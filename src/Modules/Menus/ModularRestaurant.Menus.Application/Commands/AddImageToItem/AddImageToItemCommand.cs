using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.AddImageToItem
{
    public record AddImageToItemCommand(Guid MenuId, Guid GroupId, Guid ItemId, 
        IFormFile Image) : ICommand<Unit>;
}