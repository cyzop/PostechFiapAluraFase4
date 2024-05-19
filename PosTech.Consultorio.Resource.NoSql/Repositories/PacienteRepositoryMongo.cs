using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Adapter;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Resource.NoSql.Repositories
{
    public class PacienteRepositoryMongo : IPatientRepository
    {
        private readonly IMongoCollection<PacienteModel> _database;
        private readonly PacienteDbSettings _settings;

        public PacienteRepositoryMongo(IConfiguration configuration)
        {
            _settings = new PacienteDbSettings(configuration);

            string connectionString = string.Format(_settings.ConnectionString, _settings.Secret);

            var mongoClient = new MongoClient(connectionString);
            var mongoDataBase = mongoClient.GetDatabase(_settings.Database);

            _database = mongoDataBase.GetCollection<PacienteModel>(_settings.Repository);
        }

        public PacienteRepositoryMongo(IMongoDatabase database)
        {
            _database = database.GetCollection<PacienteModel>(nameof(PacienteModel));
                 
        }

        public void AtualizarPaciente(PacienteEntity paciente)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, paciente.Identificacao);
            var pacientedb = _database.Find(filter).FirstOrDefault();

            var pacienteAtualizar = PacienteModelAdapter.ModelFromEntity(pacientedb.Id, paciente);

            _database.ReplaceOne(p => p.Id == pacientedb.Id, pacienteAtualizar);
        }

        public void RegistrarPaciente(PacienteEntity paciente)
        {
            var pacienteIncluir = PacienteModelAdapter.ModelFromEntity(paciente);
            _database.InsertOne(pacienteIncluir);
        }

        public PacienteEntity ObterPorIdentificacao(string identificacao)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, identificacao);
            var p = _database.Find(filter).FirstOrDefault();

            return p != null ? PacienteModelAdapter.EntityFromModel(p)  : null;
        }

        public ICollection<PacienteEntity> ObterPacientes()
        {
            var dbitens = _database.Find(a => true).ToList();

            return dbitens.Select(e => PacienteModelAdapter.EntityFromModel(e)).ToList();
        }
      
        public void RemoverPaciente(PacienteEntity paciente)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, paciente.Identificacao);
            var result = _database.DeleteOne(filter);
        }
    }
}