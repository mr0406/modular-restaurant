using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Commands
{
    public class UnitOfWorkBehavior<TUnitOfWork, TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
        where TCommand : ICommand<TResult> where TUnitOfWork : IUnitOfWork
    {
        private readonly TUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(TUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
        {
            var result = await next();

            await _unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
