using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rakoona.models.dtos.Parameters;
using rakoona.models.dtos.Response;
using rakoona.services.Entities.Models.TiposDeContacto;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing.Printing;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/clinica/{clinicaId}/mascotas")]
    [Authorize]
    [ApiController]
    public class GetMascotasByClinicaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public GetMascotasByClinicaController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clinicaId,
                                                                   [FromQuery] string? nombre,
                                                                   [FromQuery] string? raza,
                                                                   [FromQuery] string? especie,
                                                                   [FromQuery] int? page,
                                                                   [FromQuery] int? pagesize)
        {

            var parameters = new SearchMascotaParameters() { Nombre = nombre, Raza = raza, Especie = especie };
            var pagination = new PaginationParameters(page, pagesize);
            var respuesta = await _mascotaService.GetPorClinica(clinicaId, parameters, pagination);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
