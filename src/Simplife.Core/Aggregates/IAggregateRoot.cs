
namespace Simplife.Core.Aggregates
{
    public interface IAggregateRoot<TKey>
    {
        public TKey Id { get; }

        public DateTimeOffset CreatedAt { get; }

        public DateTimeOffset UpdatedAt { get; }
    }
}
