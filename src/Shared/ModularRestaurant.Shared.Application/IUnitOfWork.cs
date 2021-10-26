using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Application
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken token);
    }
}