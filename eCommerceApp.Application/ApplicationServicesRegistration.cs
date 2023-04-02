using System.Reflection;
using eCommerceApp.Application.Models.Settings;
using eCommerceApp.Application.PipelineBehaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly())
                .ConfigurePipeline();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
        public static IServiceCollection RegisterSettings(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            return services;
        }
    }
}