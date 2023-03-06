using eCommerceApp.Application.Contracts.Persistence;
using eCommerceApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection RegisterPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION") ?? configuration.GetConnectionString("eCommerceDb"),
                    sqlServerOptionsAction: sqloptions =>
                    {
                        sqloptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}