using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request.Domicilio;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Domicilio
{
    [Route("api/mascota/{mascotaId}/domicilio")]
    [Authorize]
    [ApiController]
    public class CreateDomicilioByMascotaController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public CreateDomicilioByMascotaController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Domicilio" })]
        [ProducesResponseType(typeof(DomicilioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DomicilioResponse>> Get([FromBody] CreateDomicilioRequest request, [FromRoute] string mascotaId)
        {
            var domicilio = await _domicilioService.CrearByMascotaAsync(request, mascotaId);

            if (domicilio == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, domicilio);
        }

    }
}
