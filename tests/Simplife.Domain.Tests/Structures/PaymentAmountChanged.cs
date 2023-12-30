using Simplife.Domain.Events;

namespace Simplife.Domain.Tests.Structures
{
    public record PaymentAmountChanged : IEvent
    {
        public decimal Amount { get; init; }

        public string AggregateId { get; init; }

        public DateTimeOffset OccurredAt { get; init; } = DateTimeOffset.UtcNow;
    }
}
