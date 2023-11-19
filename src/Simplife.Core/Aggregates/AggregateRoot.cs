using Simplife.Core.Events;

namespace Simplife.Core.Aggregates
{
    public abstract class AggregateRoot : AggregateRoot<Guid> { }

    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        protected AggregateRoot() { }

        protected List<IEvent> _uncommittedEvents = new();

        public IReadOnlyList<IEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

        public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

        public TKey Id { get; protected set; } = default;

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        protected virtual void Raise(IEvent @event)
        {
            _uncommittedEvents.Add(@event);
        }
    }
}
