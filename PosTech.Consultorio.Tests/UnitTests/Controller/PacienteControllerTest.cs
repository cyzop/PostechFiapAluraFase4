using Moq;
using PosTech.Consultorio.Adapters.OutPut;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.UnitTests.Controller
{
    [Collection(nameof(PacienteTestFixtureCollection))]
    public class PacienteControllerTest
    {
        private readonly PacienteTestFixture _pacienteFixture;

        public PacienteControllerTest(PacienteTestFixture pacienteFixture)
        {
            _pacienteFixture = pacienteFixture;
        }

        [Fact(DisplayName = "Teste unitário de validação do controler de criação de novo paciente")]
        [Trait("PacienteController", "Teste unitário de validação do controler de criação novo paciente")]
        public void Create_ShouldReturnJson()
        {
            //Arrange
            var entidade = _pacienteFixture.GerarPacienteValido();
            //Act
            var json = PacienteAdapter.FromEntityToJson(entidade);

            var mockController = new Mock<IPacienteController>();
            mockController.Setup(controller => controller.RegistrarPaciente(It.IsAny<PacienteDao>())).Returns(json);

            var pacienteController = mockController.Object;

            //ACT
            string jsonRetorno = pacienteController.RegistrarPaciente(_pacienteFixture.GerarPacienteDao(entidade.Nome, entidade.Identificacao, entidade.DataNascimento, entidade.Email));

            //Assert
            Assert.Equal(jsonRetorno, json);
        }

        [Fact(DisplayName = "Teste unitário de validação do controler de alteração de paciente")]
        [Trait("PacienteController", "Teste unitário de validação do controler de alteração de paciente")]
        public void Update_ShouldReturnJson()
        {
            //Arrange
            var entidade = _pacienteFixture.GerarPacienteValido();
            //Act
            var json = PacienteAdapter.FromEntityToJson(entidade);

            var mockController = new Mock<IPacienteController>();
            mockController.Setup(controller => controller.AtualizarPaciente(It.IsAny<PacienteDao>())).Returns(json);

            var pacienteController = mockController.Object;

            //ACT
            string jsonRetorno = pacienteController.AtualizarPaciente(_pacienteFixture.GerarPacienteDao(entidade.Nome, entidade.Identificacao, entidade.DataNascimento, entidade.Email));

            //Assert
            Assert.Equal(jsonRetorno, json);
        }
    }
}
