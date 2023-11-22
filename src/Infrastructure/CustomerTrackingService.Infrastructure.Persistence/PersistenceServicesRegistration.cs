using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CustomerTrackingService.Infrastructure.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
