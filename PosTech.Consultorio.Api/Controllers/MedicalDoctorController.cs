using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.Consultorio.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Repositories;

namespace PosTech.Consultorio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalDoctorController : ControllerBase
    {
        private readonly ILogger<MedicalDoctorController> _logger;
        private readonly IMedicoController _medicoController;
        private readonly IMedicalDoctorRepository medicoStore;

        public MedicalDoctorController(ILogger<MedicalDoctorController> logger, IMedicoController medicoController, IMedicalDoctorRepository medicoStore)
        {
            _logger = logger;
            _medicoController = medicoController;
            this.medicoStore = medicoStore;
        }



        /// <summary>
        /// Retorna a listagem de médicos
        /// </summary>
        /// <response code="200">Retorno realizado com sucesso</response>
        /// <response code="204">Nenhum Médico encontrado</response>
        /// <response code="400">Falha na consulta dos pacientes</response>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MedicoDAO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMedicos()
        {
            try
            {
                var medicos = _medicoController.ListarMedicos();
                var quantidade = medicos?.Count() ?? 0;

                _logger.LogInformation("Get medicos length {quantidade}", quantidade);

                if (medicos?.Count() > 0)
                    return Ok(medicos);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicoDAO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IncluirMedico(MedicoDAO medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //inclusao
                    _logger.LogInformation("Post Medico {Nome}", medico.Nome);

                    string jsonRestorno = _medicoController.RegistrarMedico(medico);

                    return Ok(jsonRestorno);
                }
                else
                {
                    var erros = ModelState.Values
                        .Where(x => x.ValidationState == ModelValidationState.Invalid)
                        .Select(x => x.Errors?.FirstOrDefault()?.ErrorMessage).ToList();
                    return BadRequest(new
                    {
                        PayloadErros = erros
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicoDAO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarMedico(MedicoDAO medico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //update
                    _logger.LogInformation("Put medico {Nome}", medico.Nome);

                    string jsonRestorno = _medicoController.AtualizarMedico(medico);

                    return Ok(jsonRestorno);
                }
                else
                {
                    var erros = ModelState.Values
                        .Where(x => x.ValidationState == ModelValidationState.Invalid)
                        .Select(x => x.Errors?.FirstOrDefault()?.ErrorMessage).ToList();
                    return BadRequest(new
                    {
                        PayloadErros = erros
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IdentificadorMedicoDAO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirMedico(IdentificadorMedicoDAO medico)
        {
            try
            {
                //delete
                _logger.LogInformation("Delete medico {medico.Nome}", medico.Nome);

                _medicoController.RemoverMedico(medico);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

    }
}

