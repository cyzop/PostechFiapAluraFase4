using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PosTech.Consultorio.Controllers.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCleanArchitectureControllers(this IServiceCollection services, IConfiguration configuration)
        {
            //AddControllers
            services.AddScoped<PacienteController>();
            services.AddScoped<MedicoController>();
            services.AddScoped<AtendimentoController>();

            return services;
        }
    }
}
