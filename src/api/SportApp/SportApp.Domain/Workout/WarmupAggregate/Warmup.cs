using SportApp.Domain.BaseObjects;

namespace SportApp.Domain.Workout.WarmupAggregate
{
    public class Warmup : Entity, IAggregateRoot
    {
        string Name { get; set; }

        string Description { get; set; }

        public VideoUrl Url { get; set; }
    }
}
