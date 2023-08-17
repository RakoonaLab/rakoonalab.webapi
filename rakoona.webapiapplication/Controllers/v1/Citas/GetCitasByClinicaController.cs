using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Citas
{
    [Route("api/clinica/{clinicaId}/citas")]
    [Authorize]
    [ApiController]
    public class GetCitasByClinicaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public GetCitasByClinicaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Citas, SwaggerOperationTagsConstant.Clinica })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CitaResponse>>> Get([FromRoute] string clinicaId)
        {
            var citas = await _citaService.GetCitasByClinica(clinicaId);

            if (citas == null)
                return NoContent();

            return Ok(citas);
        }

    }
}
