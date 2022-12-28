using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response.Consultas;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapiapplication.Configuration.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Consultas.Preventiva
{
    [Route("api/clinica/{clinicaId}/consultas/preventivas")]
    [Authorize]
    [ApiController]
    public class GetConsultasPreventivasByClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetConsultasPreventivasByClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Consultas", "Clinica" })]
        public async Task<ActionResult<List<ConsultaPreventivaResponse>>> Get([FromRoute] string clinicaId)
        {
            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            var consultas = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(m => m.ConsultasPreventivas)
                .Include(c => c.Mascota).ThenInclude(m => m.Duenio)
                .ToList();

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
