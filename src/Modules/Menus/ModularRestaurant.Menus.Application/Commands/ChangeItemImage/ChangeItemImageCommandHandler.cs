using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Exceptions;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Application.Commands.ChangeItemImage
{
    public class ChangeItemImageCommandHandler : ICommandHandler<ChangeItemImageCommand, string>
    {
        private readonly List<string> _validContentTypes = new() {"image/png", "image/jpeg"};
        private const long MaxImageSizeInBytes = 10_000_000;

        private readonly IMenuRepository _menuRepository;
        private readonly IMenuItemImageService _menuItemImageService;

        public ChangeItemImageCommandHandler(IMenuRepository menuRepository, IMenuItemImageService menuItemImageService)
        {
            _menuRepository = menuRepository;
            _menuItemImageService = menuItemImageService;
        }
        
        public async Task<string> Handle(ChangeItemImageCommand command, CancellationToken cancellationToken)
        {
            if (command.NewImage is null)
                throw new ArgumentNullException(nameof(command.NewImage));

            if (!_validContentTypes.Contains(command.NewImage.ContentType))
                throw new UnsupportedFileFormatException(command.NewImage.ContentType, _validContentTypes);

            if (command.NewImage.Length > MaxImageSizeInBytes)
                throw new FileTooLargeException(command.NewImage.Length, MaxImageSizeInBytes);
            
            var imageName = GetImageName(command.NewImage.FileName);
            
            var menuId = new MenuId(command.MenuId);
            var groupId = new GroupId(command.GroupId);
            var itemId = new ItemId(command.ItemId);
            var menu = await _menuRepository.GetAsync(menuId, cancellationToken);
            
            await _menuItemImageService.SaveImage(imageName, command.NewImage);
            
            menu.ChangeItemImage(groupId, itemId, imageName);

            return imageName;
        }

        private string GetImageName(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var fileExtension = fileName[dotIndex..];

            return Guid.NewGuid() + fileExtension;
        }
    }
}