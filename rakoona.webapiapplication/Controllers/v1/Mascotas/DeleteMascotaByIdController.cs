using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.core.Services.Interfaces;
using rakoona.dtos.Response;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/mascota/{mascotaId}")]
    [Authorize]
    [ApiController]
    public class DeleteMascotaByIdController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public DeleteMascotaByIdController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Mascotas })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<MascotaResponse>> Delete([FromRoute] string mascotaId)
        {
            var respuesta = await _mascotaService.DeleteAsync(mascotaId);

            return respuesta ? StatusCode(StatusCodes.Status204NoContent) : NotFound();
        }

    }
}
