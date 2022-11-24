using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Vacunas
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
        [SwaggerOperation(Tags = new[] { "Vacunas" })]
        public async Task<ActionResult<List<VacunaResponse>>> GetVacunasByMascotaId([FromRoute] string mascotaId)
        {
            if (_context.Vacunas == null)
            {
                return NotFound();
            }

            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            var vacunas = _context.Vacunas.Where(x => x.MascotaRef == mascota.Id).ToList();

            if (vacunas == null)
            {
                return NotFound();
            }

            return vacunas.Select(x => x.MapToResponse()).ToList();
        }

    }
}
