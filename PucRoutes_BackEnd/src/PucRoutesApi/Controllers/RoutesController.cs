using Microsoft.AspNetCore.Mvc;
using Otimizacao;

namespace PucRoutesApi.ViewModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        // GET: api/Routes
        [HttpGet("{Vi}/{Vf}")]
        public IActionResult Get(int Vi, int Vf)
        {
            if (Vi < 0 || Vf > 22)
                return BadRequest();

            var caminho = Modelo.Solve(Vi, Vf);

            return Ok(caminho);
        }

    }
}
