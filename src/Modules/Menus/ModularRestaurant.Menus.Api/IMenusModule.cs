using System.Threading.Tasks;
using ModularRestaurant.Shared.Application.CQRS;

namespace ModularRestaurant.Menus.Api
{
    public interface IMenusModule
    {
        Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
        
        Task<TResult> ExecuteCommand<TResult>(ICommand<TResult> command);
    }
}