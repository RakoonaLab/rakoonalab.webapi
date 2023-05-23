using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/cliente/{clienteId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByClienteController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public GetVacunasByClienteController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Cliente" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string clienteId)
        {
            var vacunas = await _vacunaService.GetVacunasByCliente(clienteId);

            if (vacunas == null)
                return NoContent();

            return Ok(vacunas);
        }

    }
}
