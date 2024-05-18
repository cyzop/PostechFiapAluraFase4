using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.Consultorio.Controllers;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Repositories;

namespace PosTech.Consultorio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalCareController : ControllerBase
    {
        private readonly ILogger<MedicalCareController> _logger;
        private readonly AtendimentoController _atendimentoController;
        private readonly IMedicalCareRepository _atendimentoStore;

        public MedicalCareController(ILogger<MedicalCareController> logger, AtendimentoController atendimentoController, IMedicalCareRepository atendimentoStore)
        {
            _logger = logger;
            _atendimentoController = atendimentoController;
            _atendimentoStore = atendimentoStore;
        }

        [HttpGet]
        [Route("ListByDate/{dateFormatyyyyMMdd}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AtendimentoMedicoDAO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMedicos(int dateFormatyyyyMMdd)
        {
            try
            {
                var atendimentos = _atendimentoController.ListarAtendimentosPorData(dateFormatyyyyMMdd);
                var quantidade = atendimentos?.Count() ?? 0;

                _logger.LogInformation("Get atendimentos por data {dateFormatyyyyMMdd} length {quantidade}", 
                    dateFormatyyyyMMdd,
                    quantidade);

                if (atendimentos?.Count() > 0)
                    return Ok(atendimentos);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ListByMedicalDoctor/{medicalId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AtendimentoMedicoDAO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtendimentosPorMedico(string medicalId)
        {
            try
            {
                var atendimentos = _atendimentoController.ListarAtendimentosPorMedico(medicalId);
                var quantidade = atendimentos?.Count() ?? 0;

                _logger.LogInformation("Get atendimentos por Medico {medicalId} length {quantidade}",
                    medicalId,
                    quantidade);

                if (atendimentos?.Count() > 0)
                    return Ok(atendimentos);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ListByPatient/{patienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AtendimentoMedicoDAO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtendimentosPorPaciente(string patienteId)
        {
            try
            {
                var atendimentos = _atendimentoController.ListarAtendimentosPorPaciente(patienteId);
                var quantidade = atendimentos?.Count() ?? 0;

                _logger.LogInformation("Get atendimentos por Paciente {patienteId} length {quantidade}",
                    patienteId,
                    quantidade);

                if (atendimentos?.Count() > 0)
                    return Ok(atendimentos);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AtendimentoMedicoDAO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IncluirAtendimento(AtendimentoMedicoDAO atendimento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //update
                    _logger.LogInformation("Post atendimento {data}", atendimento.DataAtendimento.ToString("dd/MM/yyyy"));

                    string jsonRestorno = _atendimentoController.IncluirAtendimento(atendimento);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AtendimentoMedicoDAO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarAtendimento(AtendimentoMedicoDAO atendimento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //update
                    _logger.LogInformation("Put atendimento {data}", atendimento.DataAtendimento.ToString("dd/MM/yyyy"));

                    string jsonRestorno = _atendimentoController.AtualizarAtendimento(atendimento);

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
    }
}
