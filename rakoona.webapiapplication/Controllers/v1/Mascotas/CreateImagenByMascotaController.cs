using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/mascota/{mascotaId}/imagenes/principal")]
    [Authorize]
    [ApiController]
    public class CreateImagenByMascotaController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public CreateImagenByMascotaController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Imagenes" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaResponse>> Post([FromForm] IFormFile formFile, [FromRoute] string mascotaId)
        {

            var request = new FileDetailsRequest()
            {
                FileName = formFile.FileName,
            };

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                request.FileData = stream.ToArray();
            }

            var respuesta = await _mascotaService.CreateImage(request, mascotaId);
            if (respuesta)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return Problem();
        }
    }
}
