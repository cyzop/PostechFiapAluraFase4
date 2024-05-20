using Bogus;
using PosTech.Consultorio.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Gateways;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.MongoDB.Tests.MongoDB;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Repositories;

namespace PosTech.Consultorio.MongoDB.Tests.Integrations
{
    public class PacienteControllerIntegrationTest : PacienteMongoDBTest
    {
        private readonly Faker _faker;
        private readonly IPacienteGateway _gateway;
        private readonly IPacienteController _controller;


        public PacienteControllerIntegrationTest()
        {
            base.TestInitialize();
            var repositorioMedicos = new PacienteRepositoryMongo(_mongoDataBase);
            _faker = new Faker();

            //initialize with 5 register
            collectionPaciente.InsertMany(new List<PacienteModel>() {
               new PacienteModel("10001", "Paciente 1", DateTime.Today.AddYears(-10), "teste1@teste.com"),
               new PacienteModel("10002", "Paciente 2", DateTime.Today.AddYears(-11), "teste2@teste.com"),
               new PacienteModel("10003", "Paciente 3", DateTime.Today.AddYears(-11), "teste3@teste.com"),
               new PacienteModel("10004", "Paciente 4", DateTime.Today.AddYears(-12), "teste4@teste.com"),
               new PacienteModel("10005", "Paciente 5", DateTime.Today.AddYears(-13), "teste5@teste.com")
            });

            _gateway = new PacienteGateway(repositorioMedicos);

            _controller = new PacienteController(_gateway);
        }

        ~PacienteControllerIntegrationTest() => base.TestCleanup();

        [Fact(DisplayName = "Validando inclusão de medico com CRM duplicado")]
        [Trait("PacienteDao", "Validando inclusão de novo medico CRM duplicado")]
        public void Create_ShouldThrowException_WhenIdentificationIsDuplicated()
        {
            //Arrange
            var pacientes = _controller.ListarPacientes().ToList();
            var identificador = pacientes[_faker.Random.Number(pacientes.Count - 1)].Identificacao;
            var email = _faker.Person.Email;
            var nome = _faker.Name.FullName();

            var pacienteDao = new PacienteDao() { Identificacao = identificador, Nome = nome, Email = email, DataNascimento = DateTime.Today.AddYears(-30)};

            //Act
            var result = Assert.Throws<Exception>(() => _controller.RegistrarPaciente(pacienteDao));

            //Assert
            Assert.Equal("Já existe um paciente cadastrado com esta Identificacao!", result.Message);
        }
    }
}
