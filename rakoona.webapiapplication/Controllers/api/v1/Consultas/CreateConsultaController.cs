using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.webapiapplication.Configuration.Services;
using rakoona.webapiapplication.Context;
using rakoona.webapiapplication.Entities.Dtos.Request;
using rakoona.webapiapplication.Entities.Dtos.Response;
using rakoona.webapiapplication.Entities.Models.Consultas;
using rakoona.webapiapplication.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Consultas
{
    [Route("api/mascota/{mascotaId}/consulta")]
    [Authorize]
    [ApiController]
    public class CreateConsultaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public CreateConsultaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Consultas" })]
        public async Task<ActionResult<ConsultaResponse>> PostConsulta([FromBody] CreateConsultaRequest request, [FromRoute] string mascotaId)
        {
            //if (_context.Clinicas == null)
            //    return Problem("Entity set 'ApplicationDbContext.Consultas'  is null.");

            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            var consulta = request.CreateFromRequest(mascota.Id);

            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
