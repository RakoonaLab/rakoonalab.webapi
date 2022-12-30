using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacuna")]
    [ApiController]
    public class CreateVacunaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateVacunaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Mascotas" })]
        public async Task<ActionResult<VacunaResponse>> Post([FromBody] CreateVacunaRequest request, [FromRoute] string mascotaId)
        {
            if (_context.Vacunas == null)
                return Problem("Entity set 'ApplicationDbContext.Vacunas'  is null.");

            var mascota = _context.Mascotas.Single(x => x.ExternalId == mascotaId);

            if (mascota == null)
            {
                return NotFound();
            }

            var vacuna = request.CreateFromRequest(mascota.Id);

            _context.Vacunas.Add(vacuna);
            await _context.SaveChangesAsync();

            var response = vacuna.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
