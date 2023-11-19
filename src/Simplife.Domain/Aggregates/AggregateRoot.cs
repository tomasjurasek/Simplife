
namespace Simplife.Domain.Aggregates
{
    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        public AggregateRoot() { }

        public AggregateRoot(TKey id, DateTimeOffset createdAt, DateTimeOffset updatedAt, long version)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
        }

        public TKey Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public long Version { get; protected set; }
    }
}
