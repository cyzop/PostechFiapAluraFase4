using Mongo2Go;
using MongoDB.Driver;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.MongoDB.Tests.MongoDB
{
    public class PacienteMongoDBTest
    {
        const string MONGO_DB = "PacienteMongoDBTest";
        protected static MongoDbRunner _runner;
        protected static IMongoDatabase _mongoDataBase;
        protected static IMongoCollection<PacienteModel> collectionPaciente;

        public virtual void TestInitialize()
        {
            _runner = MongoDbRunner.Start();
            var mongoClient = new MongoClient(_runner.ConnectionString);
            _mongoDataBase = mongoClient.GetDatabase(MONGO_DB);
            collectionPaciente = _mongoDataBase.GetCollection<PacienteModel>(nameof(PacienteModel));
        }

        public virtual void TestCleanup() => _runner.Dispose();
    }
}
