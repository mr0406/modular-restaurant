using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Queries
{
    public class QueryLoggingBehavior<TQuery, TResult> : IPipelineBehavior<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        /*private readonly ILogger<QueryLoggingBehavior<TQuery, TResult>> _logger;

        public QueryLoggingBehavior(ILogger<QueryLoggingBehavior<TQuery, TResult>> logger)
        {
            _logger = logger;
        }*/

        public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            try
            {
                var result = await next();

                //_logger.LogInformation($"Query: {query.GetType().Name} - success");

                return result;
            }
            catch (Exception)
            {
                //_logger.LogError($"Query: {query.GetType().Name} - fail");
                throw;
            }
        }
    }
}
