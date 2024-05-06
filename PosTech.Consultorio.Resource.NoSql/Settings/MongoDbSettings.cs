using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class MongoDbSettings
    {
        private string ConnectionString { get; set; }
        private string Database { get; set; }
        private string Repository { get; set; }
        private string Secret { get; set; }

        public MongoDbSettings(IConfiguration config)
        {
            config.GetSection("MongoDbSettings").Bind(this);
        }

        public string GetConnectionString() { return ConnectionString; }
        public string GetDatabaseName() { return Database; }
        public string GetRepositoryName() { return Repository; }
        public string GetSecret() { return Secret; }    
    }
}
