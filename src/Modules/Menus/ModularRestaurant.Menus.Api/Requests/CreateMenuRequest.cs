using MediatR;
using ModularRestaurant.Menus.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Api.Requests
{
    public record CreateMenuRequest
    {
        public IEnumerable<Group> Groups { get; init; }

        public CreateMenuRequest(IEnumerable<Group> groups)
        {
            Groups = groups;
        }

        public record Group(string Name, IEnumerable<Item> Items);

        public record Item(string Name);
    }

}
