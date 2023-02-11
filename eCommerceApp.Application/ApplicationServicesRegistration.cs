using eCommerceApp.Application.PipelineBehaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eCommerceApp.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly())
                .ConfigurePipeline();

            return services;
        }
    }
}