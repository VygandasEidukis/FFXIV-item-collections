using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FFXIVCollectors.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
