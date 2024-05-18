using Bogus;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.UnitTests.Entities
{
    [Collection(nameof(PacienteTestFixtureCollection))]
    public class PacienteTest : IClassFixture<PacienteTestFixture>
    {
        private readonly PacienteTestFixture _pacienteFixture;

        public PacienteTest(PacienteTestFixture pacienteFixture)
        {
            _pacienteFixture = pacienteFixture;
        }

        [Fact(DisplayName = "Validando entidade paciente")]
        [Trait("PacienteEntity", "Validando entidade paciente")]
        public void ValidateEntity_Should_Return_Sucess()
        {
            //Arrange
            var entidade = _pacienteFixture.GerarPacienteValido();

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
        }
    }
}
