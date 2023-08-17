using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Celular
{
    [Route("api/cliente/{clienteId}/celular")]
    [Authorize]
    [ApiController]
    public class GetCelularByClienteController : ControllerBase
    {
        private readonly IInformacionDeContactoService _infoContactoService;

        public GetCelularByClienteController(IInformacionDeContactoService inforContactoService)
        {
            _infoContactoService = inforContactoService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Celular" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CelularResponse>> Get(string clienteId)
        {
            var response = await _infoContactoService.GetCelularByCliente(clienteId);

            if (response == null)
                return NoContent();
            return Ok(response);

        }

    }
}
