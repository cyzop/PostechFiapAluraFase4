using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Settings;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void AtualizarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Id, atendimento.Id);
            var registrodb = _database.Find(filter).FirstOrDefault();

            var registroAtualizar = new AtendimentoModel(registrodb.Id,
                new MedicoAtendimentoModel(atendimento.Medico.CRM, atendimento.Medico.Nome),
                new PacienteAtendimentoModel(atendimento.Paciente.Identificacao, atendimento.Paciente.Nome),
                atendimento.DataAtendimento,
                atendimento.Anamnese,
                atendimento.Sintoma,
                atendimento.Diagnostico,
                atendimento.Tratamento);

            _database.ReplaceOne(p => p.Id == registrodb.Id, registroAtualizar);
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorData(DateTime data)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.DataAtendimento, data);
            var dbitens = _database.Find(filter).ToList();

            return dbitens.Select(e =>
             new AtendimentoMedicoEntity(e.Id, e.DataAtendimento, e.Anamnese, e.Sintoma, e.Diagnostico, e.Tratamento,
                new IdentificadorMedicoEntity(e.Medico.Nome, e.Medico.Identificacao),
                new IdentificadorPacienteEntity(e.Paciente.Nome, e.Paciente.Identificacao))).ToList();
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorIdentificadorMedico(string idMedico)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Medico.Identificacao, idMedico);
            var dbitens = _database.Find(filter).ToList();

            return dbitens.Select(e =>
             new AtendimentoMedicoEntity(e.Id, e.DataAtendimento, e.Anamnese, e.Sintoma, e.Diagnostico, e.Tratamento,
                new IdentificadorMedicoEntity(e.Medico.Nome, e.Medico.Identificacao),
                new IdentificadorPacienteEntity(e.Paciente.Nome, e.Paciente.Identificacao))).ToList();
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorIdentificadorPaciente(string idPaciente)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Paciente.Identificacao, idPaciente);
            var dbitens = _database.Find(filter).ToList();

            return dbitens.Select(e =>
             new AtendimentoMedicoEntity(e.Id, e.DataAtendimento, e.Anamnese, e.Sintoma, e.Diagnostico, e.Tratamento,
                new IdentificadorMedicoEntity(e.Medico.Nome, e.Medico.Identificacao),
                new IdentificadorPacienteEntity(e.Paciente.Nome, e.Paciente.Identificacao))).ToList();
        }

        public AtendimentoMedicoEntity ObterAtendimentoPorIdentificacao(string identificacao)
        {
            var filter = Builders<AtendimentoModel>.Filter.Eq(p => p.Id, identificacao);
            var e = _database.Find(filter).FirstOrDefault();

            return e != null ? new AtendimentoMedicoEntity(e.Id, e.DataAtendimento, e.Anamnese, e.Sintoma, e.Diagnostico, e.Tratamento,
                new IdentificadorMedicoEntity(e.Medico.Nome, e.Medico.Identificacao),
                new IdentificadorPacienteEntity(e.Paciente.Nome, e.Paciente.Identificacao)) : null;
        }

        public void RegistrarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            var atendimentoIncluir = new AtendimentoModel(
                new MedicoAtendimentoModel(atendimento.Medico.CRM, atendimento.Medico.Nome),
                new PacienteAtendimentoModel(atendimento.Paciente.Identificacao, atendimento.Paciente.Nome),
                atendimento.DataAtendimento,
                atendimento.Anamnese,
                atendimento.Sintoma,
                atendimento.Diagnostico,
                atendimento.Tratamento);

            _database.InsertOne(atendimentoIncluir);
        }
    }
}
