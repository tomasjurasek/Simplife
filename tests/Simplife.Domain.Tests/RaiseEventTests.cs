using FluentAssertions;
using Simplife.Domain.Tests.Structures;

namespace Simplife.Domain.Tests
{
    public class RaiseEventTests
    {

        [Fact]
        public void RaiseEvent()
        {
            var paymentAggregate = new PaymentAggregate(Guid.NewGuid(), 10, "CZ");

            paymentAggregate.ChangeAmount(20);
            var events = paymentAggregate.GetUncommittedEvents();
            var empty = paymentAggregate.GetUncommittedEvents();

            events.Should().HaveCount(1);
            empty.Should().HaveCount(0);
        }
    }
}