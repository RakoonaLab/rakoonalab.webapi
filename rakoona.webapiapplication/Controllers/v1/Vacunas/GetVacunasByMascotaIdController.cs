using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/mascota/{mascotaId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByMascotaIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetVacunasByMascotaIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Mascotas" })]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string mascotaId)
        {
            if (_context.Vacunas == null)
            {
                return NotFound();
            }

            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            var vacunas = _context.Vacunas.Where(x => x.ConsultaPreventiva.MascotaRef == mascota.Id && x.ConsultaPreventiva.Motivo == "Vacuna")
                .Include(x => x.ConsultaPreventiva)
                .ToList();

            if (vacunas == null)
            {
                return NotFound();
            }

            return Ok(vacunas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
