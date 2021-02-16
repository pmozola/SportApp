using MediatR;

namespace SportApp.Domain.Athlete.AthleteSessionAggregate.Events
{
    public record AthleteSessionCompletedDomainEvent(int athleteId, int sessionId) : INotification;
}
