using Bogus;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Gateways;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.MongoDB.Tests.MongoDB;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Repositories;

namespace PosTech.Consultorio.MongoDB.Tests.Integrations
{
    public class PacienteGatewayIntegrationTest : PacienteMongoDBTest
    {
        private readonly IPacienteGateway _gateway; 
        private readonly Faker _faker;

        public PacienteGatewayIntegrationTest()
        {
            base.TestInitialize();
            var repositorioPacientes = new PacienteRepositoryMongo(_mongoDataBase);
            _faker = new Faker();

            //initialize with 5 register
            collectionPaciente.InsertMany(new List<PacienteModel>() {
               new PacienteModel("10001", "Paciente 1", DateTime.Today.AddYears(-10), "teste1@teste.com"),
               new PacienteModel("10002", "Paciente 2", DateTime.Today.AddYears(-11), "teste2@teste.com"),
               new PacienteModel("10003", "Paciente 3", DateTime.Today.AddYears(-11), "teste3@teste.com"),
               new PacienteModel("10004", "Paciente 4", DateTime.Today.AddYears(-12), "teste4@teste.com"),
               new PacienteModel("10005", "Paciente 5", DateTime.Today.AddYears(-13), "teste5@teste.com")
            });

            _gateway = new PacienteGateway(repositorioPacientes);
        }

        ~PacienteGatewayIntegrationTest() => base.TestCleanup();


        [Fact(DisplayName = "Validando inclusão de paciente no banco Mongo através do Gateway")]
        [Trait("PacienteEntity", "Validando inclusão de novo paciente no banco de dados através do Gateway")]
        public void Create_Should_Return_SameCreated()
        {
            //Arrange
            var identificador = _faker.Random.Number(100).ToString();
            var email = _faker.Person.Email;
            var nome = _faker.Name.FullName();

            var pacienteEntity = new PacienteEntity(identificador, nome, DateTime.Today.AddYears(-10), email);

            //Act
            _gateway.RegistrarPaciente(pacienteEntity);
            var pacienteBusca = _gateway.ObterPorIdentificacao(pacienteEntity.Identificacao);

            //Assert
            Assert.NotNull(pacienteBusca);
            Assert.Equal(pacienteBusca.Identificacao, pacienteEntity.Identificacao);
            Assert.Equal(pacienteBusca.Nome, pacienteEntity.Nome);
            Assert.Equal(pacienteBusca.Email, pacienteEntity.Email);
            Assert.Equal(pacienteBusca.DataNascimento.ToShortDateString(), pacienteEntity.DataNascimento.ToShortDateString());
        }

        [Fact(DisplayName = "Validando exclusão de paciente no banco Mongo")]
        [Trait("PacienteEntity", "Validando exclusão de paciente no banco de dados")]
        public void Remote_Should_Return_Sucess()
        {
            //Arrange
            var pacientesIniciais = _gateway.ObterPacientes();
            var randomElement = _faker.Random.ArrayElement(pacientesIniciais.ToArray());

            //Act
            _gateway.RemoverPaciente(randomElement);
            var pacienteBusca = _gateway.ObterPorIdentificacao(randomElement.Identificacao);

            var quantidadeRestante = _gateway.ObterPacientes().Count;
            //Assert
            Assert.Null(pacienteBusca);
            Assert.Equal(pacientesIniciais.Count - 1, quantidadeRestante);
        }
    }
    
}
