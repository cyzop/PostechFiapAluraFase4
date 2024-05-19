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
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPacienteController _pacienteController;
        private readonly IPatientRepository databaseClient;

        public PatientController(ILogger<PatientController> logger, IPacienteController pacienteController, IPatientRepository databaseClient)
        {
            _logger = logger;
            _pacienteController = pacienteController;
            this.databaseClient = databaseClient;
        }


        /// <summary>
        /// Inclusão de um novo Paciente
        /// </summary>
        /// <param name="paciente">Json representando as informações do Paciente</param>
        /// <response code="200">Paciente atualizado com sucesso</response>
        /// <response code="400">Falha na inclusão do Paciente</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PacienteDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPaciente(PacienteDao paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //inclusao
                    _logger.LogInformation("Post Paciente {Nome}", paciente.Nome);

                    string jsonRestorno = _pacienteController.RegistrarPaciente(paciente);

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


        /// <summary>
        /// Atualiza as informações do Paciente
        /// </summary>
        /// <param name="paciente">Json representando as informações do Paciente</param>
        /// <response code="200">Paciente atualizado com sucesso</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PacienteDao))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPaciente(PacienteDao paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //update
                    _logger.LogInformation("Put paciente {Nome}", paciente.Nome);

                    string jsonRestorno = _pacienteController.AtualizarPaciente(paciente);

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

        /// <summary>
        /// Retorna a listagem de pacientes
        /// </summary>
        /// <response code="200">Retorno realizado com sucesso</response>
        /// <response code="204">Nenhum Paciente encontrado</response>
        /// <response code="400">Falha na consulta dos pacientes</response>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PacienteDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPacientes()
        {
            try
            {
                var pacientes = _pacienteController.ListarPacientes();
                var quantidade = pacientes?.Count() ?? 0;

                _logger.LogInformation("Get pacientes length {quantidade}", quantidade);

                if (pacientes?.Count() > 0)
                    return Ok(pacientes);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Retorno realizado com sucesso</response>
        /// <response code="400">Falha na consulta dos pacientes</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PacienteDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePaciente(string identificacao)
        {
            try
            {
                //delete
                _logger.LogInformation("Delete paciente {Identificacao}", identificacao);

                _pacienteController.RemoverPaciente(identificacao);
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