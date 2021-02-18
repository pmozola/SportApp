using MediatR;
using SportApp.Domain.BaseObjects;
using System;

namespace SportApp.Domain
{
    public class Weight : Entity, IAggregateRoot
    {
        public Weight()
        {
        }

        public Weight(int userId, double value, DateTime date)
        {
            UserId = userId;
            Value = value;
            Date = date;
            this.AddDomainEvent(new UserWeightAddedDomainEvent(userId, value, Date));
        }

        public int UserId { get; private set; }
        public double Value { get; private set; }
        public DateTime Date { get; private set; }
    }

    public record UserWeightAddedDomainEvent(int UserId, double Value, DateTime date) : INotification { }
}
