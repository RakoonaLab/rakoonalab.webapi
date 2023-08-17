using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rakoona.models.dtos.Response;
using rakoona.core.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace rakoona.webapi.Controllers.v1.Domicilio
{
    [Route("api/mascota/{mascotaId}/domicilio")]
    [Authorize]
    [ApiController]
    public class GetDomicilioByMascotaController : ControllerBase
    {
        private readonly IDomicilioService _domicilioService;

        public GetDomicilioByMascotaController(IDomicilioService domicilioService)
        {
            _domicilioService = domicilioService;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Mascotas", "Domicilio" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DomicilioResponse>> Get(string mascotaId)
        {
            var domicilio = await _domicilioService.GetDomicilioPrincipalByMascotaAsync(mascotaId);

            if (domicilio == null)
                return NoContent();

            return Ok(domicilio);
        }

    }
}
