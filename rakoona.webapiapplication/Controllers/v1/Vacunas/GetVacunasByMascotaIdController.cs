using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByMascotaIdController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public GetVacunasByMascotaIdController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Mascotas" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string mascotaId)
        {
            var vacunas = await _vacunaService.GetVacunasByMascota(mascotaId);

            if (vacunas == null)
                return NoContent();

            return Ok(vacunas);
        }

    }
}
