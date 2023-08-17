using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/clinica/{clinicaId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByClinicaController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public GetVacunasByClinicaController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] {
            SwaggerOperationTagsConstant.Vacunas,
            SwaggerOperationTagsConstant.Clinica
        })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string clinicaId)
        {
            var vacunas = await _vacunaService.GetVacunasByClinica(clinicaId);

            if (vacunas == null)
                return NoContent();

            return Ok(vacunas);
        }

    }
}
