using SS.Shared.Events;

namespace SS.Domain.Contracts;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}