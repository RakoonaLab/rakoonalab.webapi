using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/clinica/{clinicaId}/mascotas/count")]
    [Authorize]
    [ApiController]
    public class GetContadorMascotasByClinicaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public GetContadorMascotasByClinicaController(
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
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clinicaId)
        {

            var respuesta = await _mascotaService.GetContadorDeMascotasPorClinica(clinicaId);

            return Ok(respuesta);
        }

    }
}
