using MediatR;

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