using Moq;
using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.UnitTests.Controller
{
    [Collection(nameof(MedicoTestFixtureCollection))]
    public class MedicoControllerTest
    {
        private readonly MedicoTestFixture _medicoFixture;
        public MedicoControllerTest(MedicoTestFixture medicoFixture)
        {
            _medicoFixture = medicoFixture;
        }

        [Fact(DisplayName = "Teste unitário de validação do controler de criação de novo médico")]
        [Trait("MedicoController", "Teste unitário de validação do controler de criação novo Medico")]
        public void Create_ShouldReturnJson()
        {
            //Arrange
            var entidade = _medicoFixture.GerarMedicoValido();
            //Act
            var json = MedicoAdapter.FromEntityToJson(entidade);

            var mockController = new Mock<IMedicoController>();
            mockController.Setup(controller => controller.RegistrarMedico(It.IsAny<MedicoDAO>())).Returns(json);

            var medicoController = mockController.Object;

            //ACT
            string jsonRetorno = medicoController.RegistrarMedico(_medicoFixture.GerarMedicoDao(entidade.Nome, entidade.CRM.ToString(), entidade.Especialidade));

            //Assert
            Assert.Equal(jsonRetorno, json);
        }

        [Fact(DisplayName = "Teste unitário de validação do controler de alteração de médico já cadastrado")]
        [Trait("MedicoController", "Teste unitário de validação do controler de alteração de Medico")]
        public void Update_ShouldReturnJson()
        {
            //Arrange
            var entidadeMedico = _medicoFixture.GerarMedicoValido();
            var json = MedicoAdapter.FromEntityToJson(entidadeMedico);
            var mockController = new Mock<IMedicoController>();

            //Act
            mockController.Setup(controller => controller.AtualizarMedico(It.IsAny<MedicoDAO>())).Returns(json);

            var medicoController = mockController.Object;

            //ACT
            string jsonRetorno = medicoController.AtualizarMedico(_medicoFixture.GerarMedicoDao(entidadeMedico.Nome, entidadeMedico.CRM.ToString(), entidadeMedico.Especialidade));

            //Assert
            Assert.Equal(jsonRetorno, json);
        }


        [Fact(DisplayName = "Teste unitário de validação do controler de listagem de méticos já cadastrados")]
        [Trait("MedicoController", "Teste unitário de validação do controler de Listar Medicos")]
        public void List_ShouldReturnListOfMedidoDao()
        {
            //Arrange
            var medico = new List<MedicoDAO>();
            medico.Add(_medicoFixture.GerarMedicoDao());
            medico.Add(_medicoFixture.GerarMedicoDao());

            var mockController = new Mock<IMedicoController>();
            mockController.Setup(controller => controller.ListarMedicos()).Returns(medico);

            var medicoController = mockController.Object;

            //ACT
            var retornoMedicos = medicoController.ListarMedicos();

            //Assert
            Assert.Equal(retornoMedicos, medico);
        }

    }
}
