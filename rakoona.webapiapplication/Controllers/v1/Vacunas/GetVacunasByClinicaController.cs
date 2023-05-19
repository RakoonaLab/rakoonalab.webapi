using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/clinica/{clinicaId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByClinicaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserInfoService _userInfo;

        public GetVacunasByClinicaController(
            ApplicationDbContext context,
            IUserInfoService userInfo
            )
        {
            _userInfo = userInfo;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Clinica" })]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string clinicaId)
        {
            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            var vacunas = _context.ClientesClinicas
                .Where(x => x.ClinicaId == clinica.Id)
                .SelectMany(c => c.Cliente.Mascotas)
                .SelectMany(m => m.Consultas)
                .SelectMany(v => v.Vacunas)
                
                .Include(c => c.Consulta)
                .ThenInclude(m=> m.Medico)

                .Include(c => c.Consulta)
                .ThenInclude(c => c.Mascota)
                .ThenInclude(m => m.Duenio)

                .ToList();

            if (vacunas == null)
            {
                return NotFound();
            }

            return Ok(vacunas.Select(x => x.MapToResponse()).ToList());
        }

    }
}
