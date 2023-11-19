namespace Simplife.Domain.Events
{
    public interface IEvent
    {
        public string Id { get; }

        public long Version { get; }
    }
}
