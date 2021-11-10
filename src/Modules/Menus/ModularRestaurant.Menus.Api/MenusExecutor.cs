using System.Threading.Tasks;
using Autofac;
using MediatR;
using ModularRestaurant.Menus.Infrastructure;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Infrastructure;

namespace ModularRestaurant.Menus.Api
{
    public class MenusExecutor : IMenusExecutor
    {
        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            await using (var scope = MenusCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }

        public async Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command)
        {
            await using (var scope = MenusCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(command);
            }
        }
    }
}