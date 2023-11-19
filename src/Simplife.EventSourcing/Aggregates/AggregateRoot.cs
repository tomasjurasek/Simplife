using Simplife.Domain.Events;

namespace Simlife.EventSourcing.Aggregates
{
    public abstract class AggregateRoot<TKey> : Simplife.Domain.Aggregates.AggregateRoot<TKey>
    {
        public AggregateRoot() : base() { }

        private List<IEvent> _uncommittedEvents = new();

        public IReadOnlyList<IEvent> GetUncommittedEvents => _uncommittedEvents.AsReadOnly();

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
