using System.Collections.Generic;

namespace SportApp.Domain.BaseObjects
{
    public interface IEntity
    {
        IReadOnlyList<object> DomainEvents { get; }
        void RemoveDomainEvent(object eventItem);
        void ClearDomainEvents();
    }
}
