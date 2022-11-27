using SS.Application.Interfaces.Common;
using SS.Shared.Events;

namespace SS.Application.Interfaces.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}