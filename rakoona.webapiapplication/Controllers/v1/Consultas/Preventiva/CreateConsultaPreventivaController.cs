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
    [Route("api/mascota/{mascotaId}/consulta/preventiva")]
    [Authorize]
    [ApiController]
    public class CreateConsultaPreventivaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public CreateConsultaPreventivaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        public async Task<ActionResult<ConsultaPreventivaResponse>> Post([FromBody] CreateConsultaPreventivaRequest request, [FromRoute] string mascotaId)
        {
            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            var consulta = request.CreateFromRequest(mascota.Id);

            _context.ConsultaPreventiva.Add(consulta);
            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
