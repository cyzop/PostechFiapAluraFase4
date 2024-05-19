using Bogus;
using Moq;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Resource.NoSql.Adapter;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Tests.fixtures;

namespace PosTech.Consultorio.Tests.UnitTests.Repositories
{
    [Collection(nameof(PacienteModelTestFixtureCollection))]
    public class PacienteRepositoryTest
    {
        private readonly PacienteModelTestFixture _modelFixture;
        private readonly List<PacienteModel> _pacienteStore;
        private readonly Mock<IPatientRepository> _mockRepository;
        private readonly Faker _faker;

        public PacienteRepositoryTest(PacienteModelTestFixture modelFixture)
        {
            _faker = new Faker();
            _modelFixture = modelFixture;
            _pacienteStore = _modelFixture.GerarListaPacientes(10);
            _mockRepository = new Mock<IPatientRepository>();          

        }

        [Fact(DisplayName = "Validando busca de paciente por Identificador")]
        [Trait("PacienteModel", "Validando busca de paciente por Identificador")]
        public void ValidateGetById_Should_Return_Entity()
        {

            //Arrange
            _mockRepository.Setup(x => x.ObterPorIdentificacao(It.IsAny<string>()))
            .Returns((string id) => PacienteModelAdapter.EntityFromModel(_pacienteStore.Single(p => p.Identificacao == id)));

            var _repository = _mockRepository.Object;

            int index = _faker.Random.Number(_pacienteStore.Count-1);
            var pacienteReferencia = _pacienteStore[index];

            //Act
            var actResult = _repository.ObterPorIdentificacao(pacienteReferencia.Identificacao);

            //Assert
            Assert.NotNull(actResult);
            Assert.IsType<PacienteEntity>(actResult);
            Assert.Equal(pacienteReferencia.Identificacao, actResult.Identificacao);
            Assert.Equal(pacienteReferencia.Nome, actResult.Nome);
            Assert.Equal(pacienteReferencia.Email, actResult.Email);
            Assert.Equal(pacienteReferencia.DataNascimento, actResult.DataNascimento);
        }
    }
}
