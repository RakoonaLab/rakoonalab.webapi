using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacuna")]
    [ApiController]
    public class CreateVacunaController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public CreateVacunaController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Mascotas" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<VacunaResponse>> Post([FromBody] CreateVacunaRequest request, [FromRoute] string mascotaId)
        {
            var vacuna = await _vacunaService.CrearAsync(request, mascotaId);

            if (vacuna == null)
                return NotFound();
        }

    }
}
