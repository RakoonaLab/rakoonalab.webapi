using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Basica
{
    [Route("api/consulta/basica/{consultaId}")]
    [Authorize]
    [ApiController]
    public class GetConsultaBasicaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultaBasicaByIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaBasicaResponse>> Get([FromRoute] string consultaId)
        {

            var consulta = _context.ConsultaBasica.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta.MapToResponse());
        }

    }
}
