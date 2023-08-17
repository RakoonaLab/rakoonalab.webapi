using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Request.Domicilio;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Domicilio
{
    [Route("api/domicilio/{domicilioId}")]
    [Authorize]
    [ApiController]
    public class UpdateDomicilioController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public UpdateDomicilioController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Domicilio" })]
        public async Task<ActionResult<DomicilioResponse>> Put([FromBody] UpdateDomicilioRequest request, [FromRoute] string domicilioId)
        {
            var domicilio = await _domicilioService.ActualizarAsync(request, domicilioId);

            if (domicilio == null)
                return StatusCode(StatusCodes.Status404NotFound, "domicilio no encontrado");

            return StatusCode(StatusCodes.Status200OK, domicilio);
        }

    }
}
