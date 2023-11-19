﻿using Simplife.Core.Aggregates;
using Simplife.Core.Events;

namespace Simlife.EventSourcing.Aggregates
{
    public abstract class AggregateRoot : AggregateRoot<Guid> { }

    public abstract class AggregateRoot<TKey> : Simplife.Core.Aggregates.AggregateRoot<TKey>, IAggregateRoot<TKey>
    {
        public long Version { get; private set; }

        public void Apply(IList<IEvent> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        override protected void Raise(IEvent @event)
        {
            Mutate(@event);
            _uncommittedEvents.Add(@event);
        }

        private void Mutate(IEvent @event)
        {
            Version++;
            ((dynamic)this).Apply((dynamic)@event);
        }
    }
}
