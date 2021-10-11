using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Commands
{
    public class CommandLoggingBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        /*private readonly ILogger<CommandLoggingBehavior<TCommand, TResult>> _logger;

        public CommandLoggingBehavior(ILogger<CommandLoggingBehavior<TCommand, TResult>> logger)
        {
            _logger = logger;
        }*/

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            try
            {
                var result = await next();

                //_logger.LogInformation($"Command: {command.GetType().Name} - success");

                return result;
            }
            catch (Exception)
            {
                //_logger.LogError($"Command: {command.GetType().Name} - fail");
                throw;
            }
        }
    }
}
