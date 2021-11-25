using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Application;

namespace ModularRestaurant.Shared.Infrastructure.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContextBase _dbContext;
        
        public EFUnitOfWork(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}