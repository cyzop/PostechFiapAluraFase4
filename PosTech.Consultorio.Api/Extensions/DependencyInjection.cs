using PosTech.Consultorio.Controllers.Extensions;
using PosTech.Consultorio.Gateways.Extensions;
using PosTech.Consultorio.Resource.NoSql.Extensions;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddRepositories(configuration);

            services.AddGateways(configuration);

            services.AddCleanArchitectureControllers(configuration);
            
            return services;
        }

        
    }
}
