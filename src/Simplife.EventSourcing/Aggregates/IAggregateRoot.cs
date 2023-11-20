
using Simplife.Core.Events;

namespace Simplife.EventSourcing.Aggregates
{
    public interface IAggregateRoot : IAggregateRoot<Guid> { }

    public interface IAggregateRoot<TKey> : Core.Aggregates.IAggregateRoot<TKey>
    {
        long Version { get; }

        void Rehydrate(IList<IEvent> events);
    }
}
