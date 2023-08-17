using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.dtos.Response;
using rakoona.core.Services.Interfaces;
using rakoona.webapi.Configuration.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Mascotas
{
    [Route("api/clientes/{clienteId}/mascotas")]
    [Authorize]
    [ApiController]
    public class GetVacunasByMascotaIdController : ControllerBase
    {
        private readonly IMascotaService _mascotaService;
        public GetVacunasByMascotaIdController(
            IMascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { SwaggerOperationTagsConstant.Mascotas })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MascotaResponse>>> Get([FromRoute] string clienteId)
        {
            var respuesta = await _mascotaService.GetPorCliente(clienteId);

            if (respuesta == null)
                return NotFound();

            return Ok(respuesta);
        }

    }
}
