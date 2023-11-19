
using Simplife.Core.Events;
using Simplife.Domain.Events;

namespace Simplife.Domain.Aggregates
{
    public abstract class AggregateRoot : AggregateRoot<Guid> { }

    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        protected AggregateRoot() { }

        public TKey Id { get; protected set; } = default;

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public long Version { get; protected set; }

        protected virtual void Raise(IEvent @event)
        {
            EventDispatcher.Dispatch(@event);
        }
    }
}
