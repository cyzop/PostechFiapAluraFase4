using PosTech.Consultorio.Controllers;
using PosTech.Consultorio.Gateways;
using PosTech.Consultorio.Interfaces;
using PosTech.Consultorio.Resource.NoSql;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            var repositorySettings = new MongoDbSettings(configuration);

            services.AddScoped<IDatabaseClient, DatabaseClientMongo>();
            services.AddScoped<IPacienteGateway, PacienteGateway>();
            services.AddScoped<PacienteController>();


            return services;
        }

        
    }
}
