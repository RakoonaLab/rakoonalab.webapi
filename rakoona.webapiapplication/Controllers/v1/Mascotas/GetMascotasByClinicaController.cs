using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
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
        [SwaggerOperation(Tags = new[] { "Mascotas", "Clinica" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clinicaId)
        {
            var respuesta = await _mascotaService.GetPorClinica(clinicaId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
