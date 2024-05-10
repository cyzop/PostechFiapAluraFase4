using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Repository { get; set; }
        public string Secret { get; set; }

        public MongoDbSettings(IConfiguration config)
        {
            var sessao = config.GetSection("MongoDbSettings");
            sessao.Bind(this);
        }

        //public string GetConnectionString() { return ConnectionString; }
        //public string GetDatabaseName() { return Database; }
        //public string GetRepositoryName() { return Repository; }
        //public string GetSecret() { return Secret; }    
    }
}
