using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Domicilio
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
        public async Task<ActionResult<DomicilioResponse>> Get(string clienteId)
        {
            var domicilio = await _domicilioService.GetDomicilioPrincipalByClienteAsync(clienteId);

            if (domicilio == null)
                return NotFound();

            return Ok(domicilio);
        }

    }
}
