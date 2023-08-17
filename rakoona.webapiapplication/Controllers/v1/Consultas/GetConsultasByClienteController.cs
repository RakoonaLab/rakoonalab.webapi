using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/cliente/{clienteId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByClienteController : ControllerBase
    {
        private readonly IConsultaService _context;

        public GetConsultasByClienteController(
            IConsultaService context
            )
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Clientes" })]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string clienteId)
        {
            var consultas = await _context.GetConsultaByCliente(clienteId);
            if (consultas == null)
            {
                return NoContent();
            }
            return Ok(consultas);
        }

    }
}
