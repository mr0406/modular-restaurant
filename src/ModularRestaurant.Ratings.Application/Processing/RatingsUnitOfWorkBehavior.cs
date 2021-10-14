using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Application.Processing.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Application.Processing
{
    public class RatingsUnitOfWorkBehavior<TCommand, TResult> : UnitOfWorkBehavior<IRatingsUnitOfWork, TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        public RatingsUnitOfWorkBehavior(IRatingsUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
