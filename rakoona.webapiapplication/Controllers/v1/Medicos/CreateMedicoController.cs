using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Medicos
{
    [Route("api/clinica/{clinicaId}/medico")]
    [Authorize]
    [ApiController]
    public class CreateMedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public CreateMedicoController(
            IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Medico", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<MedicoResponse>> Post([FromBody] CreateMedicoRequest request, [FromRoute] string clinicaId)
        {
            var response = await _medicoService.CrearAsync(request, clinicaId);
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
