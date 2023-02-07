using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Application.PipelineBehaviour
{
    internal static class PipelineConfiguration
    {
        internal static IServiceCollection ConfigureMediatRPipeline(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PereformenceBehaviour<,>));
            return services;
        }
    }
}