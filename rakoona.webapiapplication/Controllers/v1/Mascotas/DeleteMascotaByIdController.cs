using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/mascota/{mascotaId}")]
    [Authorize]
    [ApiController]
    public class DeleteMascotaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public DeleteMascotaByIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<MascotaResponse>> Delete([FromRoute] string mascotaId)
        {
            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            if (mascota == null)
                return NotFound();

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
