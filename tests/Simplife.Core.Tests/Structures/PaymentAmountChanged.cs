using Simplife.Domain.Events;

namespace Simplife.Core.Tests.Structures
{
    public record PaymentAmountChanged : IEvent
    {
        public decimal Amount { get; init; }

        public string Id { get; init; }

        public long Version { get; init; }
    }
}
