using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class AtendimentoDbSettings : MongoDbSettings
    {
        const string sectionName = "AtendimentoDbSettings";
        public AtendimentoDbSettings(IConfiguration config)
        {
            var sessao = config.GetSection(sectionName);
            sessao.Bind(this);
        }
    }
}
