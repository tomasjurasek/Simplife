using Simplife.Core.Tests.Structures;

namespace Simplife.Core.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var paymentAggregate = new PaymentAggregate(Guid.NewGuid(), 10, "CZ");

            paymentAggregate.ChangeAmount(20);
        }
    }
}