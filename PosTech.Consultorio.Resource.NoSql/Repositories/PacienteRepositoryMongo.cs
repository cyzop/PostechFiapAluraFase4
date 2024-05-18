using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Resource.NoSql.Repositories
{
    public class PacienteRepositoryMongo : IPacienteRepository
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

        public void AtualizarPaciente(PacienteEntity paciente)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, paciente.Identificacao);
            var pacientedb = _database.Find(filter).FirstOrDefault();

            var pacienteAtualizar = new PacienteModel(pacientedb.Id,
                paciente.Identificacao,
                paciente.Nome,
                paciente.DataNascimento,
                paciente.Email);

            _database.ReplaceOne(p => p.Id == pacientedb.Id, pacienteAtualizar);
        }

        public void IncluirPaciente(PacienteEntity paciente)
        {
            var pacienteIncluir = new PacienteModel(paciente.Identificacao, paciente.Nome, paciente.DataNascimento, paciente.Email);
            _database.InsertOne(pacienteIncluir);
        }

        public PacienteEntity? ObterPacientePorIdentificacao(string identificacao)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, identificacao);
            var p = _database.Find(filter).FirstOrDefault();

            return p != null ? new PacienteEntity(p.Identificacao, p.Nome, p.DataNascimento, p.Email) : null;
        }

        public ICollection<PacienteEntity> ObterPacientes()
        {
            var dbitens = _database.Find(a => true).ToList();

            return dbitens.Select(e =>
                new PacienteEntity(
                e.Identificacao,
                e.Nome,
                e.DataNascimento,
                e.Email)).ToList();
        }

        public void RemoverPaciente(PacienteEntity paciente)
        {
            var filter = Builders<PacienteModel>.Filter.Eq(p => p.Identificacao, paciente.Identificacao);
            var result = _database.DeleteOne(filter);
        }
    }
}