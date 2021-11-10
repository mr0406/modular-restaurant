using System.Threading.Tasks;
using ModularRestaurant.Shared.Application.CQRS;
using ModularRestaurant.Shared.Domain.Common;

namespace ModularRestaurant.Shared.Infrastructure
{
    public interface IModuleExecutor
    {
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);

        Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command);
    }
}