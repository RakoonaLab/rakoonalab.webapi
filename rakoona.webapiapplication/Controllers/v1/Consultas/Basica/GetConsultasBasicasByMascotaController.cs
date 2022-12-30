using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Basica
{
    [Route("api/mascota/{mascotaId}/consultas/basicas")]
    [Authorize]
    [ApiController]
    public class GetConsultasBasicasByMascotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasBasicasByMascotaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        public async Task<ActionResult<List<ConsultaBasicaResponse>>> Get([FromRoute] string mascotaId)
        {
            var mascota = _context.Mascotas.Single(x => x.ExternalId == mascotaId);

            var consultas = _context.ConsultaBasica.Where(x => x.MascotaRef == mascota.Id).ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
