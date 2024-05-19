using Bogus;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.Fixtures
{
    public class MedicoTestFixture
    {
        private readonly Faker _faker;
        private string[] ESTADOS_SIGLA = new string[] { "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG", "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF" };

        public MedicoTestFixture()
        {
            _faker = new Faker();
        }

        public string RandomSigla()
        {
            return ESTADOS_SIGLA[_faker.Random.Number(ESTADOS_SIGLA.Length - 1)];
        }

        public MedicoEntity GerarMedicoValido()
        {
            var xteste = _faker.Address.StateAbbr();

            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome, 
                DateTime.Today.AddYears(-50), 
                crm, 
                DateTime.Today.AddYears(-20), 
                especialidade);
        }

        public MedicoEntity GerarMedicoNomeVazio()
        {
            var nome = string.Empty;
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome,
                DateTime.Today.AddYears(-50),
                crm,
                DateTime.Today.AddYears(-20),
                especialidade);

        }
        public MedicoEntity GerarMedicoCRMInvalido()
        {
            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.String2(10)}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome,
                DateTime.Today.AddYears(-50),
                crm,
                DateTime.Today.AddYears(-20),
                especialidade);
        }
        public MedicoEntity GerarMedicoCRMcomUFInvalida()
        {
            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{_faker.Random.String2(4)}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome,
                DateTime.Today.AddYears(-50),
                crm,
                DateTime.Today.AddYears(-20),
                especialidade);
        }
        public MedicoEntity GerarMedicoComIdadeAcimadoLimiteMaximo()
        {
            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome,
                DateTime.Today.AddYears(-100),
                crm,
                DateTime.Today.AddYears(-20),
                especialidade);
        }
        public MedicoEntity GerarMedicoComIdadeAbaixoLimiteMinimo()
        {
            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var especialidade = _faker.Name.JobArea();

            return new MedicoEntity(nome,
                DateTime.Today.AddYears(-15),
                crm,
                DateTime.Today.AddYears(-20),
                especialidade);
        }


        public MedicoDAO GerarMedicoDao()
        {
            var nome = _faker.Name.FullName();
            var crm = $"{_faker.Random.Number(999999)}-{RandomSigla()}";
            var especialidade = _faker.Name.JobArea();
            return GerarMedicoDao(nome, crm, especialidade);
        }

        public MedicoDAO GerarMedicoDao(string nome, string crm, string especialidade)
        {
            return new MedicoDAO()
            {
                Nome = nome,
                CRM = crm,
                DataInscricao = DateTime.Today.AddYears(-20),
                DataNascimento = DateTime.Today.AddYears(-50),
                Especialidade = especialidade
            };
        }

        //declarar a colection para colocar com notation na classe de teste que vai utilizar
    }
}
