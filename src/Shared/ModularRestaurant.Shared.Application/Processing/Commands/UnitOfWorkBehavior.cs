using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Commands
{
    public class UnitOfWorkBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            var result = await next();

            await _unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}