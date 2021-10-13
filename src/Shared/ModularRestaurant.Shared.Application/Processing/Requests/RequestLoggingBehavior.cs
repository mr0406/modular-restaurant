using MediatR;
using Microsoft.Extensions.Logging;
using ModularRestaurant.Shared.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Requests
{
    public class RequestLoggingBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        private readonly ILogger<RequestLoggingBehavior<TRequest, TResult>> _logger;

        public RequestLoggingBehavior(ILogger<RequestLoggingBehavior<TRequest, TResult>> logger)
        {
            _logger = logger;
        }

        public async Task<TResult> Handle(TRequest reqeust, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            try
            {
                var result = await next();
                _logger.LogInformation($"{reqeust.GetType().Name} executed successfully.");
                return result;
            }
            catch (Exception)
            {
                _logger.LogError($"{reqeust.GetType().Name} executed unsuccessfully.");
                throw;
            }
        }
    }
}
