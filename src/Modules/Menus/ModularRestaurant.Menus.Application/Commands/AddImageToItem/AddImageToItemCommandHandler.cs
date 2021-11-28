using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.AddImageToItem
{
    public class AddImageToItemCommandHandler : ICommandHandler<AddImageToItemCommand, Unit>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuItemImageService _menuItemImageService;

        public AddImageToItemCommandHandler(IMenuRepository menuRepository, IMenuItemImageService menuItemImageService)
        {
            _menuRepository = menuRepository;
            _menuItemImageService = menuItemImageService;
        }
        
        public async Task<Unit> Handle(AddImageToItemCommand command, CancellationToken cancellationToken)
        {
            var validContentTypes = new List<string> {"image/png", "image/jpeg"};

            if (command.Image is null)
                throw new ArgumentNullException(nameof(command.Image));

            if (!validContentTypes.Contains(command.Image.ContentType))
                throw new UnsupportedFileFormatException(command.Image.ContentType, validContentTypes);

            var imageName = GetImageName(command.Image.FileName);
            
            var menuId = new MenuId(command.MenuId);
            var groupId = new GroupId(command.GroupId);
            var itemId = new ItemId(command.ItemId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);
            
            await _menuItemImageService.SaveImage(imageName, command.Image);
            
            menu.AddImageToItem(groupId, itemId, imageName);
            
            return Unit.Value;
        }

        private string GetImageName(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var fileExtension = fileName[dotIndex..];

            return Guid.NewGuid() + fileExtension;
        }
    }
}