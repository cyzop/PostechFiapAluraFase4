using Bogus;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.Fixtures
{
    public class AtendimentoTestFixture
    {
        private readonly Faker _faker;
        private string[] ESTADOS_SIGLA = new string[] { "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG", "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF" };

        public string RandomSigla()
        {
            return ESTADOS_SIGLA[_faker.Random.Number(ESTADOS_SIGLA.Length - 1)];
        }
        private DateTime DataAtendimentoValida { 
            get { return DateTime.Now.AddDays(-1); } 
        }
        private DateTime DataAtendimentoInValida
        {
            get { return DateTime.Now.AddDays(+1); }
        }

        public AtendimentoTestFixture()
        {
            _faker = new Faker();
        }

        public AtendimentoMedicoEntity GerarAtendimentoMedicoValido()
        {
            var anamnese = _faker.Lorem.Random.String2(100);
            var sintoma = _faker.Lorem.Random.String2(100);
            var diagnostico = _faker.Lorem.Random.String2(100);
            var tratamento = _faker.Lorem.Random.String2(100);

            var nomeMedico = _faker.Name.FullName();
            var nomePaciente = _faker.Name.FullName();
            var crmMedico = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var idPaciente = _faker.Random.Number(999999).ToString();

            return GeraAtendimentoMedicoEntity(DataAtendimentoValida,
                anamnese,
                sintoma,
                diagnostico,
                tratamento,
                nomeMedico,
                crmMedico,
                nomePaciente,
                idPaciente);
        }
        public AtendimentoMedicoEntity GerarAtendimentoMedicoDataInvalida()
        {
            var anamnese = _faker.Lorem.Random.String2(100);
            var sintoma = _faker.Lorem.Random.String2(100);
            var diagnostico = _faker.Lorem.Random.String2(100);
            var tratamento = _faker.Lorem.Random.String2(100);

            var nomeMedico = _faker.Name.FullName();
            var nomePaciente = _faker.Name.FullName();
            var crmMedico = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var idPaciente = _faker.Random.Number(999999).ToString();

            return GeraAtendimentoMedicoEntity(DataAtendimentoInValida,
                anamnese,
                sintoma,
                diagnostico,
                tratamento,
                nomeMedico,
                crmMedico,
                nomePaciente,
                idPaciente);
        }
        public IdentificadorMedicoEntity GerarIdentificadorMedico()
        {
            var nomeMedico = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            return GerarIdentificadorMedico(nomeMedico, crm);
        }
        
        public IdentificadorMedicoDAO GerarIdentificadorMedicoDao()
        {
            return new IdentificadorMedicoDAO
            {
                Nome = _faker.Name.FullName(),
                CRM = $"{_faker.Random.Number(999999)}-{RandomSigla()}"
            };
        }
        public IdentificadorPacienteDAO GerarIdentificadorPacienteDao()
        {
            return new IdentificadorPacienteDAO
            {
                Nome = _faker.Name.FullName(),
                Identificacao = _faker.Random.Number().ToString()
            };
        }

        public AtendimentoMedicoDAO GerarAtendimentoMedicoDao(IdentificadorPacienteDAO identificadorPacienteDAO)
        {
            var anamnese = _faker.Lorem.Random.String2(100);
            var sintoma = _faker.Lorem.Random.String2(100);
            var diagnostico = _faker.Lorem.Random.String2(100);
            var tratamento = _faker.Lorem.Random.String2(100);

            var nomePaciente = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";

            return GerarAtendimentoMedicoDao(DataAtendimentoValida,
                anamnese,
                sintoma,
                diagnostico,
                tratamento,
                new IdentificadorMedicoDAO() { Nome = nomePaciente, CRM = crm },
                new IdentificadorPacienteDAO() { Nome = identificadorPacienteDAO.Nome, Identificacao = identificadorPacienteDAO.Identificacao });
        }
        public AtendimentoMedicoDAO GerarAtendimentoMedicoDao(IdentificadorMedicoDAO medicoIdentifier)
        {
            var anamnese = _faker.Lorem.Random.String2(100);
            var sintoma = _faker.Lorem.Random.String2(100);
            var diagnostico = _faker.Lorem.Random.String2(100);
            var tratamento = _faker.Lorem.Random.String2(100);

            var nomePaciente = _faker.Name.FullName();
            var idPaciente = _faker.Random.Number(999999).ToString();

            return GerarAtendimentoMedicoDao(DataAtendimentoValida,
                anamnese,
                sintoma,
                diagnostico,
                tratamento,
                new IdentificadorMedicoDAO() { Nome = medicoIdentifier.Nome, CRM = medicoIdentifier.CRM },
                new IdentificadorPacienteDAO() { Nome = nomePaciente, Identificacao = idPaciente });
        }

        public AtendimentoMedicoDAO GerarAtendimentoMedicoDaoDataInvalida(IdentificadorMedicoDAO medicoIdentifier)
        {
            var anamnese = _faker.Lorem.Random.String2(100);
            var sintoma = _faker.Lorem.Random.String2(100);
            var diagnostico = _faker.Lorem.Random.String2(100);
            var tratamento = _faker.Lorem.Random.String2(100);

            var nomePaciente = _faker.Name.FullName();
            var idPaciente = _faker.Random.Number(999999).ToString();

            return GerarAtendimentoMedicoDao(DataAtendimentoInValida,
                anamnese,
                sintoma,
                diagnostico,
                tratamento,
                new IdentificadorMedicoDAO() { Nome = medicoIdentifier.Nome, CRM = medicoIdentifier.CRM },
                new IdentificadorPacienteDAO() { Nome = nomePaciente, Identificacao = idPaciente });
        }

        private AtendimentoMedicoDAO GerarAtendimentoMedicoDao(DateTime dataAtendimento, string anamnese, string sintoma, string diagnostico, string tratamento,
            IdentificadorMedicoDAO identificadorMedico,
            IdentificadorPacienteDAO identificadorPaciente)
        {
            return new AtendimentoMedicoDAO()
            {
                Anamnese = anamnese,
                Sintoma = sintoma,
                Diagnostico = diagnostico,
                Tratamento = tratamento,
                Medico = identificadorMedico,
                Paciente = identificadorPaciente,
                DataAtendimento = dataAtendimento
            };
        }
        private AtendimentoMedicoEntity GeraAtendimentoMedicoEntity(DateTime data, string anamnese, string sintoma, string diagnostico, string tratamento, 
            string nomeMedico, string crmMedico, string nomePaciente, string identificadorPaciente)
        {
            return new AtendimentoMedicoEntity(Guid.NewGuid().ToString(),
              data, anamnese, sintoma, diagnostico, tratamento,
              GerarIdentificadorMedico(nomeMedico, crmMedico),
              GerarIdentificadorPaciente(nomePaciente, identificadorPaciente));
        }

        public AtendimentoMedicoEntity GerarAtendimentoMedicoValido(AtendimentoMedicoDAO atendimentoDao)
        {
            var nomeMedico = _faker.Name.FullName();
            var nomePaciente = _faker.Name.FullName();
            
            return new AtendimentoMedicoEntity(Guid.NewGuid().ToString(),
                atendimentoDao.DataAtendimento,
                atendimentoDao.Anamnese,
                atendimentoDao.Sintoma,
                atendimentoDao.Diagnostico,
                atendimentoDao.Tratamento,
                GerarIdentificadorMedico(nomeMedico, atendimentoDao.Medico.CRM),
                GerarIdentificadorPaciente(nomePaciente, atendimentoDao.Paciente.Identificacao));
        }

        public IdentificadorMedicoEntity GerarIdentificadorMedico(string nomeMedico, string crmMedico) {
            return new IdentificadorMedicoEntity(nomeMedico, crmMedico);
        }
        public IdentificadorPacienteEntity GerarIdentificadorPaciente(string nomePaciente, string idPaciente) {
            return new IdentificadorPacienteEntity(nomePaciente, idPaciente);
        }
    }
}
