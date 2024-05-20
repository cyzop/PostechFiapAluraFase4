using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PosTech.Consultorio.Api.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.Tests.Fixtures;

namespace PosTech.Consultorio.Tests.IntegrationTests.Api.Controller
{
    [Collection(nameof(MedicoTestFixtureCollection))]
    public class MedicoControllerApiTest
    {
        private MedicoTestFixture _fixture;
        private MedicalDoctorController _controller;
        private Mock<IMedicoController> _medicoController;
        
        private Mock<ILogger<MedicalDoctorController>> _loggerMock;
        private Mock<IMedicalDoctorRepository> _medicoRepository;

        public MedicoControllerApiTest(MedicoTestFixture fixture)
        {
            _fixture = fixture;
            _loggerMock = new Mock<ILogger<MedicalDoctorController>>();
            _medicoRepository = new Mock<IMedicalDoctorRepository>();
            _medicoController = new Mock<IMedicoController>();            
        }

        [Fact(DisplayName = "Teste unitário de validação de listagem de medicos da api")]
        [Trait("ApiMedicoController", "Teste unitário de validação de listagem de medicos da api")]
        public async void Get_ReturnsOkResultWithData()
        {
            //Arrange
            var medicos = new List<MedicoDAO>
            {
                _fixture.GerarMedicoDao(),
                _fixture.GerarMedicoDao()
            };

            _medicoController.Setup(ctr => ctr.ListarMedicos()).Returns(medicos);

            var medicosEntity = new List<MedicoEntity>
            {
                _fixture.GerarMedicoValido(),
                _fixture.GerarMedicoValido()
            };
            _medicoRepository.Setup(repos => repos.ObterMedicos()).Returns(medicosEntity);

            _controller = new MedicalDoctorController(
             _loggerMock.Object,
             _medicoController.Object,
             _medicoRepository.Object);

            //Act
            var result = await _controller.GetMedicos();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(medicos, okResult.Value);

        }
    }
}
