using SportApp.Domain.Athlete.AthleteSessionAggregate.Events;
using SportApp.Domain.BaseObjects;
using System;

namespace SportApp.Domain.Athlete.AthleteWorkoutSessionAggregate
{
    public class AthleteSession: Entity, IAggregateRoot
    {
        public int AthleteId { get; set; }
        public DateTime Date { get; set; }
        public int SessionId  { get; set; }
        public bool IsCompleted { get; private set; }

        public void CompleteSession()
        {
            this.IsCompleted = true;
            this.AddDomainEvent(new AthleteSessionCompletedDomainEvent(this.AthleteId, this.SessionId));
        }
    }
}
