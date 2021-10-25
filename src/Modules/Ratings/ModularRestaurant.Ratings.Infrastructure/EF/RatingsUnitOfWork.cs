using ModularRestaurant.Ratings.Application.Processing;
using ModularRestaurant.Shared.Infrastructure.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Infrastructure.EF
{
    public class RatingsUnitOfWork : EFUnitOfWork<RatingsDbContext>, IRatingsUnitOfWork
    {
        public RatingsUnitOfWork(RatingsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
