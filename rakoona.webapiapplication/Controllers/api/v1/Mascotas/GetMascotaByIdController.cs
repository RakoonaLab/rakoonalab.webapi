using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Personas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

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
        public async Task<ActionResult<PacienteResponse>> Get([FromRoute] string mascotaId)
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
