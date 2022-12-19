using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.services.Dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.services.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Consultas
{
    [Route("api/consulta/{consultaId}")]
    [Authorize]
    [ApiController]
    public class GetConsultaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultaByIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> Get([FromRoute] string consultaId)
        {
            if (_context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = _context.Consulta.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta.MapToResponse());
        }

    }
}
