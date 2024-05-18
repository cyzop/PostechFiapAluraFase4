using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class MedicoDbSettings : MongoDbSettings
    {
        const string sectionName = "MedicoDbSettings";
        public MedicoDbSettings(IConfiguration config)
        {
            var sessao = config.GetSection(sectionName);
            sessao.Bind(this);
        }
    }
}
