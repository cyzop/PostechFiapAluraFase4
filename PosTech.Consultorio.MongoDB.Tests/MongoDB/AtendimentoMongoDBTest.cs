using Mongo2Go;
using MongoDB.Driver;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.MongoDB.Tests.MongoDB
{
    public class AtendimentoMongoDBTest
    {
        const string MONGO_DB = "AtendimentoMongoDBTest";
        protected static MongoDbRunner _runner;
        protected static IMongoDatabase _mongoDataBase;
        protected static IMongoCollection<AtendimentoModel> collectionAtendimento;

        public virtual void TestInitialize()
        {
            _runner = MongoDbRunner.Start();
            var mongoClient = new MongoClient(_runner.ConnectionString);
            _mongoDataBase = mongoClient.GetDatabase(MONGO_DB);
            collectionAtendimento = _mongoDataBase.GetCollection<AtendimentoModel>(nameof(AtendimentoModel));
        }

        public virtual void TestCleanup() => _runner.Dispose();
    }
}
