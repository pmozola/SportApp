using SportApp.Application;
using SportApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDomainEventDispacher domainEventDispacher;
        private readonly SportAppDbContext dbContext;

        public UnitOfWork(IDomainEventDispacher domainEventDispacher, SportAppDbContext dbContext)
        {
            this.domainEventDispacher = domainEventDispacher;
            this.dbContext = dbContext;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await domainEventDispacher.Dispach(dbContext, cancellationToken);

            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
