using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Application.Processing.Events
{
    public class AfterEventHandleSaveBehavior<TEvent> : IPipelineBehavior<TEvent, Unit>
        where TEvent : DomainEvent
    {
        private readonly DbContext _dbContext;
        
        public AfterEventHandleSaveBehavior(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(TEvent request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            await next();

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}