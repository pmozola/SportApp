using SportApp.Domain.BaseObjects;
using System.Collections.Generic;

namespace SportApp.Domain.Workout
{
    public class SessionAggregate: Entity, IAggregateRoot
    {
        public int WarmupId { get; set; }
        public List<int> WorkoutId { get; set; }
    }
}
