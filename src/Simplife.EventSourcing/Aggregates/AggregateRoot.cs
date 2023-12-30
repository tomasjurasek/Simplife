using Simplife.Domain.Events;

namespace Simplife.EventSourcing.Aggregates
{
    public abstract class AggregateRoot : AggregateRoot<Guid> , IAggregateRoot
    { }

    public abstract class AggregateRoot<TKey> : Domain.Aggregates.AggregateRoot<TKey>, IAggregateRoot<TKey>
    {
        public long Version { get; private set; }

        public void Rehydrate(IList<IEvent> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        override protected void Raise(IEvent @event)
        {
            Mutate(@event);
            _uncommittedEvents.Enqueue(@event);
        }

        private void Mutate(IEvent @event)
        {
            Version++;
            this.Apply(@event);
        }
    }
}
