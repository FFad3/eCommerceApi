using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            return services;
        }
    }
}