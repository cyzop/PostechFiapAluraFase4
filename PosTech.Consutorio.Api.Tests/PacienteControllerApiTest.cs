using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PosTech.Consultorio.Api.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consutorio.Api.Tests
{
    [Collection(nameof(PacienteTestFixtureCollection))]
    public class PacienteControllerApiTest
    {
        private PacienteTestFixture _fixture;
        private PatientController _controller;
        private Mock<IPacienteController> _pacienteController;

        private Mock<ILogger<PatientController>> _loggerMock;
        private Mock<IPatientRepository> _pacienteRepository;

        public PacienteControllerApiTest(PacienteTestFixture fixture)
        {
            _fixture = fixture;
            _loggerMock = new Mock<ILogger<PatientController>>();
            _pacienteRepository = new Mock<IPatientRepository>();
            _pacienteController = new Mock<IPacienteController>();
        }

        [Fact(DisplayName = "Teste unitário de validação de listagem de pacientes da api")]
        [Trait("ApipacienteController", "Teste unitário de validação de listagem de pacientes da api")]
        public async void Get_ReturnsOkResultWithData()
        {
            //Arrange
            var pacientes = new List<PacienteDao>
            {
                _fixture.GerarPacienteDao(),
                _fixture.GerarPacienteDao()
            };

            _pacienteController.Setup(ctr => ctr.ListarPacientes()).Returns(pacientes);

            var pacientesEntity = new List<PacienteEntity>
            {
                _fixture.GerarPacienteValido(),
                _fixture.GerarPacienteValido()
            };
            _pacienteRepository.Setup(repos => repos.ObterPacientes()).Returns(pacientesEntity);

            _controller = new PatientController(
             _loggerMock.Object,
             _pacienteController.Object,
             _pacienteRepository.Object);

            //Act
            var result = await _controller.GetPacientes();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(pacientes, okResult.Value);

        }
    }
}
