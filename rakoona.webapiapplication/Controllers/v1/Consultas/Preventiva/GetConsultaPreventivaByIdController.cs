using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Preventiva
{
    [Route("api/consulta/preventiva/{consultaId}")]
    [Authorize]
    [ApiController]
    public class GetConsultaPreventivaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultaPreventivaByIdController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaPreventivaResponse>> Get([FromRoute] string consultaId)
        {

            var consulta = _context.ConsultaPreventiva.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta.MapToResponse());
        }

    }
}
