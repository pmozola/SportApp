using MediatR;
using SportApp.Domain.BaseObjects;

namespace SportApp.Domain
{
    public class Weight : Entity, IAggregateRoot
    {
        public Weight()
        {
        }

        public Weight(int userId, double value)
        {
            UserId = userId;
            Value = value;
            this.AddDomainEvent(new UserWeightAddedDomainEvent(userId, value));
        }

        public int UserId { get; private set; }
        public double Value { get; private set; }
    }

    public record UserWeightAddedDomainEvent(int UserId, double Value) : INotification { }
}
