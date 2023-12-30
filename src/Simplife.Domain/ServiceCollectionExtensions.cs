using Microsoft.Extensions.DependencyInjection;
using Simplife.Domain.Events;

namespace Simplife.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSimplife(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, InMemoryEventBus>();
            return services;
        }
    }
}
