using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Consultorio.Interfaces.Gateways;

namespace PosTech.Consultorio.Gateways.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGateways(this IServiceCollection services, IConfiguration configuration)
        {
            //AddGateways
            services.AddScoped<IPacienteGateway, PacienteGateway>();
            services.AddScoped<IMedicoGateway, MedicoGateway>();
            services.AddScoped<IAtendimentoMedicoGateway, AtendimentoMedicoGateway>();
            return services;
        }
    }
}
