using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Adapter;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Settings;

namespace PosTech.Consultorio.Resource.NoSql.Repositories
{
    public class MedicoRepositoryMongo : IMedicalDoctorRepository
    {
        private readonly IMongoCollection<MedicoModel> _database;
        private readonly MedicoDbSettings _settings;

        public MedicoRepositoryMongo(IConfiguration configuration)
        {
            _settings = new MedicoDbSettings(configuration);

            string connectionString = string.Format(_settings.ConnectionString, _settings.Secret);

            var mongoClient = new MongoClient(connectionString);
            var mongoDataBase = mongoClient.GetDatabase(_settings.Database);

            _database = mongoDataBase.GetCollection<MedicoModel>(_settings.Repository);
        }

        public MedicoRepositoryMongo(IMongoDatabase database)
        {
            _database = database.GetCollection<MedicoModel>(nameof(MedicoModel));
        }
        public void AtualizarMedico(MedicoEntity medico)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, medico.CRM.ToString());
            var medicodb = _database.Find(filter).FirstOrDefault();

            var medicoAtualizar = MedicoModelAdapter.ModelFromEntity(medicodb.Id, medico);
            _database.ReplaceOne(p => p.Id == medicodb.Id, medicoAtualizar);
        }

        public void IncluirMedico(MedicoEntity medico)
        {
            var medicoIncluir = MedicoModelAdapter.ModelFromEntity(medico);
            _database.InsertOne(medicoIncluir);
        }

        public ICollection<MedicoEntity> ObterMedicos()
        {
            var dbitens = _database.Find(a => true).ToList();
            return dbitens.Select(e => MedicoModelAdapter.EntityFromModel(e)).ToList();
        }

        public MedicoEntity ObterPorIdentificacao(string identificacao)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, identificacao);
            var p = _database.Find(filter).FirstOrDefault();

            return p != null ? MedicoModelAdapter.EntityFromModel(p) : null;
        }

        public void RemoverMedico(MedicoEntity medico)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, medico.CRM.ToString());
            var result = _database.DeleteOne(filter);
        }
    }
}
