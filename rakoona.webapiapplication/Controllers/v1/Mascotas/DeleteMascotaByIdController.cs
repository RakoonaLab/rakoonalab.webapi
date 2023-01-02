using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
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
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        
        public async Task<ActionResult<MascotaResponse>> Delete([FromRoute] string mascotaId)
        {
            var respuesta = await _mascotaService.DeleteAsync(mascotaId);
            
            return respuesta ? StatusCode(StatusCodes.Status204NoContent): NotFound();
        }

    }
}
