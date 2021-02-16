using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp.Domain.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportApp.Infrastructure
{
    public class DomainEventDispacher : IDomainEventDispacher
    {
        private readonly IPublisher publisher;

        public DomainEventDispacher(IPublisher publisher)
        {
            this.publisher = publisher;
        }

        public async Task Dispach(DbContext ctx, CancellationToken cancellationToken)
        {
            var domainEntities = ctx.ChangeTracker
                   .Entries<IEntity>()
                   .Where(x => x.Entity.DomainEvents != null &&
                               x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await publisher.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                });

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
