using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Preventiva
{
    [Route("api/mascota/{mascotaId}/consultas/preventivas")]
    [Authorize]
    [ApiController]
    public class GetConsultasPreventivasByMascotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasPreventivasByMascotaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        public async Task<ActionResult<List<ConsultaPreventivaResponse>>> Get([FromRoute] string mascotaId)
        {
            var mascota = _context.Mascotas.Single(x => x.ExternalId == mascotaId);

            var consultas = _context.ConsultaPreventiva.Where(x => x.MascotaRef == mascota.Id).ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
