using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Citas
{
    [Route("api/mascota/{mascotaId}/cita")]
    [Authorize]
    [ApiController]
    public class CreateCitaController : ControllerBase
    {
        private readonly ICitaService _context;
        public CreateCitaController(
            ICitaService context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Citas, SwaggerOperationTagsConstant.Citas })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CitaResponse>> Post([FromBody] CreateCitaRequest request, [FromRoute] string mascotaId)
        {
            var cita = await _context.Create(request, mascotaId);
            if (cita == null)
            {

            }
            return StatusCode(StatusCodes.Status201Created, cita);
        }

    }
}
