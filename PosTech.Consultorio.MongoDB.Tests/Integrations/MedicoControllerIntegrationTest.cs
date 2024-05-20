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
    public class MedicoControllerIntegrationTest : MedicoMongoDBTest
    {
        private readonly Faker _faker;
        private readonly IMedicoGateway _gateway;
        private readonly IMedicoController _controller;

        public MedicoControllerIntegrationTest()
        {
            base.TestInitialize();
            var repositorioMedicos = new MedicoRepositoryMongo(_mongoDataBase);
            _faker = new Faker();

            //initialize with 5 register
            collectionMedico.InsertMany(new List<MedicoModel>() {
               new MedicoModel("10001-RJ", DateTime.Today.AddYears(-10), "Medico 1", DateTime.Today.AddYears(-25), "Clinico"),
               new MedicoModel("10002-DF", DateTime.Today.AddYears(-10),"Medico 2", DateTime.Today.AddYears(-26), "Pediatra"),
               new MedicoModel("10003-BH", DateTime.Today.AddYears(-10),"Medico 3", DateTime.Today.AddYears(-27), "Osteopata"),
               new MedicoModel("10004-SP", DateTime.Today.AddYears(-10),"Medico 4", DateTime.Today.AddYears(-28), "Geriatra"),
               new MedicoModel("10005-RS", DateTime.Today.AddYears(-10),"Medico 5", DateTime.Today.AddYears(-29), "Urologista")
            });

            _gateway = new MedicoGateway(repositorioMedicos);

            _controller = new MedicoController(_gateway);
        }

        ~MedicoControllerIntegrationTest() => base.TestCleanup();


        [Fact(DisplayName = "Validando inclusão de medico com CRM duplicado")]
        [Trait("MedicoDao", "Validando inclusão de novo medico CRM duplicado")]
        public void Create_ShouldThrowException_WhenCRMIsDuplicated()
        {
            //Arrange
            var medicos = _controller.ListarMedicos();
            var crm = medicos[_faker.Random.Number(medicos.Count - 1)].CRM.ToString();
            var especialidade = "Neuro cirurgião";
            var nome = _faker.Name.FullName();

            var medidoDao = new MedicoDAO() { CRM = crm, Nome = nome, Especialidade = especialidade, DataNascimento = DateTime.Today.AddYears(-30), DataInscricao = DateTime.Today.AddYears(5) };

            //Act
            var result = Assert.Throws<Exception>(() => _controller.RegistrarMedico(medidoDao));

            //Assert
            Assert.Equal("Já existe um Medico cadastrado com mesmo CRM!", result.Message);
        }
    }
}
