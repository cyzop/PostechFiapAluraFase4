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

        [Fact(DisplayName = "Validando entidade paciente com nome vazio")]
        [Trait("PacienteEntity", "Validando entidade paciente com nome vazio")]
        public void ValidateEntity_ShouldThrowException_WhenNameIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _pacienteFixture.GerarPacienteNomeVazio());

            //Assert
            Assert.Equal("O Nome do paciente não pode estar vazio!", result.Message);
        }

        [Fact(DisplayName = "Validando entidade paciente com nome Identificador vazio")]
        [Trait("PacienteEntity", "Validando entidade paciente com Identificador vazio")]
        public void ValidateEntity_ShouldThrowException_WhenIdentifierIsEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _pacienteFixture.GerarPacienteIdentificadorVazio());

            //Assert
            Assert.Equal("A Identificação do paciente não pode estar vazia!", result.Message);
        }

        [Fact(DisplayName = "Validando entidade paciente com idade superior a 110 anos")]
        [Trait("PacienteEntity", "Validando entidade paciente com idade inválida, acima dos 110 anos")]
        public void ValidateEntity_ShouldThrowException_WhenAgeIsGreaterThanMaxValue()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _pacienteFixture.GerarPacienteComIdadeAcimadoLimiteMaximo());

            //Assert
            Assert.Equal("Data de nascimento do paciente inválida, ele não pode ter mais de 110 anos!", result.Message);
        }

        [Fact(DisplayName = "Validando entidade paciente com idade inferior a 0 anos")]
        [Trait("PacienteEntity", "Validando entidade paciente com idade inválida, data de nascimento futura")]
        public void ValidateEntity_ShouldThrowException_WhenAgeIsLowerThanMinValue()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _pacienteFixture.GerarPacienteComIdadeAbaixoLimiteMinimo());

            //Assert
            Assert.Equal("Data de nascimento do paciente inválida, ele não pode nascer no futuro!", result.Message);
        }
    }
}
