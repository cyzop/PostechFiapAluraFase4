using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.Api.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Tests.Fixtures;
using PosTech.Consutorio.Api.Tests.fixtures;

namespace PosTech.Consutorio.Api.Tests
{
    [Collection(nameof(AtendimentoTestFixtureCollection))]
    public class AtendimentoMedicoControllerApiTest
    {
        private AtendimentoTestFixture _fixture;
        private MedicalCareController _apiController;
        private Mock<IAtendimentoController> _atendimentoController;

        private Mock<ILogger<MedicalCareController>> _loggerMock;
        private Mock<IMedicalCareRepository> _atendimentoRepository;
        public AtendimentoMedicoControllerApiTest(AtendimentoTestFixture fixture)
        {
            _fixture = fixture;

            _loggerMock = new Mock<ILogger<MedicalCareController>>();
            _atendimentoRepository = new Mock<IMedicalCareRepository>();
            _atendimentoController = new Mock<IAtendimentoController>();
        }

        [Fact(DisplayName = "Teste unitário de validação de retorno dos atendimentos de um médico")]
        [Trait("ApiAtendimentoMedicoController", "Teste unitário de validação de retorno dos atendimentos de um médico")]
        public async void Get_ReturnsOkResultWithDataFromMedicalDoctor()
        {
            //Arrange
            var medicoIdentifier = _fixture.GerarIdentificadorMedicoDao();

            var atendimentosDao = new List<AtendimentoMedicoDAO>
           {
               _fixture.GerarAtendimentoMedicoDao(medicoIdentifier),
               _fixture.GerarAtendimentoMedicoDao(medicoIdentifier)
           };

            _atendimentoController.Setup(ctr => ctr.ListarAtendimentosPorMedico(medicoIdentifier.CRM)).Returns(atendimentosDao);

            var medicoIdentifierEntity = _fixture.GerarIdentificadorMedico(medicoIdentifier.Nome, medicoIdentifier.CRM);

            var atendimentosEntity = new List<AtendimentoMedicoEntity>
            {
           _fixture.GerarAtendimentoMedicoValido(),
           _fixture.GerarAtendimentoMedicoValido()
            };

            _atendimentoRepository.Setup(repos => repos.ObterAtendimentosPorMedico(medicoIdentifier.CRM)).Returns(atendimentosEntity);

            _apiController = new MedicalCareController(
             _loggerMock.Object,
            _atendimentoController.Object,
             _atendimentoRepository.Object);

            //Act
            var result = await _apiController.GetAtendimentosPorMedico(medicoIdentifier.CRM);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(atendimentosDao, okResult.Value);
        }

        [Fact(DisplayName = "Teste unitário de validação de retorno de atendimentos de um paciente")]
        [Trait("ApiAtendimentoMedicoController", "Teste unitário de validação de retorno de atendimentos de um paciente")]
        public async void Get_ReturnsOkResultWithDataFromPatient()
        {
            //Arrange
            var pacienteIdentifier = _fixture.GerarIdentificadorPacienteDao();

            var atendimentosDao = new List<AtendimentoMedicoDAO>
           {
               _fixture.GerarAtendimentoMedicoDao(pacienteIdentifier),
               _fixture.GerarAtendimentoMedicoDao(pacienteIdentifier)
           };

            _atendimentoController.Setup(ctr => ctr.ListarAtendimentosPorPaciente(pacienteIdentifier.Identificacao)).Returns(atendimentosDao);

            var medicoIdentifierEntity = _fixture.GerarIdentificadorPaciente(pacienteIdentifier.Nome, pacienteIdentifier.Identificacao);

            var atendimentosEntity = new List<AtendimentoMedicoEntity>
            {
               _fixture.GerarAtendimentoMedicoValido(),
               _fixture.GerarAtendimentoMedicoValido()
            };

            _atendimentoRepository.Setup(repos => repos.ObterAtendimentosPorPaciente(pacienteIdentifier.Identificacao)).Returns(atendimentosEntity);

            _apiController = new MedicalCareController(
             _loggerMock.Object,
            _atendimentoController.Object,
             _atendimentoRepository.Object);

            //Act
            var result = await _apiController.GetAtendimentosPorPaciente(pacienteIdentifier.Identificacao);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(atendimentosDao, okResult.Value);
        }

        [Fact(DisplayName = "Teste unitário de validação de registro de atendimento médico")]
        [Trait("ApiAtendimentoMedicoController", "Teste unitário de validação de registro de atendimento médico ")]
        public async void Get_ReturnsOkResultWithJsonWhenInclude()
        {
            //Arrange
            var medicoIdentifier = _fixture.GerarIdentificadorMedicoDao();
            var atendimentoDao = _fixture.GerarAtendimentoMedicoDao(medicoIdentifier);
            var atendimentoEntity = _fixture.GerarAtendimentoMedicoValido(atendimentoDao);
            var jsonAtendimento = AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);

            _atendimentoController.Setup(ctr => ctr.IncluirAtendimento(atendimentoDao)).Returns(jsonAtendimento);

            _atendimentoRepository.Setup(repos => repos.RegistrarAtendimentoMedico(atendimentoEntity));

            _apiController = new MedicalCareController(
             _loggerMock.Object,
            _atendimentoController.Object,
             _atendimentoRepository.Object);

            //Act
            var result = await _apiController.IncluirAtendimento(atendimentoDao);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(jsonAtendimento, okResult.Value);
        }

        [Fact(DisplayName = "Teste unitário de validação de alteração de atendimento médico")]
        [Trait("ApiAtendimentoMedicoController", "Teste unitário de validação de alteração de atendimento médico ")]
        public async void Get_ReturnsOkResultWithJsonWhenUpdate()
        {
            //Arrange
            var medicoIdentifier = _fixture.GerarIdentificadorMedicoDao();
            var atendimentoDao = _fixture.GerarAtendimentoMedicoDao(medicoIdentifier);
            var atendimentoEntity = _fixture.GerarAtendimentoMedicoValido(atendimentoDao);
            var jsonAtendimento = AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);

            _atendimentoController.Setup(ctr => ctr.AtualizarAtendimento(atendimentoDao)).Returns(jsonAtendimento);

            _atendimentoRepository.Setup(repos => repos.AtualizarAtendimentoMedico(atendimentoEntity));

            _apiController = new MedicalCareController(
             _loggerMock.Object,
            _atendimentoController.Object,
             _atendimentoRepository.Object);

            //Act
            var result = await _apiController.AtualizarAtendimento(atendimentoDao);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(jsonAtendimento, okResult.Value);
        }
    }
}
