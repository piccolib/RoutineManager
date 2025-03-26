using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutineManager.API.Controllers
{
    [Route("api/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Teste de rota" });
        }
    }
}
