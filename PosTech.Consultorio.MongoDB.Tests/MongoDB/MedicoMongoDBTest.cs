using Mongo2Go;
using MongoDB.Driver;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.MongoDB.Tests.MongoDB
{
    public class MedicoMongoDBTest
    {
        const string MONGO_DB = "MedicoMongoDBTest";
        protected static MongoDbRunner _runner;
        protected static IMongoDatabase _mongoDataBase;
        protected static IMongoCollection<MedicoModel> collectionMedico;

        public virtual void TestInitialize()
        {
            _runner = MongoDbRunner.Start();
            var mongoClient = new MongoClient(_runner.ConnectionString);
            _mongoDataBase = mongoClient.GetDatabase(MONGO_DB);
            collectionMedico = _mongoDataBase.GetCollection<MedicoModel>(nameof(MedicoModel));
        }

        public virtual void TestCleanup() => _runner.Dispose();
    }
}
