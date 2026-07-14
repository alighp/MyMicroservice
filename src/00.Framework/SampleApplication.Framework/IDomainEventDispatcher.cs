using Microsoft.Extensions.DependencyInjection;

namespace SampleApplication.Framework
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IReadOnlyList<IDomainEvent> events);
    }
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _service;

        public DomainEventDispatcher(IServiceProvider service)
        {
            _service = service;
        }
        public Task Dispatch(IReadOnlyList<IDomainEvent> events)
        {
            foreach (dynamic @event in events)
            {
                DispatchEvent(@event);
            }
            return Task.CompletedTask;
        }
        private Task DispatchEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        {
            var handlers = _service.GetServices<IDomainEventHandler<TDomainEvent>>();

            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(@event);
                }
            }
            return Task.CompletedTask;

        }
    }
}
