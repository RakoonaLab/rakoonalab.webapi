using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/consulta/{consultaId}")]
    [Authorize]
    [ApiController]
    public class ÚpdateConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;

        public ÚpdateConsultaController(
            IConsultaService service)
        {
            _service = service;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ConsultaResponse>> Put([FromBody] UpdateConsultaRequest request, [FromRoute] string consultaId)
        {
            var response = await _service.Update(request, consultaId);

            if (response == null)
                return NoContent();

            return StatusCode(StatusCodes.Status200OK, response);
        }

    }
}
