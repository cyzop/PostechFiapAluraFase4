using Microsoft.Extensions.Configuration;

namespace PosTech.Consultorio.Resource.NoSql.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Repository { get; set; }
        public string Secret { get; set; }
    }
}
