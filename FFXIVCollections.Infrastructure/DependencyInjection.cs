using FFXIVCollections.Infrastructure.Persistance.MemoryRepository;
using FFXIVCollections.Infrastructure.Services;
using FFXIVCollectors.Application.Common.Interfaces;
using FFXIVCollectors.Application.Common.Interfaces.Persistance;
using FFXIVCollectors.Application.Common.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FFXIVCollections.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var opts = new FinalFantasyCollectionConfiguration();
            var ffClollectionSection = configuration.GetSection(nameof(FinalFantasyCollectionConfiguration));
            ffClollectionSection.Bind(opts);
            services.AddSingleton(opts);

            services.AddTransient<IFinalFantasyCollectionService, FinalFantasyCollectionService>();

            services.AddMemoryPersistanceLayer();
            return services;
        }

        private static void AddMemoryPersistanceLayer(this IServiceCollection services)
        {
            //Singleton to keep in memory data loaded for every request
            services.AddSingleton<IMinionRepository, MinionRepository>();
            services.AddSingleton<IMountRepository, MountRepository>();
            services.AddSingleton<IProfileRepository, ProfileRepository>();
            services.AddSingleton<IRepositoryContext, MemoryRepositoryContext>();
        }
    }
}
