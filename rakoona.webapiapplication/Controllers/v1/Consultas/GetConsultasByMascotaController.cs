using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas
{
    [Route("api/mascota/{mascotaId}/consultas")]
    [Authorize]
    [ApiController]
    public class GetConsultasByMascotaController : ControllerBase
    {
        private readonly IConsultaService _context;
        private IUserInfoService _userInfo;

        public GetConsultasByMascotaController(
            IConsultaService context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        public async Task<ActionResult<List<ConsultaResponse>>> Get([FromRoute] string mascotaId)
        {
            var consultas = await _context.GetConsultasByMascota(mascotaId);

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas);
        }

    }
}
