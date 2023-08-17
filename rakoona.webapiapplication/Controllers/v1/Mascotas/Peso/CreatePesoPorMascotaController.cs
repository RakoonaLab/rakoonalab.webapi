using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Peso
{
    [Route("api/mascota/{mascotaId}/peso")]
    [Authorize]
    [ApiController]
    public class CreatePesoPorMascotaController : ControllerBase
    {
        private readonly IPesoPorMascotaService _pesoService;
        public CreatePesoPorMascotaController(
            IPesoPorMascotaService pesoService)
        {
            _pesoService = pesoService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] {
            SwaggerOperationTagsConstant.Peso,
            SwaggerOperationTagsConstant.Mascotas
        })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaResponse>> Post([FromBody] CreatePesoPorMascotaRequest request, [FromRoute] string mascotaId)
        {
            var respuesta = await _pesoService.CreateAsync(request, mascotaId);
            if (respuesta == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, respuesta);
        }

    }
}
