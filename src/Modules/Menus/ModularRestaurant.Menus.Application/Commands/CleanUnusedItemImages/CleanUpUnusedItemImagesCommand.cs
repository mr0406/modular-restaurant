using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Application.Commands.CleanUnusedItemImages
{
    public record CleanUpUnusedItemImagesCommand : ICommand<Unit>;
}