namespace Simplife.Domain.Events
{
    public interface IEvent<TAggregateId>
    {
        public TAggregateId Id { get; }

        public long Version { get; }
    }
}
