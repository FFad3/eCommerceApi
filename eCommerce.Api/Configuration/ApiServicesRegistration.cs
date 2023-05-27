using eCommerceApp.Application;
using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Identity;
using eCommerceApp.Infrastructure;
using eCommerceApp.Infrastructure.Services;
using eCommerceApp.Persistence;

namespace eCommerce.Api.Configuration
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllers();

            services.AddSwagger();

            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.RegisterSettings(configuration);
            services.RegisterApplication();
            services.RegisterInfrastructure(configuration);
            services.RegisterPersistance(configuration);
            services.RegisterIdentity(configuration);

            return services;
        }
    }
}