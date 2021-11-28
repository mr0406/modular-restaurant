using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularRestaurant.Menus.Application.Services;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.CleanUnusedItemImages
{
    public class CleanUpUnusedItemImagesCommandHandler : ICommandHandler<CleanUpUnusedItemImagesCommand, Unit>
    {
        private readonly IMenuItemImageService _menuItemImageService;

        public CleanUpUnusedItemImagesCommandHandler(IMenuItemImageService menuItemImageService)
        {
            _menuItemImageService = menuItemImageService;
        }
        
        public async Task<Unit> Handle(CleanUpUnusedItemImagesCommand request, CancellationToken cancellationToken)
        {
            await _menuItemImageService.CleanUpUnusedImages();
            
            return Unit.Value;
        }
    }
}