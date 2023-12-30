using Simplife.Domain.Events;

namespace Simplife.Domain.Aggregates
{
    public interface IAggregateRoot : IAggregateRoot<Guid> { }

    public interface IAggregateRoot<TKey>
    {
        public TKey Id { get; }

        public DateTimeOffset CreatedAt { get; }

        public DateTimeOffset UpdatedAt { get; }

        IEnumerable<IEvent> GetUncommittedEvents();
    }
}
