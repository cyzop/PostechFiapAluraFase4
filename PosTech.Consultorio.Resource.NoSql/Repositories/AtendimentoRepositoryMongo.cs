using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Adapter;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Resource.NoSql.Repositories
{
    public class AtendimentoRepositoryMongo : IMedicalCareRepository
    {
        private readonly IMongoCollection<AtendimentoModel> _database;
        private readonly AtendimentoDbSettings _settings;

        public AtendimentoRepositoryMongo(IConfiguration configuration)
        {
            _settings = new AtendimentoDbSettings(configuration);

            string connectionString = string.Format(_settings.ConnectionString, _settings.Secret);

            var mongoClient = new MongoClient(connectionString);
            var mongoDataBase = mongoClient.GetDatabase(_settings.Database);

            _database = mongoDataBase.GetCollection<AtendimentoModel>(_settings.Repository);
        }
        public AtendimentoRepositoryMongo(IMongoDatabase database)
        {
            _database = database.GetCollection<AtendimentoModel>(nameof(AtendimentoModel));
        }
        public void AtualizarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Id, atendimento.Id);
            var registrodb = _database.Find(filter).FirstOrDefault();

            var registroAtualizar = AtendimentoMedicoModelAdapter.ModelFromEntity(registrodb.Id, atendimento);

            _database.ReplaceOne(p => p.Id == registrodb.Id, registroAtualizar);
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorData(DateTime data)
        {
            var dbitens = _database.Find(f=> f.DataAtendimento.Year == data.Year &&
                                            f.DataAtendimento.Month == data.Month &&
                                            f.DataAtendimento.Day == data.Day).ToList();

            return dbitens.Select(e => AtendimentoMedicoModelAdapter.EntityFromModel(e)).ToList();
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorMedico(string idMedico)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Medico.Identificacao, idMedico);
            var dbitens = _database.Find(filter).ToList();

            return dbitens.Select(e => AtendimentoMedicoModelAdapter.EntityFromModel(e)).ToList();
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorPaciente(string idPaciente)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Paciente.Identificacao, idPaciente);
            var dbitens = _database.Find(filter).ToList();

            return dbitens.Select(e => AtendimentoMedicoModelAdapter.EntityFromModel(e)).ToList();
        }

        public AtendimentoMedicoEntity ObterPorIdentificacao(string identificacao)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Id, identificacao);
            var e = _database.Find(filter).FirstOrDefault();

            return e != null ? AtendimentoMedicoModelAdapter.EntityFromModel(e) : null;
        }

        public void RegistrarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            var atendimentoIncluir = AtendimentoMedicoModelAdapter.ModelFromEntity(atendimento);

            _database.InsertOne(atendimentoIncluir);
        }
    }
}
