using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
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
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Mascotas })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<MascotaResponse>> GetAsync([FromRoute] string mascotaId)
        {
            var respuesta = await _mascotaService.GetAsync(mascotaId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
