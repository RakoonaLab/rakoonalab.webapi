using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
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
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Citas, "Imagenes" })]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaResponse>> Post([FromRoute] string mascotaId)
        {
            if (Request.ContentLength == 0)
                return BadRequest();

            IFormFile formFile = Request.Form.Files[0];

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
