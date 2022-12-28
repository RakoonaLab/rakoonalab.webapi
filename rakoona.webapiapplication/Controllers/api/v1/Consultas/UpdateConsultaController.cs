using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using Swashbuckle.AspNetCore.Annotations;
using rakoona.services.Entities.Mappers;

namespace rakoona.webapi.Controllers.api.v1.Consultas
{
    [Route("api/consulta/{consultaId}")]
    [Authorize]
    [ApiController]
    public class ÚpdateConsultaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public ÚpdateConsultaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> Put([FromBody] UpdateConsultaRequest request, [FromRoute] string consultaId)
        {
            if (_context.Consulta == null)
                return Problem("Entity set 'ApplicationDbContext.Consulta'  is null.");

            var consulta = _context.Consulta.FirstOrDefault(x => x.ExternalId == consultaId);

            if (consulta == null)
                return StatusCode(StatusCodes.Status404NotFound, "Consulta no encontrada");

            var update = request.UpdateFromRequest(consulta);

            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
