using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Request;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/cliente/{clienteId}/mascota")]
    [Authorize]
    [ApiController]
    public class CreateMascotaByClienteController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public CreateMascotaByClienteController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Mascotas })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MascotaResponse>> Post([FromBody] CreateMascotaRequest request, [FromRoute] string clienteId)
        {
            var respuesta = await _mascotaService.CreateAsync(request, clienteId);
            if (respuesta == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, respuesta);
        }

    }
}
