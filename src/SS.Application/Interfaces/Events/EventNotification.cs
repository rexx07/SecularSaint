using MediatR;
using SS.Shared.Events;

namespace SS.Application.Interfaces.Events;

public class EventNotification<TEvent> : INotification
    where TEvent : IEvent
{
    public EventNotification(TEvent @event)
    {
        Event = @event;
    }

    public TEvent Event { get; }
}