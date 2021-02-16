using System.Threading.Tasks;

using SportApp.Domain;
using SportApp.Domain.Athlete.WeightAggregate;

namespace SportApp.Infrastructure.Repositories
{
    public class WeightRepository : IWeightRepository
    {
        private readonly SportAppDbContext dbContext;

        public WeightRepository(SportAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Add(Weight weight)
        {
            this.dbContext.AthleteWeights.AddAsync(weight);
            
            return Task.CompletedTask;
        }
    }
}
