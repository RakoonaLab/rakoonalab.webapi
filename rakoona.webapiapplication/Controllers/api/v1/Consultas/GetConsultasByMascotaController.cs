using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.services.Dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Consultas
{
    [Route("api/mascota/{mascotaId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByMascotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasByMascotaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas","Mascotas" })]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string mascotaId)
        {
            if (_context.Consulta == null)
            {
                return NotFound();
            }

            var mascota = _context.Mascotas.Single(x => x.ExternalId == mascotaId);


            var consultas = _context.Consulta.Where(x => x.MascotaRef == mascota.Id).ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
