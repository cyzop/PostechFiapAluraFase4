using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Repositories;

namespace PosTech.Consultorio.Resource.NoSql.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //AddRepositories
            services.AddSingleton<IPatientRepository, PacienteRepositoryMongo>();
            services.AddSingleton<IMedicalDoctorRepository, MedicoRepositoryMongo>();
            services.AddSingleton<IMedicalCareRepository, AtendimentoRepositoryMongo>();

            return services;
        }
    }
}
