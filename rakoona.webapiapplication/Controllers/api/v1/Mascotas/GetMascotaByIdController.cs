using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

namespace rakoona.webapiapplication.Controllers.api.v1.Mascota
{
    [Route("api/mascota/{mascotaId}")]
    [Authorize]
    [ApiController]
    public class GetMascotaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetMascotaByIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<MascotaResponse>> Get([FromRoute] string mascotaId)
        {
            if (_context.Mascotas == null)
            {
                return NotFound();
            }

            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            if (mascota == null)
            {
                return NotFound();
            }

            return mascota.MapToResponse();
        }

    }
}
