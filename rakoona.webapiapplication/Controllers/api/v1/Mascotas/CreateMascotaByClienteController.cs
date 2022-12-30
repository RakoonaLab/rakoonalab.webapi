using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Request;
using rakoona.models.dtos.Response;
using rakoona.services.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.api.v1.Mascota
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
        [SwaggerOperation(Tags = new[] { "Mascotas" })]
        public async Task<ActionResult<MascotaResponse>> Post([FromBody] CreatePacienteRequest request, [FromRoute] string clienteId)
        {
            var respuesta = await _mascotaService.CreateAsync(request, clienteId);
            if (respuesta == null)
                return Problem();

            if (!respuesta.IsWorking)
            {
                return Problem();
            }

            return StatusCode(StatusCodes.Status201Created, respuesta.Respuesta);
        }

    }
}
