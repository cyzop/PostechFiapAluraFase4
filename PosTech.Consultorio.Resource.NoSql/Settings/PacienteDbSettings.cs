using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class PacienteDbSettings : MongoDbSettings
    {
        const string sectionName = "PacienteDbSettings";

        public PacienteDbSettings(IConfiguration config)
        {
            var sessao = config.GetSection(sectionName);
            sessao.Bind(this);
        }
    }
}
