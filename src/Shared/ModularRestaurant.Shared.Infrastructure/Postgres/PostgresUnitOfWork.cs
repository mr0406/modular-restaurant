using Microsoft.EntityFrameworkCore;
using ModularRestaurant.Shared.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Infrastructure.Postgres
{
    public class PostgresUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        //private readonly T _dbContext;

        /*public PostgresUnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }*/

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            //await _dbContext.SaveChangesAsync();
            Debug.WriteLine("---------------");
            Debug.WriteLine("FROM UnitOfWork");
            Debug.WriteLine("---------------");
        }
    }
}
