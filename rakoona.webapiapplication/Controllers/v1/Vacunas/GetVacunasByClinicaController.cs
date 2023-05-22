using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rakoona.models.dtos.Response;
using rakoona.services.Context;
using rakoona.services.Entities.Mappers;
using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Services.Implementacion;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace rakoona.webapi.Controllers.v1.Vacunas
{
    [Route("api/clinica/{clinicaId}/vacunas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByClinicaController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public GetVacunasByClinicaController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Vacunas", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<VacunaResponse>>> Get([FromRoute] string clinicaId)
        {
            var vacunas = await _vacunaService.GetVacunasByClinica(clinicaId);

            if (vacunas == null)
                return NoContent();

            return Ok(vacunas);
        }

    }
}
