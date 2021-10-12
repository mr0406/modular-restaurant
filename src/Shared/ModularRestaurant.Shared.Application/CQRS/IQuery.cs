using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.CQRS
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
