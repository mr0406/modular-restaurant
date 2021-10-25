using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularRestaurant.Ratings.Application;
using ModularRestaurant.Ratings.Domain;
using ModularRestaurant.Ratings.Infrastructure;
using ModularRestaurant.Shared.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Ratings.Api
{
    public class RatingsExecutor : IRatingsExecutor
    {
        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            await using (var scope = RatingsCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }

        public async Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command)
        {
            await using (var scope = RatingsCompositionRoot.BeginLifeTimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(command);
            }
        }
    }
}
