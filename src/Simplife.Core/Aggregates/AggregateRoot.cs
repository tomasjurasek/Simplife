using Simplife.Core.Events;

namespace Simplife.Core.Aggregates
{
    public abstract class AggregateRoot : AggregateRoot<Guid> { }

    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        protected AggregateRoot() { }

        protected Queue<IEvent> _uncommittedEvents = new();

        public IEnumerable<IEvent> GetUncommittedEvents()
        {
            while (_uncommittedEvents.TryDequeue(out var @event))
            {
                yield return @event;
            }
        }

        public TKey Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        protected virtual void Raise(IEvent @event)
        {
            _uncommittedEvents.Enqueue(@event);
        }
    }
}
