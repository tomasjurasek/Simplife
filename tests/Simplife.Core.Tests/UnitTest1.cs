using Microsoft.Extensions.DependencyInjection;
using Simplife.Core.Tests.Structures;

namespace Simplife.Core.Tests
{
    public class UnitTest1
    {
        private readonly ServiceCollection _serviceCollection;

        public UnitTest1()
        {
            _serviceCollection = new ServiceCollection();
            

        }
        [Fact]
        public void Test1()
        {
            _serviceCollection.AddSimplife();
            var paymentAggregate = new PaymentAggregate(Guid.NewGuid(), 10, "CZ");

            paymentAggregate.ChangeAmount(20);
        }
    }
}