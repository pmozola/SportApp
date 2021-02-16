using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportApp.Infrastructure
{
    public interface IDomainEventDispacher
    {
        Task Dispach(DbContext ctx, CancellationToken cancellationToken);
    }
}
