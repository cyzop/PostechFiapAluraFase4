using Moq;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.IntegrationTests.Gateways
{
    [Collection(nameof(PacienteTestFixtureCollection))]
    public class PacienteGatewayTest
    {
        private PacienteTestFixture _fixture;
        private Mock<IMedicalDoctorRepository> _medicoRepository;

        public PacienteGatewayTest(PacienteTestFixture fixture)
        {
            this._fixture = fixture;
            _medicoRepository = new Mock<IMedicalDoctorRepository>();
        }

        [Fact(DisplayName = "Validando busca de paciente por Identificador")]
        [Trait("PacienteEntity", "Validando busca de paciente por Identificador")]
        public void Get_ReturnsByIdentifier()
        {
            //Arrange
            var entidade = _fixture.GerarPacienteValido();
            var mockGateway = new Mock<IPacienteGateway>();
            mockGateway.Setup(controller => controller.ObterPorIdentificacao(It.IsAny<String>())).Returns(entidade);

            var pacienteGateway = mockGateway.Object;

            //ACT
            var result = pacienteGateway.ObterPorIdentificacao(entidade.Identificacao);

            //Assert
            Assert.IsType<PacienteEntity>(result);
            Assert.Equal(entidade, result);

        }
    }
}
