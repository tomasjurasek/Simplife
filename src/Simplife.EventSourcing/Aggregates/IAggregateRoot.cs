
using Simplife.Domain.Events;

namespace Simplife.EventSourcing.Aggregates
{
    public interface IAggregateRoot : IAggregateRoot<Guid> { }

    public interface IAggregateRoot<TKey> : Domain.Aggregates.IAggregateRoot<TKey>
    {
        long Version { get; }

        void Rehydrate(IList<IEvent> events);
    }
}
