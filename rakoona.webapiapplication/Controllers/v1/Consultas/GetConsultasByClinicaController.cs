using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/clinica/{clinicaId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByClinicaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public GetConsultasByClinicaController(
            IConsultaService consultaService
            )
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string clinicaId)
        {
            var response = await _consultaService.GetConsultasByClinica(clinicaId);
            if (response == null)
                return NoContent();
            return Ok(response);
        }

    }
}
