using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Parameters;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Tags = new[] {
            SwaggerOperationTagsConstant.Mascotas,
            SwaggerOperationTagsConstant.Clinica,
        })]
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
