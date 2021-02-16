using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportApp.Application;
using SportApp.Domain;

namespace SportApp.Infrastructure
{
    public class SportAppDbContext : DbContext, IUnitOfWork
    {
        public SportAppDbContext(DbContextOptions<SportAppDbContext> options) : base(options)
        {
        }

        public DbSet<Weight> AthleteWeights { get; set; }
        public DbSet<Excercise> Excercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportAppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
