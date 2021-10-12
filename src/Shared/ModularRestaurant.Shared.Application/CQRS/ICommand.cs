using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.CQRS
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }

    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
