using Simplife.Core.Events;

namespace Simplife.Core.Tests.Structures
{
    public record PaymentAmountChanged : IEvent
    {
        public decimal Amount { get; init; }

        public string Id { get; init; }
    }
}
