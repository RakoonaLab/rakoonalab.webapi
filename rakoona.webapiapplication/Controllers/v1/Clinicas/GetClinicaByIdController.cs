using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Entities.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Clinicas
{
    [Route("api/clinica/{clinicaId}")]
    [Authorize]
    [ApiController]
    public class GetClinicaByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetClinicaByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Clinica" })]
        public async Task<ActionResult<ClinicaResponse>> Get([FromRoute] string clinicaId)
        {
            if (_context.Clinicas == null)
            {
                return NotFound();
            }
            var clinica = _context.Clinicas.Single(x => x.ExternalId == clinicaId);

            if (clinica == null)
            {
                return NotFound();
            }

            return Ok(clinica.MapToResponse());
        }

    }
}
