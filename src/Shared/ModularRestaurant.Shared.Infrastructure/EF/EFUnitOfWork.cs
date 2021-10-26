using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Application;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Infrastructure.MsSql
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        
        public EFUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}