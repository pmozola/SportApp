using System.Threading.Tasks;

namespace SportApp.Domain.Athlete.WeightAggregate
{
    public interface IWeightRepository
    {
        Task Add(Weight weight);
    }
}
