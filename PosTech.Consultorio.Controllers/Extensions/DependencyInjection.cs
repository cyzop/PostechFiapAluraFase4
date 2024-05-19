using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Consultorio.Interfaces.Controller;

namespace PosTech.Consultorio.Controllers.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCleanArchitectureControllers(this IServiceCollection services, IConfiguration configuration)
        {
            //AddControllers
            services.AddScoped<IPacienteController, PacienteController>();
            services.AddScoped<IMedicoController, MedicoController>();
            services.AddScoped<IAtendimentoController, AtendimentoController>();

            return services;
        }
    }
}
