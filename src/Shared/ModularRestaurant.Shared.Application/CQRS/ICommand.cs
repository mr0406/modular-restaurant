using MediatR;

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