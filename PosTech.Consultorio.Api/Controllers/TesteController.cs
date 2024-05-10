using Microsoft.AspNetCore.Mvc;

namespace PosTech.Consultorio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Funcionou");
        }
    }
}
