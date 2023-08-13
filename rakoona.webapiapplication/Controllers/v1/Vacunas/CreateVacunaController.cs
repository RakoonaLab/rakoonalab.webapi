using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacuna")]
    [Authorize]
    [ApiController]
    public class CreateVacunaController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public CreateVacunaController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] {
            SwaggerOperationTagsConstant.Vacunas,
            SwaggerOperationTagsConstant.Cartilla
        })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<VacunaResponse>> Post([FromBody] CreateVacunaRequest request, [FromRoute] string cartillaId)
        {
            var vacuna = await _vacunaService.CrearAsync(request, cartillaId);

            if (vacuna == null)
                return NoContent();

            return StatusCode(StatusCodes.Status201Created, vacuna);
        }

    }
}
