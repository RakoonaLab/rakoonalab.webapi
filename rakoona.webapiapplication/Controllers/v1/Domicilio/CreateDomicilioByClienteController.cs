using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Domicilio;
using rakoona.models.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Domicilio
{
    [Route("api/cliente/{clienteId}/domicilio")]
    [Authorize]
    [ApiController]
    public class CreateDomicilioByClienteController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public CreateDomicilioByClienteController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Clientes", "Domicilio" })]
        [ProducesResponseType(typeof(DomicilioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DomicilioResponse>> Get([FromBody] CreateDomicilioRequest request, [FromRoute] string clienteId)
        {
            var domicilio = await _domicilioService.CrearByClienteAsync(request, clienteId);

            if (domicilio == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, domicilio);
        }

    }
}
