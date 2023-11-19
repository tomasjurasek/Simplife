﻿using Simplife.Domain.Events;

namespace Simlife.EventSourcing.Aggregates
{
    public abstract class AggregateRoot<TKey> : Simplife.Domain.Aggregates.AggregateRoot<TKey>
    {
        private List<IEvent<TKey>> _uncommittedEvents = new();

        public IReadOnlyList<IEvent<TKey>> GetUncommittedEvents => _uncommittedEvents.AsReadOnly();

        public void Apply(IList<IEvent<TKey>> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        protected void Raise(IEvent<TKey> @event)
        {
            Mutate(@event);
            _uncommittedEvents.Add(@event);
        }

        private void Mutate(IEvent<TKey> @event)
        {
            Version++;
            ((dynamic)this).Apply((dynamic)@event);
        }
    }
}
