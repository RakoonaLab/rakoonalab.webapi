using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request.Consultas;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/mascota/{mascotaId}/consulta")]
    [Authorize]
    [ApiController]
    public class CreateConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public CreateConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ConsultaResponse>> Post([FromBody] CreateConsultaRequest request, [FromRoute] string mascotaId)
        {
            var consulta = await _consultaService.CrearAsync(request, mascotaId);

            if (consulta == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, consulta);
        }

    }
}