using Bogus;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.UnitTests.Entities
{
    [Collection(nameof(MedicoTestFixtureCollection))]
    public class MedicoTest
    {
        public readonly MedicoTestFixture _medicoFixture;

        public MedicoTest(MedicoTestFixture medicoFixture)
        {
            _medicoFixture = medicoFixture;
        }

        [Fact(DisplayName = "Teste unitário de validação da entidade médico")]
        [Trait("MedicoEntity", "Teste unitário de validação da entidade Médico")]
        public void ValidateEntity_Should_New_MedicalDoctorEntity()
        {
            //Arrange
            var entidade = _medicoFixture.GerarMedicoValido();

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
        }


        [Fact(DisplayName = "Teste unitário de validação da entidade médico com nome vazio")]
        [Trait("MedicoEntity", "Teste unitário de validação da entidade Médico com nome vazio")]
        public void ValidateEntity_ShouldThrowException_WhenNameisEmpty()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _medicoFixture.GerarMedicoNomeVazio());

            //Assert
            Assert.Equal("O Nome do médico não pode estar vazio!", result.Message);
        }

        [Fact(DisplayName = "Teste unitário de validação da entidade médico com UF do CRM inválida")]
        [Trait("MedicoEntity", "Teste unitário de validação da entidade Médico com UF do CRM inválida")]
        public void ValidateEntity_ShouldThrowException_WhenCRMisInvalid()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _medicoFixture.GerarMedicoCRMcomUFInvalida());

            //Assert
            Assert.Equal("A UF do CRM está inválida, ela deve ter apenas 2 caracteres!", result.Message);
        }

        [Fact(DisplayName = "Teste unitário de validação da entidade médico com idade superior a 70 anos")]
        [Trait("MedicoEntity", "Teste unitário de validação da entidade Médico com idade inválida, acima dos 70 anos")]
        public void ValidateEntity_ShouldThrowException_WhenAgeIsGreaterThanMaxValue()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _medicoFixture.GerarMedicoComIdadeAcimadoLimiteMaximo());

            //Assert
            Assert.Equal("Data de nascimento do médico inválida, ele não pode ter mais de 70 anos!", result.Message);
        }

        [Fact(DisplayName = "Teste unitário de validação da entidade médico com idade inferior a 21 anos")]
        [Trait("MedicoEntity", "Teste unitário de validação da entidade Médico com idade inválida, abaixo dos 21 anos")]
        public void ValidateEntity_ShouldThrowException_WhenAgeIsLowerThanMinValue()
        {
            //Arrange

            //Act
            var result = Assert.Throws<ArgumentException>(() => _medicoFixture.GerarMedicoComIdadeAbaixoLimiteMinimo());

            //Assert
            Assert.Equal("Data de nascimento do médico inválida, ele não pode ser menor de 21 anos!", result.Message);
        }
    }
}
