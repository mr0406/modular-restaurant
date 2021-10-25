using System.Threading.Tasks;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Ratings.Api
{
    public interface IRatingsExecutor
    {
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
        
        Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command);
    }
}