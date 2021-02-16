using SportApp.Domain.BaseObjects;

namespace SportApp.Domain.Workout.WorkoutAggregate
{
    public class Workout : Entity, IAggregateRoot
    {
        public Workout()
        { }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
