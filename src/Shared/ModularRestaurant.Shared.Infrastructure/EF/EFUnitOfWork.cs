using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Infrastructure.MsSql
{
    public class EFUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _dbContext;

        public EFUnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
