using ModularRestaurant.Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Application.Commands
{
    public record CreateMenuCommand : ICommand<Guid>
    {
        public IEnumerable<Group> Groups { get; init; }

        public CreateMenuCommand(IEnumerable<Group> groups)
        {
            Groups = groups;
        }

        public record Group(string Name, IEnumerable<Item> Items);

        public record Item(string Name);
    }

    public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Guid>
    {
        public async Task<Guid> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Guid.NewGuid());
        }
    }
}
