using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapiapplication.Controllers.api.v1.Mascota
{
    [Route("api/mascota/{mascotaId}")]
    [Authorize]
    [ApiController]
    public class GetMascotaByIdController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public GetMascotaByIdController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<MascotaResponse>> GetAsync([FromRoute] string mascotaId)
        {
            var respuesta = await _mascotaService.GetAsync(mascotaId);

            if (respuesta == null)
                return Problem();
            if (!respuesta.IsWorking)
                return Problem();
            if (respuesta.Respuesta == null)
                return NotFound();

            return Ok(respuesta.Respuesta);
        }

    }
}
