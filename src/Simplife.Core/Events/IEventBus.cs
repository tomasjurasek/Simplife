﻿using Microsoft.Extensions.DependencyInjection;

namespace Simplife.Core.Events
{
    public interface IEventBus
    {
        Task PublishAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken = default);
    }

    class InMemoryEventBus : IEventBus
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryEventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            foreach (var @event in events)
            {
                var eventHandlerType = typeof(IEventHandler<>)
                    .MakeGenericType(@event.GetType());

                foreach (var eventHandler in _serviceProvider.GetServices(eventHandlerType))
                {
                    var methodInfo = eventHandlerType.GetMethod(nameof(IEventHandler<IEvent>.HandleAsync));
                    await (Task)methodInfo!.Invoke(eventHandler, [@event, cancellationToken])!;
                }
            }
        }
    }
}
