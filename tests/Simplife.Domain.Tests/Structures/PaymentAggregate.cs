using Simplife.Domain.Aggregates;

namespace Simplife.Domain.Tests.Structures
{
    internal class PaymentAggregate : AggregateRoot
    {
        public PaymentAggregate(Guid id, decimal amount, string currency)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public void ChangeAmount(decimal amount)
        {
            // TODO Validation, etc,...
            Amount = amount;

            Raise(new PaymentAmountChanged
            {
                AggregateId = Id.ToString(),
                Amount = Amount
            });
        }
    }
}
