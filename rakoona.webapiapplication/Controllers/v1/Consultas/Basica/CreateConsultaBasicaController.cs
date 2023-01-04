using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request.Consultas;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Entities.Models.Consultas;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Consultas.Basica
{
    [Route("api/mascota/{mascotaId}/consulta/basica")]
    [Authorize]
    [ApiController]
    public class CreateConsultaBasicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public CreateConsultaBasicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo)
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Consultas", "Mascotas" })]
        public async Task<ActionResult<ConsultaBasicaResponse>> Post([FromRoute] string mascotaId)
        {
            //if (_context.Clinicas == null)
            //    return Problem("Entity set 'ApplicationDbContext.Consultas'  is null.");

            var mascota = _context.Mascotas.FirstOrDefault(x => x.ExternalId == mascotaId);

            var consulta = new ConsultaBasica()
            {
                ExternalId = Guid.NewGuid().ToString(),
                FechaDeCreacion = DateTime.Now,
                MascotaRef = mascota.Id
            };

            await _context.ConsultaBasica.AddAsync(consulta);
            await _context.SaveChangesAsync();

            var response = consulta.MapToResponse();
            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
