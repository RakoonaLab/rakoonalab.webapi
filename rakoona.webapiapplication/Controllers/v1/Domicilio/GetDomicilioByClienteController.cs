using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Domicilio
{
    [Route("api/cliente/{clienteId}/domicilio")]
    [Authorize]
    [ApiController]
    public class GetDomicilioByClienteController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public GetDomicilioByClienteController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Domicilio" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DomicilioResponse>> Get(string clienteId)
        {
            var domicilio = await _domicilioService.GetDomicilioPrincipalByClienteAsync(clienteId);

            if (domicilio == null)
                return NoContent();

            return Ok(domicilio);
        }

    }
}
