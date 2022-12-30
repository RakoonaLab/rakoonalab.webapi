using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Consultas;
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
    public class ÚpdateConsultaPreventivaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public ÚpdateConsultaPreventivaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaPreventivaResponse>> Put([FromBody] UpdateConsultaRequest request, [FromRoute] string consultaId)
        {
            var consulta = _context.ConsultaPreventiva.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
                return StatusCode(StatusCodes.Status404NotFound, "Consulta no encontrada");

            var update = request.UpdateFromRequest(consulta);

            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
