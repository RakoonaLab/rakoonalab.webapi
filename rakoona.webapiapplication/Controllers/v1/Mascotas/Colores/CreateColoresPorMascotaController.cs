using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas.Colores
{
    [Route("api/mascota/{mascotaId}/colores")]
    [Authorize]
    [ApiController]
    public class CreateColoresPorMascotaController : ControllerBase
    {
        private readonly IColoresPorMascotaService _coloresService;
        public CreateColoresPorMascotaController(
            IColoresPorMascotaService coloresService)
        {
            _coloresService = coloresService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Colores" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaResponse>> Post([FromBody] CreateColoresPorMascotaRequest request, [FromRoute] string mascotaId)
        {
            var respuesta = await _coloresService.CreateAsync(request, mascotaId);
            if (respuesta == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, respuesta);
        }

    }
}
