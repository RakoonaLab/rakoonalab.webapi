using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clientes
{
    [Route("api/clinica/{clinicaId}/clientes/count")]
    [Authorize]
    [ApiController]
    public class GetContadorDeClientesByClinicaIdController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public GetContadorDeClientesByClinicaIdController(
            IClienteService clienteService
            )
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clientes", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ClienteResponse>>> Get([FromRoute] string clinicaId)
        {
            var result = await _clienteService.GetContadorClientesByClinica(clinicaId);

            return Ok(result);
        }

    }
}
