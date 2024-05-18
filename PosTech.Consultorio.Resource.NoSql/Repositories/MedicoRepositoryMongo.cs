using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
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
        public void AtualizarMedico(MedicoEntity medico)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, medico.CRM.ToString());
            var medicodb = _database.Find(filter).FirstOrDefault();

            var medicoAtualizar = new MedicoModel(medicodb.Id,
                medico.CRM.ToString(),
                medico.DataEmissao,
                medico.Nome,
                medico.DataNascimento,
                medico.Especialidade
                );

            _database.ReplaceOne(p => p.Id == medicodb.Id, medicoAtualizar);
        }

        public void IncluirMedico(MedicoEntity medico)
        {
            var medicoIncluir = new MedicoModel(medico.CRM.ToString(), medico.DataEmissao, medico.Nome, medico.DataNascimento, medico.Especialidade);
            _database.InsertOne(medicoIncluir);
        }

        public ICollection<MedicoEntity> ObterMedicos()
        {
            var dbitens = _database.Find(a => true).ToList();

            return dbitens.Select(e =>
                new MedicoEntity(e.Nome, 
                e.DataNascimento, 
                new CRMEntity(e.Identificacao), 
                e.DataEmissao, 
                e.Especialidade)).ToList();
        }

        public MedicoEntity ObterPorIdentificacao(string identificacao)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, identificacao);
            var p = _database.Find(filter).FirstOrDefault();

            return p != null ? new MedicoEntity(p.Nome, 
                p.DataNascimento, 
                new CRMEntity(p.Identificacao), 
                p.DataEmissao, 
                p.Especialidade) : null;
        }

        public void RemoverMedico(MedicoEntity medico)
        {
            var filter = Builders<MedicoModel>.Filter.Eq(p => p.Identificacao, medico.CRM.ToString());
            var result = _database.DeleteOne(filter);
        }
    }
}
