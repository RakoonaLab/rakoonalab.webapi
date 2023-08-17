using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Parameters;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clientes
{
    [Route("api/clinica/{clinicaId}/clientes")]
    [Authorize]
    [ApiController]
    public class GetClientesByClinicaIdController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public GetClientesByClinicaIdController(
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
        public async Task<ActionResult<List<ClienteResponse>>> Get([FromRoute] string clinicaId,
                                                                   [FromQuery] string? nombres,
                                                                   [FromQuery] string? apellidos,
                                                                   [FromQuery] string? celular,
                                                                   [FromQuery] int? page,
                                                                   [FromQuery] int? pagesize)
        {
            var parameters = new SearchClienteParameters() { Nombres = nombres, Apellidos = apellidos, Celular = celular };
            var pagination = new PaginationParameters(page, pagesize);

            var result = await _clienteService.GetClientesByClinica(clinicaId, parameters, pagination);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
