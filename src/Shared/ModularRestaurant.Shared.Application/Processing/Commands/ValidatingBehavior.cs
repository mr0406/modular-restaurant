using MediatR;
using ModularRestaurant.Shared.Application.CQRS;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application.Processing.Commands
{
    public class ValidatingBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        /*private readonly IEnumerable<IValidator<TCommand>> _validators;

        public ValidatingBehavior(IEnumerable<IValidator<TCommand>> validators)
        {
            _validators = validators;
        }*/

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResult> next)
        {
            /*var context = new ValidationContext<TCommand>(command);

            var errors = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Count != 0)
            {
                throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
            }*/

            return await next();
        }
    }
}