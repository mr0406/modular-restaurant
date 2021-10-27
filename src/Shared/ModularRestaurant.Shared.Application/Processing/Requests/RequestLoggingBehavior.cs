using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace ModularRestaurant.Shared.Application.Processing.Requests
{
    public class RequestLoggingBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        private readonly ILogger _logger;

        public RequestLoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            try
            {
                var result = await next();
                _logger.Information($"{request.GetType().Name} executed successfully.");
                return result;
            }
            catch (Exception)
            {
                _logger.Error($"{request.GetType().Name} executed unsuccessfully.");
                throw;
            }
        }
    }
}