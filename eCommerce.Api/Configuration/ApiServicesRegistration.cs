using eCommerceApp.Application;
using eCommerceApp.Infrastructure;
using eCommerceApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.RegisterApplication();
            services.RegisterInfrastructure();
            services.RegisterPersistance(configuration);

            return services;
        }
    }
}