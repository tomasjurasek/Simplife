using Microsoft.Extensions.DependencyInjection;
using Simplife.Core.Events;

namespace Simplife.Core
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
