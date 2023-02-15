using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}